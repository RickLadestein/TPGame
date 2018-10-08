using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.TCPServer;

namespace GameServer.TCPManager
{
    class TCPDataManager
    {
        private List<TCPConnection> connections;
        public Queue<Message> outgoingPlayer1;
        public Queue<Message> outgoingPlayer2;
        private Queue<string> incomming;

        public TCPDataManager()
        {
            connections = new List<TCPConnection>();
            outgoingPlayer1 = new Queue<Message>();
            outgoingPlayer2 = new Queue<Message>();
            incomming = new Queue<string>();
        }

        public void AskAllPlayersQuestion(String q)
        {
            outgoingPlayer1.Enqueue(new Message(1, q));
            outgoingPlayer2.Enqueue(new Message(2, q));
        }

        public void AddCommandToQueue(int player,string e)
        {
            if(player == 1)
            {
                outgoingPlayer1.Enqueue(new Message(player, e));
            } else
            {
                outgoingPlayer2.Enqueue(new Message(player, e));
            }
            
        }
    }
}
