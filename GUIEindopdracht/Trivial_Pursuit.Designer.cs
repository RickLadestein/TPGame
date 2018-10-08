namespace GUIEindopdracht
{
    partial class Trivial_Pursuit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.Player1Textbox = new System.Windows.Forms.TextBox();
            this.Player2Textbox = new System.Windows.Forms.TextBox();
            this.questionTextbox = new System.Windows.Forms.TextBox();
            this.AnswerButton1 = new System.Windows.Forms.Button();
            this.AnswerButton2 = new System.Windows.Forms.Button();
            this.AnswerButton3 = new System.Windows.Forms.Button();
            this.AnswerButton4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(115, 45);
            this.Player1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(45, 13);
            this.Player1Label.TabIndex = 0;
            this.Player1Label.Text = "Player 1";
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Location = new System.Drawing.Point(316, 45);
            this.Player2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(45, 13);
            this.Player2Label.TabIndex = 1;
            this.Player2Label.Text = "Player 2";
            // 
            // Player1Textbox
            // 
            this.Player1Textbox.Location = new System.Drawing.Point(164, 45);
            this.Player1Textbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Player1Textbox.Name = "Player1Textbox";
            this.Player1Textbox.Size = new System.Drawing.Size(76, 20);
            this.Player1Textbox.TabIndex = 2;
            this.Player1Textbox.Text = "0";
            this.Player1Textbox.TextChanged += new System.EventHandler(this.player1Textbox_TextChanged);
            // 
            // Player2Textbox
            // 
            this.Player2Textbox.Location = new System.Drawing.Point(365, 45);
            this.Player2Textbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Player2Textbox.Name = "Player2Textbox";
            this.Player2Textbox.Size = new System.Drawing.Size(76, 20);
            this.Player2Textbox.TabIndex = 3;
            this.Player2Textbox.Text = "0";
            // 
            // questionTextbox
            // 
            this.questionTextbox.Location = new System.Drawing.Point(100, 88);
            this.questionTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.questionTextbox.Multiline = true;
            this.questionTextbox.Name = "questionTextbox";
            this.questionTextbox.ReadOnly = true;
            this.questionTextbox.Size = new System.Drawing.Size(360, 71);
            this.questionTextbox.TabIndex = 4;
            // 
            // AnswerButton1
            // 
            this.AnswerButton1.Location = new System.Drawing.Point(179, 171);
            this.AnswerButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AnswerButton1.Name = "AnswerButton1";
            this.AnswerButton1.Size = new System.Drawing.Size(196, 29);
            this.AnswerButton1.TabIndex = 5;
            this.AnswerButton1.UseVisualStyleBackColor = true;
            this.AnswerButton1.Click += new System.EventHandler(this.AnswerButton1_Click);
            // 
            // AnswerButton2
            // 
            this.AnswerButton2.Location = new System.Drawing.Point(179, 205);
            this.AnswerButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AnswerButton2.Name = "AnswerButton2";
            this.AnswerButton2.Size = new System.Drawing.Size(196, 29);
            this.AnswerButton2.TabIndex = 6;
            this.AnswerButton2.UseVisualStyleBackColor = true;
            this.AnswerButton2.Click += new System.EventHandler(this.AnswerButton2_Click);
            // 
            // AnswerButton3
            // 
            this.AnswerButton3.Location = new System.Drawing.Point(179, 239);
            this.AnswerButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AnswerButton3.Name = "AnswerButton3";
            this.AnswerButton3.Size = new System.Drawing.Size(196, 29);
            this.AnswerButton3.TabIndex = 7;
            this.AnswerButton3.UseVisualStyleBackColor = true;
            this.AnswerButton3.Click += new System.EventHandler(this.AnswerButton3_Click);
            // 
            // AnswerButton4
            // 
            this.AnswerButton4.Location = new System.Drawing.Point(179, 273);
            this.AnswerButton4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AnswerButton4.Name = "AnswerButton4";
            this.AnswerButton4.Size = new System.Drawing.Size(196, 29);
            this.AnswerButton4.TabIndex = 8;
            this.AnswerButton4.UseVisualStyleBackColor = true;
            this.AnswerButton4.Click += new System.EventHandler(this.AnswerButton4_Click);
            // 
            // Trivial_Pursuit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 366);
            this.Controls.Add(this.AnswerButton4);
            this.Controls.Add(this.AnswerButton3);
            this.Controls.Add(this.AnswerButton2);
            this.Controls.Add(this.AnswerButton1);
            this.Controls.Add(this.questionTextbox);
            this.Controls.Add(this.Player2Textbox);
            this.Controls.Add(this.Player1Textbox);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Trivial_Pursuit";
            this.Text = "Trivial_Pursuit";
            this.Load += new System.EventHandler(this.Trivial_Pursuit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.Label Player2Label;
        private System.Windows.Forms.TextBox Player1Textbox;
        private System.Windows.Forms.TextBox Player2Textbox;
        private System.Windows.Forms.TextBox questionTextbox;
        private System.Windows.Forms.Button AnswerButton1;
        private System.Windows.Forms.Button AnswerButton2;
        private System.Windows.Forms.Button AnswerButton3;
        private System.Windows.Forms.Button AnswerButton4;
    }
}