using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUIEindopdracht.TCPConnection;

namespace GUIEindopdracht
{
    public partial class Trivial_Pursuit : Form
    {
        public int playerID;

        private Connection conn;

        public Trivial_Pursuit()
        {
            InitializeComponent();
            conn = new Connection(this, "localhost", 6666);
        }

        public void SetPlayerID(int id)
        {
            Invoke(new Action(() => { playerID = id; }));
            Invoke(new Action(() => { this.Text = $"Trivial_Pursuit Player:{id}"; }));
        }

        public void ShowQuestionAnswer(string question, string answer1, string answer2, string answer3, string answer4)
        {
            Invoke(new Action(() => { questionTextbox.Text = question; }));
            Invoke(new Action(() => { AnswerButton1.Text = answer1; }));
            Invoke(new Action(() => { AnswerButton2.Text = answer2; }));
            Invoke(new Action(() => { AnswerButton3.Text = answer3; }));
            Invoke(new Action(() => { AnswerButton4.Text = answer4; }));
            Invoke(new Action(() => { UnlockAllButtons(); }));
        }

        public void AddPoints(int player, int points)
        {
            switch (player)
            {
                case 1:
                    Invoke(new Action(() => { Player1Textbox.Text = Convert.ToString(Convert.ToInt32(Player1Textbox.Text) + points); }));
                    break;
                case 2:
                    Invoke(new Action(() => { Player2Textbox.Text = Convert.ToString(Convert.ToInt32(Player2Textbox.Text) + points); }));
                    break;
            }
        }

        public void PlayerWins(int id)
        {
            if(id == playerID)
            {
                Invoke(new Action(() => { MessageBox.Show("Hooray you win, retard", $"Player {id} wins"); })); ;
            } else
            {
                Invoke(new Action(() => { MessageBox.Show("Oh noooo u lost, loser", $"Player {id} wins"); }));
            }
        }

        public void GiveAnswer(string answer)
        {
            conn.SendAnswer(answer, playerID);
        }

        public void LockAllButtons()
        {
            AnswerButton1.Enabled = false;
            AnswerButton2.Enabled = false;
            AnswerButton3.Enabled = false;
            AnswerButton4.Enabled = false;
        }

        public void UnlockAllButtons()
        {
            AnswerButton1.Enabled = true;
            AnswerButton2.Enabled = true;
            AnswerButton3.Enabled = true;
            AnswerButton4.Enabled = true;
        }

        private void Trivial_Pursuit_Load(object sender, EventArgs e)
        {

        }

        private void AnswerButton1_Click(object sender, EventArgs e)
        {
            LockAllButtons();
            GiveAnswer(AnswerButton1.Text);
        }

        private void AnswerButton2_Click(object sender, EventArgs e)
        {
            LockAllButtons();
            GiveAnswer(AnswerButton2.Text);
        }

        private void AnswerButton3_Click(object sender, EventArgs e)
        {
            LockAllButtons();
            GiveAnswer(AnswerButton3.Text);
        }

        private void AnswerButton4_Click(object sender, EventArgs e)
        {
            LockAllButtons();
            GiveAnswer(AnswerButton4.Text);
        }

        private void Trivial_Pursuit_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.CloseConnection();
        }
    }
}
