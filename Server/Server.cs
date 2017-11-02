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
        //member variables
        public static Client client;
        TcpListener server;
        bool isOn;
        private Queue<Message> chats;
        private Dictionary<Client, int> users;
<<<<<<< HEAD
        private TextLogger textLogger;
=======
        object messageLock = new object();
>>>>>>> 40d5ac7ddad585baf3f9d5ac024abc73f6bf4333


        //constructor      

        public Server(TextLogger textLogger)
        {
            server = new TcpListener(IPAddress.Any, 14234);
            server.Start();
            isOn = true;
            users = new Dictionary<Client, int>();
            chats = new Queue<Message>();
<<<<<<< HEAD
            this.textLogger = textLogger;
            Parallel.Invoke(ConstantlyListen);            
        }
        
        
        
        //member methods
=======
            Parallel.Invoke(ConstantlyListen);
            //Parallel.Invoke(ConstantlyDisplayChats);                  
        }

        //public void ConstantlyDisplayChats()
        //{
        //    while(true)
        //    {
        //        Console.WriteLine(chats);
        //    }     
        //}
            
>>>>>>> 40d5ac7ddad585baf3f9d5ac024abc73f6bf4333
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
<<<<<<< HEAD
=======
            client.AskForUsername();
            AddUserToDictionary(client);
            NotifyOfNewUserToChat(client);
>>>>>>> 40d5ac7ddad585baf3f9d5ac024abc73f6bf4333
        }

        private void Respond(string body)
        {
             client.Send(body);
        }

        private void AddMessageToQueue(Client client, Message message)
        {
            chats.Enqueue(message);
        }
     
        private void AddUserToDictionary(Client client)
        {
            users.Add(client, client.IDNumber);
            client.IDNumber++;
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
