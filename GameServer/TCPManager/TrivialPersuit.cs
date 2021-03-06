﻿using System;
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
        public List<QuestionAnswer> questions = new List<QuestionAnswer>();
        private int player1points;
        private int player2points;

        private string currentQuestion;
        private string currentAnswer;
        public bool allplayersAnswered;
        private int answerCount;
        private int rightanswercount;
        private Session session;

        Random randomNumber = new Random(DateTime.Now.Second);

        public string answer2 = "", answer3 = "", answer4 = "";

        private jsonData json= new jsonData();

        public TrivialPersuit(Session session)
        {
            json.WritequestionsToFile();
            json.ReadquestionfromFile(this);
            Console.WriteLine(questions);
            player1points = 0;
            player2points = 0;
            allplayersAnswered = false;
            answerCount = 0;
            rightanswercount = 0;
            this.session = session;
        }

        public string getQuestion()
        {
            String modifier;
            string var1 = Convert.ToString(randomNumber.Next(0, 1000));
            string var2 = Convert.ToString(randomNumber.Next(0, 1000));

            int rng = randomNumber.Next(0, questions.Count);
            QuestionAnswer question = questions[rng];

            currentQuestion = $"{question.question}";
            currentAnswer = $"{question.rightAnswer}";
            allplayersAnswered = false;
            answerCount = 0;
            rightanswercount = 0;
            answer2 = question.answe2;
            answer3 = question.answe3;
            answer4 = question.answer4;
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
                        session.SendPlayerData(1, Commands.PlayerEarnedPoints(1,points));
                        session.SendPlayerData(2, Commands.PlayerEarnedPoints(1, points));
                        session.player1points += points;
                        rightanswercount++;
                        
                    } else
                    {
                        session.SendPlayerData(1, Commands.PlayerEarnedPoints(1, 0));
                    }
                    
                    break;
                case 2:
                    if (answer == currentAnswer)
                    {
                        player2points += points;
                        session.SendPlayerData(1, Commands.PlayerEarnedPoints(2, points));
                        session.SendPlayerData(2, Commands.PlayerEarnedPoints(2, points));
                        session.player2points += points;
                        rightanswercount++;
                    }
                    else
                    {
                        session.SendPlayerData(2, Commands.PlayerEarnedPoints(2, 0));
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
            dynamic message;
            message = JsonConvert.DeserializeObject(e);
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
