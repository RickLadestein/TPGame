using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace GameClient.TCPClient
{
    class TCPReceiver
    {
        private StreamReader reader;
        private Stream stream;

        private ITCPDataListener listener;

        public TCPReceiver(TcpClient client, ITCPDataListener listener)
        {
            reader = new StreamReader(client.GetStream());
            this.listener = listener;
            stream = client.GetStream();
        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(10);
                ReadStream();
            }
        }

        private void ReadStream()
        {
            byte[] sizeInfo = new byte[4];

            int totalRead = 0, read = 0;
            do
            {
                read = stream.Read(sizeInfo, totalRead, sizeInfo.Length - totalRead);

                totalRead += read;
            } while (totalRead < sizeInfo.Length && read > 0);

            int messageSize = BitConverter.ToInt32(sizeInfo, 0);

            byte[] data = new byte[messageSize];

            totalRead = 0;

            do
            {
                totalRead += read = stream.Read(data, totalRead, data.Length - totalRead);
            } while (totalRead < messageSize && read > 0);
            String message = Encoding.UTF8.GetString(data);
            HandleMessage(message);
        }

        private void HandleMessage(String e)
        {
            dynamic message = JsonConvert.DeserializeObject(e);
            String command = message.command;

            switch (command)
            {
                case "player/addpoints":
                    string player = message.player;
                    string points = message.points;
                    break;
                case "game/askquestion":
                    string question = message.question;
                    string[] answers = message.answers;
                    listener.onQuestionReceived(question, answers[0], answers[1], answers[2], answers[3]);
                    break;
                case "player/id":
                    listener.onPlayerIDReceived(message.playerid);
                    break;
                case "player/win":
                    listener.onPlayerIDReceived(message.playerid);
                    break;
            }
        }
    }
}
