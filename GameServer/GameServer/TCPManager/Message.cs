using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.TCPManager
{
    class Message
    {
        public int destination;
        public string message;

        public Message(int destination, string message)
        {
            this.destination = destination;
            this.message = message;
        }
    }
}
