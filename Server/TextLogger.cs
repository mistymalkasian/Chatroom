using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class TextLogger : ILogger
    {
        //member variables
        //private Queue<Message> chats;

        //constructor
        public TextLogger()
        {
            //chats = new Queue<Message>();
        }



        public void LogLeaveMessage()
        {
            throw new NotImplementedException();
        }

        public void LogMessages()
        {
            throw new NotImplementedException();

            //foreach(Message chat in chats)
            //{
            //    Console.WriteLine(chat);
            //}
        }

        public void LogUsername()
        {
            throw new NotImplementedException();
        }
    }
}
