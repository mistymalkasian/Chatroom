using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Message
    {
        //member variables
        public Client sender;
        public string Body;
        public string UserId;

        //constructor
        public Message(Client Sender, string Body)
        {
            sender = Sender;
            this.Body = Body;
            UserId = sender?.UserId;
        }

        //member methods
    }
}
