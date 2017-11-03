using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        public bool isOn;

        public Client(string IP, int port)
        {
            clientSocket = new TcpClient();
            try
            {
                clientSocket.Connect(IPAddress.Parse(IP), port);
                stream = clientSocket.GetStream();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            isOn = true;
            Parallel.Invoke(Send);
            Parallel.Invoke(Receive);
            AskForUsername();
        }

        public void Send()
        {
            try
            {
                while (isOn == true)
                {
                    string messageString = UI.GetInput();
                    byte[] message = Encoding.ASCII.GetBytes(messageString);
                    stream.Write(message, 0, message.Count());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }        
        }

        public void Receive()
        {
            try
            {
                while (isOn == true)
                {
                    byte[] receivedMessage = new byte[256];
                    stream.Read(receivedMessage, 0, receivedMessage.Length);
                    UI.DisplayMessage(Encoding.ASCII.GetString(receivedMessage));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public string AskForUsername()
        {
            Console.WriteLine("Welcome to the chatroom! Please enter a username.");
            var username = Console.ReadLine();
            return username;
        }
    }
}
