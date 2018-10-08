using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading;
using GameClient.TCPClient;

namespace GameClient
{
    public partial class ClientInterface : Form,ITCPDataListener
    {
        private int PlayerID;
        private Thread connection;
        public Queue<string> outgoing;
        public ClientInterface()
        {
            this.PlayerID = 0;
            this.outgoing = new Queue<string>();
            StartConnection("localhost", 6666);
            InitializeComponent();
            Lockbuttons();
        }

        private void StartConnection(string ip, int port)
        {
            connection = new Thread(new ThreadStart(new TCPConnection(ip, port, this, this).Start));
            connection.Start();
        }

        private void ClientInterface_Load(object sender, EventArgs e)
        {
        }

        private void AnswerButton1_Click(object sender, EventArgs e)
        {
            sendMessage(AnswerButton1.Text);
            Lockbuttons();
        }

        private void AnswerButton2_Click(object sender, EventArgs e)
        {
            sendMessage(AnswerButton2.Text);
            Lockbuttons();
        }

        private void AnswerButton3_Click(object sender, EventArgs e)
        {
            sendMessage(AnswerButton3.Text);
            Lockbuttons();
        }

        private void AnswerButton4_Click(object sender, EventArgs e)
        {
            sendMessage(AnswerButton4.Text);
            Lockbuttons();
        }

        private void Lockbuttons()
        {
            AnswerButton1.Enabled = false;
            AnswerButton2.Enabled = false;
            AnswerButton3.Enabled = false;
            AnswerButton4.Enabled = false;
        }

        private void UnlockButtons()
        {
            AnswerButton1.Enabled = true;
            AnswerButton2.Enabled = true;
            AnswerButton3.Enabled = true;
            AnswerButton4.Enabled = true;
        }

        private void sendMessage(String answer)
        {
            if(this.PlayerID != 0)
            {
                string message = JsonConvert.SerializeObject(new
                {
                    source = "player" + PlayerID,
                    command = "player/answer",
                    player = PlayerID,
                    answer = answer
                });
                this.outgoing.Enqueue(message);
                
            }
        }


        public void onQuestionReceived(string question, string answer1, string answer2, string answer3, string answer4)
        {
            QuestionLabel.Text = question;
            AnswerButton1.Text = answer1;
            AnswerButton2.Text = answer2;
            AnswerButton3.Text = answer3;
            AnswerButton4.Text = answer4;
            UnlockButtons();
        }

        public void onPointsReceived(string player, string points)
        {
            
        }

        public void onGameWin(string playerID)
        {
            throw new NotImplementedException();
        }

        public void onPlayerIDReceived(string id)
        {
            this.PlayerID = Convert.ToInt32(id);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
