using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
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
        //member variables
        public static Client client;
        TcpListener server;
        bool isOn;
        private Queue<Message> chats;
        private Dictionary<Client, int> users;
        private TextLogger textLogger;
        object messageLock = new object();

        //constructor      

        public Server(TextLogger textLogger)
        {
            server = new TcpListener(IPAddress.Any, 14234);
            server.Start();
            isOn = true;
            users = new Dictionary<Client, int>();
            chats = new Queue<Message>();
            this.textLogger = textLogger;
            Parallel.Invoke(ConstantlyListen);
            Parallel.Invoke(Run);          
        }
        
        
        
        //member methods    
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
                    Message msg = RemoveMessageFromQueue();
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

        private Message RemoveMessageFromQueue()
        {
            return chats.Dequeue();
        }

        private void NotifyOfNewUserToChat(Client client)
        {
            lock(messageLock)
            {
                Message newUserMessage = new Message(client, client.username + " has joined the chat!");
                chats.Enqueue(newUserMessage);
            }
        }

        public void LogMessages(Client client, Message chatMessage)
        {
            lock (messageLock)
            {
                chats.Enqueue(chatMessage);

            }
        }

        public void DisplayTime()
        {
            DateTime localDate = DateTime.Now;
            string[] cultureNames = { "en-US" }; 
            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("{0}: {1}", cultureName,
                                  localDate.ToString(culture));
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
