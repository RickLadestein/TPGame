using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using GameServer.TCPManager;
using Newtonsoft.Json;

namespace GameServer.TCPServer
{
    class Session : ITCPDataListener
    {
        private TCPConnection player1;
        private TCPConnection player2;
        private TcpClient connection1;
        private TcpClient connection2;

        public int player1points;
        public int player2points;

        private TrivialPersuit game;
        private bool ongoing;
        private const int Maxpoints = 4;
        private Server server;
        private int id;

        private int connectedPlayers = 2;

        public Session(TcpClient c1, TcpClient c2, Server server, int id)
        {
            this.id = id;
            this.server = server;
            connection1 = c1;
            connection2 = c2;
            player1points = 0;
            player2points = 0;
            InitializeSession();
            game = new TrivialPersuit(this);
            
        }

        private void InitializeSession()
        {
            player1 = new TCPConnection(1, this.connection1, this);
            player2 = new TCPConnection(2, this.connection2, this);

            SendPlayerData(1, Commands.InitializePlayer(1));
            SendPlayerData(2, Commands.InitializePlayer(2));
            
            

            ongoing = true;
        }

        public void Start()
        {
            gameLoop();
            Stop();
            Console.WriteLine("Stopping this session");
        }

        public void Stop()
        {
            Thread.Sleep(2000);
            server.StopSession(player1, player2,this, id);

        }

        public void SendAllPlayersData(string data)
        {
            player1.SendData(data);
            player2.SendData(data);
        }

        public void SendPlayerData(int player, string data)
        {
            Console.WriteLine("sent: " + data);
            if(player == 1)
            {
                player1.SendData(data);
            } else if(player == 2)
            {
                player2.SendData(data);
            } else
            {
                Console.WriteLine($"Player {player} does not exist");
            }
        }

        private void gameLoop()
        {
            SendAllPlayersData(Commands.AskQuestion(game.getQuestion(), game.getAnswer(), game.answer2, game.answer3, game.answer4));
            while (ongoing)
            {
                if (!(player1points >= Maxpoints || player2points >= Maxpoints))
                {

                    if (game.allplayersAnswered)
                    {
                        SendAllPlayersData(Commands.AskQuestion(game.getQuestion(), game.getAnswer(), game.answer2, game.answer3, game.answer4));
                    } else if (!game.allplayersAnswered)
                    {
                        //TODO something when not all players have answered
                    }
                } else
                {
                    ongoing = false;
                    if(player1points >= Maxpoints)
                    {
                        SendAllPlayersData(Commands.PlayerHasWon(1));
                    } else if(player2points >= Maxpoints)
                    {
                        SendAllPlayersData(Commands.PlayerHasWon(2));
                    }
                }
            }
        }

        private void OnplayerDisconnect()
        {
            connectedPlayers -= 1;
            if (connectedPlayers == 0)
                this.ongoing = false;
        }

        public void OnDataReceived(string e)
        {
            Console.WriteLine("Received: " + e);
            dynamic message = JsonConvert.DeserializeObject(e);
            if (message.command == "player/disconnect" || e == "")
            {
                int player = message.player;
                if (player == 1)
                {
                    player1.CloseConnection();
                    OnplayerDisconnect();
                }
                else if (player == 2)
                {
                    player2.CloseConnection();
                    OnplayerDisconnect();
                }
                else
                {
                    player1.CloseConnection();
                    player2.CloseConnection();
                    OnplayerDisconnect();
                    OnplayerDisconnect();
                }
            }
            else
            {
                game.decodeAnswer(e);
            }
            
        }
    }
}
