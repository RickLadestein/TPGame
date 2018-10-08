using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using GameServer.TCPManager;

namespace GameServer.TCPServer
{
    class Session : ITCPDataListener
    {
        private TCPConnection player1;
        private TCPConnection player2;
        private TcpClient connection1;
        private TcpClient connection2;

        private Thread worker1;
        private Thread worker2;

        public int player1points;
        public int player2points;

        private TrivialPersuit game;
        private TCPDataManager manager;
        private bool ongoing;
        private const int Maxpoints = 4;

        public Session(TcpClient c1, TcpClient c2)
        {
            connection1 = c1;
            connection2 = c2;
            player1points = 0;
            player2points = 0;
            manager = new TCPDataManager();
            game = new TrivialPersuit(this.manager, this);
            InitializeSession();
        }

        private void InitializeSession()
        {
            manager.AddCommandToQueue(1, Commands.InitializePlayer(1));
            manager.AddCommandToQueue(2, Commands.InitializePlayer(2));
            player1 = new TCPConnection(1, this.manager, this.connection1,this);
            player2 = new TCPConnection(2, this.manager, this.connection2,this);

            worker1 = new Thread(new ThreadStart(player1.Start));
            worker2 = new Thread(new ThreadStart(player2.Start));

            worker1.Start();
            worker2.Start();
            ongoing = true;
        }

        public void Start()
        {
            gameLoop();
        }

        private void gameLoop()
        {
            manager.AskAllPlayersQuestion(Commands.AskQuestion(game.getQuestion(), game.getAnswer()));
            while (ongoing)
            {
                if (!(player1points >= Maxpoints || player2points >= Maxpoints))
                {

                    if (game.allplayersAnswered)
                    {
                        manager.AskAllPlayersQuestion(Commands.AskQuestion(game.getQuestion(), game.getAnswer()));
                    } else if (!game.allplayersAnswered)
                    {
                        //TODO something when not all players have answered
                    }
                } else
                {
                    ongoing = false;
                    if(player1points >= Maxpoints)
                    {
                        manager.AskAllPlayersQuestion(Commands.PlayerHasWon(1));
                    } else if(player2points >= Maxpoints)
                    {
                        manager.AskAllPlayersQuestion(Commands.PlayerHasWon(2));
                    }
                }
            }
        }
        public void OnDataReceived(string e)
        {
            //Console.WriteLine("Received: " + e);
            game.decodeAnswer(e);
            
        }
    }
}
