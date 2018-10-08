using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Net.Sockets;
using GameServer.TCPManager;
using System.Threading;

namespace GameServer.TCPServer
{
    class TCPConnection
    {
        private int playerID;
        private TCPDataManager manager;
        private TcpClient client;
        private TCPReceiver receiver;
        private ITCPDataListener listener;

        public TCPConnection(int playerID, TCPDataManager manager, TcpClient client, ITCPDataListener listener)
        {
            this.playerID = playerID;
            this.manager = manager;
            this.client = client;
            this.listener = listener;
        }

        public void Start()
        {
            Thread worker = new Thread(new ThreadStart(new TCPReceiver(client,listener).Start));
            worker.Start();
            while (true)
            {
                Thread.Sleep(10);
                if (playerID == 1)
                {
                    if (manager.outgoingPlayer1.Count != 0)
                    {
                        if (((Message)manager.outgoingPlayer1.Peek()).destination == playerID)
                        {
                            string message = manager.outgoingPlayer1.Dequeue().message;
                            SendData(message);
                        }
                    }
                } else if(playerID == 2)
                {
                    if (manager.outgoingPlayer2.Count != 0)
                    {
                        if (((Message)manager.outgoingPlayer2.Peek()).destination == playerID)
                        {
                            string message = manager.outgoingPlayer2.Dequeue().message;
                            SendData(message);
                        }
                    }
                }
            }
        }

        private void SendData(string message)
        {
            byte[] length = BitConverter.GetBytes(message.Length);
            byte[] data = Encoding.UTF8.GetBytes(message);
            byte[] msg = new byte[length.Length + data.Length];
            length.CopyTo(msg, 0);
            data.CopyTo(msg, length.Length);
            NetworkStream networkStream = client.GetStream();
            networkStream.Write(msg, 0, msg.Length);
            Console.WriteLine("sent: " + message);
        }
    }
}
