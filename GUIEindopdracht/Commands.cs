using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GUIEindopdracht
{
    class Commands
    {

        /*public static string setPlayerID()
        {
            dynamic message = new
            {
                origin = "host",
                command = "player/id",
                id = ""
            };
            return message;
        }

        public static string getQuestion()
        {
            dynamic message = new
            {
                origin = "",
                command = "player/addpoints",
                player = "",
                points = ""
            };
            return message;
        }

        public static string getQuestionFromServer()
        {
            dynamic message = new
            {
                origin = "host",
                command = "player/win",
                player = "",
            };
            return message;
        }*/

        public static string AnswerQuestionFromServer(string answer, int playerID)
        {
            string message = JsonConvert.SerializeObject(new
            {
                origin = "client",
                command = "player/answer",
                player = playerID,
                answer = answer
            });
            return message;
        }
    }
}
