using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameServer.TCPManager
{
    class jsonData
    {
        private string question { get; set; }
        private string ranswer { get; set; }
        private string answer2 { get; set; }
        private string answer3 { get; set; }
        private string answer4 { get; set; }
        private string json;
        private List<JObject> _data = new List<JObject>();


        private void setJsonQuestions()
        {
            AddQuestionAnswer("waar staat het grootste reuzenrad ter wereld?", "singapore", "london", "dubai", "parijs");
            AddQuestionAnswer("Wat wordt bedoeld met horripilatie of spasmodermie?", "kippenvel", "Angst voor Ti'ers", "Spasme", "Wiskunde");
            AddQuestionAnswer("Hoeveel seconden zijn er in 5 minuten?", "300", "301", "302", "5");
            AddQuestionAnswer("Hoeveel maanden hebben 30 dagen in een jaar?", "4", "5", "6", "3");
            AddQuestionAnswer("Hoe heet de toren die scheef staat?", "De toren van Pisa", "Er is geen toren die scheef staat", "De toren van Pita", "De toren van Kees");
            AddQuestionAnswer("Waar mag je dronken achter het stuur zitten?", "Indonesië", "Vietnam", "Noord korea", "Nederland");
            AddQuestionAnswer("Uit welke jaar komt de oudste condoom?", "1640", "1869", "1754", "1744");
            AddQuestionAnswer("Hoelang doet een slak erover om een rondje om de wereld te kruipen?", "4575 jaar", "3698 jaar", "4265 jaar", "3988 jaar");
        }

        private void AddQuestionAnswer(string question, string rightanswer, string answer2, string answer3, string answer4)
        {
            JObject quan = new JObject();
            quan.Add("question", question);
            quan.Add("ranswer",rightanswer);
            quan.Add("answer2", answer2);
            quan.Add("answer3", answer3);
            quan.Add("answer4", answer4);
            _data.Add(quan);
        }

        public void WritequestionsToFile()
        {
            setJsonQuestions();
            json = JsonConvert.SerializeObject(_data.ToArray());
            File.WriteAllText(@"D:\jsonFile.json", json);
        }

        public void ReadquestionfromFile(TrivialPersuit game)
        {
            string lines = "";
            StreamReader reader = new StreamReader(@"D:\jsonFile.json");
            try
            {
                do
                {
                    lines += reader.ReadLine();
                }
                while (reader.Peek() != -1);
            }

            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            finally
            {
                reader.Close();
                ReadquestionsFromString(game, lines);
            }
        }

        private void ReadquestionsFromString(TrivialPersuit game, string jsonstring)
        {

            game.questions.Clear();
           dynamic jsonData = JsonConvert.DeserializeObject(jsonstring);
            JArray data = jsonData._data;
            for(int i = 0; i < data.Count; i++)
            {
                dynamic dataInArray = data[i];
                string question = dataInArray.question;
                string ranswer = dataInArray.ranswer;
                string answer2 = dataInArray.answer2;
                string answer3 = dataInArray.answer3;
                string answer4 = dataInArray.answer4;

                game.questions.Add(new QuestionAnswer(question, ranswer, answer2, answer3, answer4));
            }

            
            
        }
    } 
}
