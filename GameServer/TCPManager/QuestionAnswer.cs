using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.TCPManager
{
    class QuestionAnswer
    {
        public string question;
        public string rightAnswer;
        public string answe2;
        public string answe3;
        public string answer4;

        public QuestionAnswer(string question, string rightAnswer, string answe2, string answe3, string answer4)
        {
            this.question = question;
            this.rightAnswer = rightAnswer;
            this.answe2 = answe2;
            this.answe3 = answe3;
            this.answer4 = answer4;
        }
    }
}
