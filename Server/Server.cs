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
        int userValue;
        string username;
        bool isOn;

        public Server(ILogger log)
        {
            server = new TcpListener(IPAddress.Any, 9999);
            isOn = true;
            Dictionary<Client, int> users = new Dictionary<Client, int>();
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

        public void LogUsername(Client client)
        {
            Console.Write("{0} has joined!", username);
        }

        public void LogMessages()
        {

        }

        public void LogLeaveMessage(Client client)
        {
            Console.Write("{0} has left.", username);
        }
    }
}
