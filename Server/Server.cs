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


        public Server(ILogger log)
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
    }
}
