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
        private TcpClient client;
        private ITCPDataListener listener;
        private StreamWriter writer;

        private TCPReceiver receiver;
        private Thread worker;
        private bool alive;

        public TCPConnection(int playerID, TcpClient client, ITCPDataListener listener)
        {
            this.playerID = playerID;
            this.client = client;
            this.listener = listener;
            this.writer = new StreamWriter(client.GetStream());
            this.alive = true;
            StartStreamworker();
        }

        public void SendData(string message)
        {
            if (alive)
            {
                try
                {
                    writer.WriteLine(message);
                    writer.Flush();
                } catch(Exception ex)
                {
                    Console.WriteLine("Could not send data: " + ex);
                    this.alive = false;
                }
            }
        }

        private void StartStreamworker()
        {
            receiver = new TCPReceiver(this.client, this.listener);
            worker = new Thread(new ThreadStart(receiver.Start));
            worker.Start();
        }

        public void CloseConnection()
        {
            try
            {
                alive = false;
                receiver.Stop();
                writer.Flush();
                writer.Close();
                client.Close();
            } catch(Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex);
            }
        }

       
    }
}
