using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GameServer.TCPServer;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            new Thread(new ThreadStart(new Server().Start)).Start();
            //Console.ReadLine();

        }
    }
}
