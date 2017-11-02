using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public interface ILogger
    {
        void LogUsername(Client client);

        void LogMessages();

        void LogLeaveMessage(Client client);

    }
}
