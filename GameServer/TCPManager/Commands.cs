using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GameServer.TCPManager
{
    class Commands
    {
        private static Random number = new Random(200);
        public static string InitializePlayer(int id)
        {
            return JsonConvert.SerializeObject(new
            {
                origin = "host",
                command = "player/id",
                playerid = id
            });
        }

        public static string PlayerEarnedPoints(int p, int pts)
        {
            return JsonConvert.SerializeObject(new
            {
                origin = "host",
                command = "player/addpoints",
                player = p,
                points = pts
            });
        }

        public static string AskQuestion(String q, String ranswer ,String answer2, String answer3, String answer4)
        {
            List<string> answers = new List<string>();
            answers.Add(ranswer);
            answers.Add(answer2);
            answers.Add(answer3);
            answers.Add(answer4);

            for(int i = 0; i < number.Next(0, 100); i++)
            {
                string first;
                string second;
                int num;
                int num2 = number.Next(0, 3);
                if (num2 == 0)
                {
                    first = answers[0];
                    num = number.Next(0, 3);
                    second = answers[number.Next(0, 3)];
                    answers[0] = second;
                    answers[num] = first;
                } else if(num2 == (answers.Count - 1))
                {
                    first = answers[answers.Count - 1];
                    num = number.Next(0, 3);
                    second = answers[number.Next(0, 3)];
                    answers[answers.Count - 1] = second;
                    answers[num] = first;
                } else
                {
                    first = answers[num2];
                    num = number.Next(0, 3);
                    second = answers[num];
                    answers[num2] = second;
                    answers[num] = first;
                }
            }



            return JsonConvert.SerializeObject(new
            {
                origin = "host",
                command = "game/question",
                question = q,
                answer1 = answers[0],
                answer2 = answers[1],
                answer3 = answers[2],
                answer4 = answers[3]
            });
        }

        public static string PlayerHasWon(int p)
        {
            return JsonConvert.SerializeObject(new
            {
                origin = "host",
                command = "player/win",
                player = p
            });
        }
    }
}
