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

        public static string AskQuestion(String q, String answer)
        {
            String[] aw = new String[4];
            Random rng = new Random();
            for(int i = 0; i < 4; i++)
            {
                int identifier = rng.Next(0, 1);
                int number = rng.Next(0, 100);
                switch (identifier)
                {
                    case 0:
                        aw[i] = Convert.ToString(Convert.ToInt32(answer) + number);
                        break;

                    case 1:
                        aw[i] = Convert.ToString(Convert.ToInt32(answer) - number);
                        break;
                }
            }
            aw[rng.Next(0, 3)] = answer;

            return JsonConvert.SerializeObject(new
            {
                origin = "host",
                command = "game/question",
                question = q,
                answer1 = aw[0],
                answer2 = aw[1],
                answer3 = aw[2],
                answer4 = aw[3]
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
