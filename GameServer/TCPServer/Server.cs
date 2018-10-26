using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;


namespace GameServer.TCPServer
{
    class Server
    {
        private TcpListener server;
        private TcpClient player1;
        private TcpClient player2;
        public List<Thread> sessionPool;

        public List<Thread> removeables;

        private int sessionid;

        public Server()
        {
            sessionid = 0;
            server = new TcpListener(IPAddress.Any, 6666);
            sessionPool = new List<Thread>();
            removeables = new List<Thread>();
        }

        public void Start()
        {
            StartRemovingThreadsThread();
            server.Start();
            Console.WriteLine($"Server started on IP:{GetLocalIPAddress()} and Port:{6666}");
            while (true)
            {
                player1 = server.AcceptTcpClient();
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine($"Player 1 found on IP:{player1.Client.RemoteEndPoint}");
                player2 = server.AcceptTcpClient();
                Console.WriteLine($"Player 2 found on IP:{player2.Client.RemoteEndPoint}");
                Console.WriteLine($"Started a session with {player1.Client.RemoteEndPoint} and {player2.Client.RemoteEndPoint}");
                Console.WriteLine("------------------------------------------------------------------------");
                sessionPool.Add(new Thread(new ThreadStart(new Session(player1, player2, this, sessionid).Start)));
                sessionPool[sessionPool.Count - 1].Start();
                sessionid++;
            }
        }

        public void StopSession(TCPConnection p1, TCPConnection p2, Session s, int sessionid)
        {
            p1.CloseConnection();
            p2.CloseConnection();

            Console.WriteLine($"Aborting sessions {sessionid}");
            Thread t = sessionPool[sessionid];
            removeables.Add(t);
            StartRemovingThreadsThread();
        }

        private void StartRemovingThreadsThread()
        {
            new Thread(() => RemoveThreads(this)).Start();
        }

        private void RemoveThreads(Server s)
        {
                foreach (Thread t in removeables)
                {
                    t.Abort();
                    s.sessionPool.Remove(t);
                    Console.WriteLine($"Active sessions {s.sessionPool.Count}");
                }
                s.removeables.Clear();
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
