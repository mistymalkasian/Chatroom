using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ILoggable : ILogger
    {

        private object messageLock = new object();


        public void LogUsername(Client client, Queue<Message> chats)
        {
            lock(messageLock)
            {
                Message joinMessage = new Message(client, client.username + " has joined the chat!");
                chats.Enqueue(joinMessage);
            }          
        }

        public void LogMessages(Client client, Queue<Message> chats, Message chatMessage)
        {
            lock(messageLock)
            {
                chats.Enqueue(chatMessage);
            }           
        }

        public void LogLeaveMessage(Client client, Queue<Message> chats)
        {
            lock(messageLock)
            {
                Message leaveMessage = new Message(client, client.username + " has left the chat.");
                chats.Enqueue(leaveMessage);
            }         
        }
    }
}
