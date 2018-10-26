using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace GUIEindopdracht.TCPConnection
{
    class Connection : ITCPListener
    {
        private TcpClient connection;
        private StreamWriter writer;

        private Trivial_Pursuit parent;
        private string ip;
        private int port;

        private Thread worker;
        private StreamListener streamlistener;

        private bool alive;
        public int playerID;


        public Connection(Trivial_Pursuit parent, string ip, int port)
        {
            this.parent = parent;
            this.ip = ip;
            this.port = port;
            ConnectToServer();
            StartStreamListener();
        }

        #region connection
        public void SendAnswer(string answer, int playerID)
        {
            if (alive)
            {
                writer.WriteLine(JsonConvert.SerializeObject(new
                {
                    command = "player/answer",
                    answer = answer,
                    player = playerID
                }));
                writer.Flush();
            }
        }


        public void SendCommand(string command)
        {
            if (alive)
            {
                writer.WriteLine(JsonConvert.SerializeObject(new
                {
                    command = command
                }));
                writer.Flush();
            }
        }

        public void SendDisconnect(int player)
        {
            if(alive)
            {
                writer.WriteLine(JsonConvert.SerializeObject(new
                {
                    command = "player/disconnect",
                    player = player
                }));
                writer.Flush();
            }
        }

        public void CloseConnection()
        {
            try
            {
                SendDisconnect(parent.playerID);
                Thread.Sleep(1000);
                this.alive = false;
                streamlistener.Stop();
                writer.Flush();
                writer.Close();
                connection.GetStream().Close();
                connection.Close();
            } catch(Exception ex)
            {
                Console.WriteLine("closing error: " + ex);
            }
        }

        private void ConnectToServer()
        {
            try
            {
                connection = new TcpClient(ip, port);
                this.writer = new StreamWriter(connection.GetStream());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not connect to server: " + ex);
                Console.WriteLine("ENTER KEY TO EXIT");
                Console.ReadKey();
                Environment.Exit(-1);
            }
        }

        private void StartStreamListener()
        {
            streamlistener = new StreamListener(connection.GetStream(), this);
            worker = new Thread(new ThreadStart(streamlistener.Start));
            worker.Start();
            alive = true;
        }
        #endregion

        private void ParseData(string data)
        {
            //TODO HandleData
            dynamic message = JsonConvert.DeserializeObject(data);
            string id;
            int player;
            string origin = message.origin;
            string command = message.command;

            if(origin == "host")
            {
                switch (command)
                {
                    case "player/id":
                        id = message.playerid;
                        this.playerID = int.Parse(id);
                        parent.playerID = this.playerID;
                        Console.WriteLine($"PlayerID is now {this.playerID}");
                        break;
                    case "game/question":
                        string question = message.question;
                        string answer1 = message.answer1;
                        string answer2 = message.answer2;
                        string answer3 = message.answer3;
                        string answer4 = message.answer4;
                        parent.ShowQuestionAnswer(question, answer1, answer2, answer3, answer4);
                        break;
                    case "player/addpoints":
                        string player1 = message.player;
                        player = int.Parse(player1);
                        string points = message.points;
                        int points1 = int.Parse(points);
                        parent.AddPoints(player, points1);
                        break;
                    case "player/win":
                        string player2 = message.player;
                        player = int.Parse(player2);
                        parent.PlayerWins(player);
                        break;
                }
            }
            //{"origin":"host","command":"game/question","question":"Waar mag je dronken achter het stuur zitten?","answer1":"Indonesië","answer2":"Vietnam","answer3":"Noord korea","answer4":"Nederland"}

        }

        public void OnDataReceived(string data)
        {
            Console.WriteLine(data);
            ParseData(data);

        }
    }
}
