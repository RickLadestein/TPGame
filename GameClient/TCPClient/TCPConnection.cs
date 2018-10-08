using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GameClient.TCPClient
{
    class TCPConnection
    {
        TcpClient client;
        Thread reader;
        ITCPDataListener listener;
        ClientInterface GUI;
        public TCPConnection(String ip, int port, ClientInterface host,ITCPDataListener listener)
        {
            GUI = host;
            this.listener = listener;
            client = new TcpClient(ip, port);
            reader = new Thread(new ThreadStart(new TCPReceiver(client, listener).Start));
            reader.Start();
        }

        public void Start()
        {
            while (true)
            {
                if(GUI.outgoing.Count != 0)
                {
                    SendData(GUI.outgoing.Dequeue());
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
        }

    }
}
