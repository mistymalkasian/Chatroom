using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        public static Client client;
        TcpListener server;
        bool isOn;
        private Queue<Message> chats;
        private Dictionary<Client, int> users;
        object messageLock = new object();


        public Server(TextLogger textlogger)
        {
            server = new TcpListener(IPAddress.Any, 9999);
            isOn = true;
            users = new Dictionary<Client, int>();
            chats = new Queue<Message>();
            Parallel.Invoke(ConstantlyListen);             
        }
            
        public void ConstantlyListen()
        {
            while (isOn == true)
            {
                server.Start();

                if (server.Pending())
                {
                    Parallel.Invoke(AcceptClient);                    
                }
            }            
        }

        public void Run()
        {
            AcceptClient();
            string message = client.Receive();
            Task.Run(() => Respond(message));
        }

        private void AcceptClient()
        {
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
            Task.Run(() => DisplayAllMessages(client));
            AddUserToDictionary(client);
            NotifyOfNewUserToChat(client);
        }

        public void DisplayAllMessages(Client client)
        {

            while (true)
            {
                if (chats.Count() <= (0))
                {
                    Message msg = RemoveMessagesFromQueue();
                    lock (messageLock)
                    {
                        foreach (KeyValuePair<Client, int> user in users)
                        {
                            foreach (Message chat in chats)
                            {
                                client.Send(msg.Body);
                            }
                        }
                    }
                }
            }
        }

        private void Respond(string body)
        {
             client.Send(body);
        }
        private void AddUserToDictionary(Client client)
        {
            users.Add(client, client.IDNumber);
            client.IDNumber++;
        }

        private void AddMessageToQueue(Client client, Message message)
        {
            chats.Enqueue(message);
        }

        private Message RemoveMessagesFromQueue()
        {
            return chats.Dequeue();
        }

        private void NotifyOfNewUserToChat(Client client)
        {
            Message newUserMessage = new Message(client, client.username + " has joined the chat!");
            chats.Enqueue(newUserMessage);
        }

        public void LogMessages(Client client, Message chatMessage)
        {
            lock (messageLock)
            {
                chats.Enqueue(chatMessage);
            }
        }

        public void LogLeaveMessage(Client client)
        {
            lock (messageLock)
            {
                Message leaveMessage = new Message(client, client.username + " has left the chat.");
                chats.Enqueue(leaveMessage);
            }
        }
    }
}
