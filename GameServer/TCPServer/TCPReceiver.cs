using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace GameServer.TCPServer
{
    class TCPReceiver
    {
        private StreamReader reader;
        private Stream stream;

        private bool alive;

        private ITCPDataListener listener;

        public TCPReceiver(TcpClient client, ITCPDataListener listener)
        {
            reader = new StreamReader(client.GetStream());
            stream = client.GetStream();
            this.listener = listener;
            
        }

        public void Start()
        {
            alive = true;
            while (alive)
            {
                ReadStream();
            }
        }

        public void Stop()
        {
            this.alive = false;
            reader.Close();
        }

        private void ReadStream()
        {
            try
            {
                string message = reader.ReadLine();
                listener.OnDataReceived(message);
            } catch (Exception ex)
            { 
                Console.WriteLine("Error reading data: " + ex);
                this.alive = false;
            }
        }
    }
}
