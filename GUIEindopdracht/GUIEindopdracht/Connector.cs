using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;

namespace GUIEindopdracht
{
    public class Connector : IDataListener
    {
        private TcpClient client;
        private NetworkStream stream;
        private Trivial_Pursuit UI;

        public Connector(Trivial_Pursuit ui)
        {
            this.UI = ui;
                client = new TcpClient ("localhost", 6666);
                stream = client.GetStream();
            StartReadingStream(client.GetStream());
        }

        public void SendCommand(string message)
        {
            byte[] length = BitConverter.GetBytes(message.Length);
            byte[] data = Encoding.UTF8.GetBytes(message);
            byte[] msg = new byte[length.Length + data.Length];
            length.CopyTo(msg, 0);
            data.CopyTo(msg, length.Length);
            NetworkStream networkStream = client.GetStream();
            networkStream.Write(msg, 0, msg.Length);
        }

        public void StartReadingStream(Stream clientstream)
        {
            Thread worker = new Thread(() => ReadStream(clientstream,this));
            worker.Start();
        }

        private void ReadStream(Stream clientstream, IDataListener listener)
        {
            while (true)
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
                listener.OnDataReceived(message);
            }
        }

        public void OnDataReceived(string e)
        {
            dynamic message;
            try
            {
                message = JsonConvert.DeserializeObject(e);
            } catch (Exception ex)
            {
                message = JsonConvert.DeserializeObject(e + "}");
            }
            if(message.origin == "host")
            {
                string command = message.command;
                switch (command)
                {
                    case "player/addpoints":
                        int player = Convert.ToInt32(message.player);
                        int points = Convert.ToInt32(message.points);
                        UI.AddPoints(player, points);
                        break;
                    case "player/id":
                        int playerID = Convert.ToInt16(message.playerid);
                        UI.SetPlayerID(playerID);
                        break;
                    case "game/question": 
                        string question = message.question;
                        string answer1 = message.answer1;
                        string answer2 = message.answer2;
                        string answer3 = message.answer3;
                        string answer4 = message.answer4;
                        UI.ShowQuestionAnswer(question, answer1, answer2, answer3, answer4);
                        break;
                    case "player/win":
                        int playerid = Convert.ToInt16(message.player);
                        UI.PlayerWins(playerid);
                        break;
                }
            }
        }
    }
}
