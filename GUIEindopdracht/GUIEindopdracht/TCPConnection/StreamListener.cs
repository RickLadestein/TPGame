using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace GUIEindopdracht.TCPConnection
{
    class StreamListener
    {
        private Stream stream;
        private ITCPListener subscriber;
        private StreamReader reader;
        private bool alive;

        public StreamListener(Stream clientstream, ITCPListener sub)
        {
            this.stream = clientstream;
            this.subscriber = sub;
            this.reader = new StreamReader(stream);
            alive = true;
        }

        public void Start()
        {
            while (alive)
            {
                ReadStream();
            }
        }

        public void Stop()
        {
            reader.Close();
            alive = false;
        }

        private void ReadStream()
        {
            try
            {
                string message = reader.ReadLine();
                subscriber.OnDataReceived(message);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Streamreader error: " + ex);
                alive = false;
            }
        }
    }
}
