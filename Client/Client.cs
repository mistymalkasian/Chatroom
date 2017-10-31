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
        //member variables
        TcpClient clientSocket;
        NetworkStream stream;
        bool isOn;

        //constructor
        public Client(string IP, int port)
        {
            clientSocket = new TcpClient();
            clientSocket.Connect(IPAddress.Parse(IP), port);
            stream = clientSocket.GetStream();

            Task.Run(() => Send());
            Task.Run(() => Recieve());

        }

        //member methods
        public void Send()
        {
            while (isOn == true)
            {
            string messageString = UI.GetInput();
            byte[] message = Encoding.ASCII.GetBytes(messageString);
            stream.Write(message, 0, message.Count());
            }
        }
        public void Recieve()
        {
            while (isOn == true)
            {
            byte[] recievedMessage = new byte[256];
            stream.Read(recievedMessage, 0, recievedMessage.Length);
            UI.DisplayMessage(Encoding.ASCII.GetString(recievedMessage));
            }

        }
    }
}
