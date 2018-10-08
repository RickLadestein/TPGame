using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.TCPServer
{
    interface ITCPDataListener
    {
        void OnDataReceived(String e);
    }
}
