using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameServer.TCPManager
{
    public class jsonData
    {
        private string question { get; set; }
        private string ranswer { get; set; }
        private string answer2 { get; set; }
        private string answer3 { get; set; }
        private string answer4 { get; set; }
        private string json;
        private List<jsonData> _data = new List<jsonData>();


        public void setJsonQuestions()
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
            _data.Add(new jsonData()
            {
                question = question,
                ranswer = rightanswer,
                answer2 = answer2,
                answer3 = answer3,
                answer4 = answer4
            });
        }

        public void WritequestionsToFile()
        {
            json = JsonConvert.SerializeObject(_data.ToArray());
            File.WriteAllText(@"D:\jsonFile.json", json);
        }

        public void ReadquestionsFromFile()
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(json);
            var question = results.question;
            
        }
    } 
}
