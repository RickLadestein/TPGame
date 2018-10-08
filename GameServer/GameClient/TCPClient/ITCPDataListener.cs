using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.TCPClient
{
    interface ITCPDataListener
    {
        void onQuestionReceived(String question, String answer1, String answer2, String answer3, String answer4);
        void onPointsReceived(String player, String points);
        void onGameWin(String playerID);
        void onPlayerIDReceived(String id);
    }
}
