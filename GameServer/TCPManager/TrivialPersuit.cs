using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GameServer.TCPServer;
using System.IO;

namespace GameServer.TCPManager
{
    class TrivialPersuit
    {
        private int player1points;
        private int player2points;

        private string currentQuestion;
        private string currentAnswer;
        public bool allplayersAnswered;
        private int answerCount;
        private int rightanswercount;
        private TCPDataManager manager;
        private Session session;

        public TrivialPersuit(TCPDataManager manager, Session session)
        {
            player1points = 0;
            player2points = 0;
            allplayersAnswered = false;
            answerCount = 0;
            rightanswercount = 0;
            this.manager = manager;
            this.session = session;
        }

        public string getQuestion()
        {
            String modifier;
            Random randomNumber = new Random();
            string var1 = Convert.ToString(randomNumber.Next(0, 1000));
            string var2 = Convert.ToString(randomNumber.Next(0, 1000));

            int rng = randomNumber.Next(0, 3);
            switch (rng)
            {
                case 0: modifier = "+"; currentAnswer = Convert.ToString(Convert.ToInt32(var1) + Convert.ToInt32(var2)); break;
                case 1: modifier = "-"; currentAnswer = Convert.ToString(Convert.ToInt32(var1) - Convert.ToInt32(var2)); break;
                case 2: modifier = "*"; currentAnswer = Convert.ToString(Convert.ToInt32(var1) * Convert.ToInt32(var2)); break;
                default: modifier = "+"; currentAnswer = Convert.ToString(Convert.ToInt32(var1) + Convert.ToInt32(var2)); break;
            }

            currentQuestion = $"{var1} {modifier} {var2}";
            allplayersAnswered = false;
            answerCount = 0;
            rightanswercount = 0;
            return currentQuestion;
        }

        public String getAnswer()
        {
            return currentAnswer;
        }

        public void CheckAnswer(int player,String answer)
        {
            int points = 2 - rightanswercount;
            
            switch (player)
            {
                case 1:
                    if(answer == currentAnswer)
                    {
                        player1points += points;
                        manager.AddCommandToQueue(1, Commands.PlayerEarnedPoints(1,points));
                        manager.AddCommandToQueue(2, Commands.PlayerEarnedPoints(1, points));
                        session.player1points += points;
                        rightanswercount++;
                        
                    } else
                    {
                        manager.AddCommandToQueue(1, Commands.PlayerEarnedPoints(1, 0));
                    }
                    
                    break;
                case 2:
                    if (answer == currentAnswer)
                    {
                        player2points += points;
                        manager.AddCommandToQueue(1, Commands.PlayerEarnedPoints(2, points));
                        manager.AddCommandToQueue(2, Commands.PlayerEarnedPoints(2, points));
                        session.player2points += points;
                        rightanswercount++;
                    }
                    else
                    {
                        manager.AddCommandToQueue(2, Commands.PlayerEarnedPoints(2, 0));
                    }
                    break;
            }
            if (answerCount == 1)
            {
                answerCount = 0;
                allplayersAnswered = true;
            }
            answerCount++;

        }

        public void decodeAnswer(String e)
        {
            dynamic message = JsonConvert.DeserializeObject(e);

            int player = Convert.ToInt32(message.player);
            String command = message.command;
            String answer = message.answer;

            if(command == "player/answer")
            {
                CheckAnswer(player, answer);
            } else
            {
                Console.WriteLine("Not real command");
            }
        }
    }
}
