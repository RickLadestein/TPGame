using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIEindopdracht.TCPConnection
{
    interface ITCPListener
    {
        void OnDataReceived(string data);
    }
}
