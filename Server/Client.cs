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
        //member variables
        NetworkStream stream;
        public TcpClient client;
        //public string UserId;
        public int IDNumber;
        public string username;
        

        //constructor

        public Client(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
            IDNumber = 1;
            username = null;
            //Task.Run(() => Send());
            // UserId = "495933b6-1762-47a1-b655-483510072e73";
         
        }

        //member methods
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


    }
}
