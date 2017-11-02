using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Client
    {
        NetworkStream stream;
        public TcpClient client;
        public string username;
        public int IDNumber;

        public Client(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
            username = null;
            IDNumber = 0;
        }
        public void Send(string Message)
        {
           while (true)
            {
                try
                {
                    byte[] message = Encoding.ASCII.GetBytes(Message);
                    stream.Write(message, 0, message.Count());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
               
                     
        }
        public string Receive()
        {
            while (true)    
            {
                try
                {
                    byte[] receivedMessage = new byte[256];
                    stream.Read(receivedMessage, 0, receivedMessage.Length);
                    string receivedMessageString = Encoding.ASCII.GetString(receivedMessage);
                    Console.WriteLine(receivedMessageString);
                    return receivedMessageString;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }           
        }

        public string AskForUsername()
        {
            Send("Welcome to the chatroom! Please enter a username.");
            username = Receive();
            return username;

        }
    }
}
