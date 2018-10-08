namespace GameClient
{
    partial class ClientInterface
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Player1Points = new System.Windows.Forms.Label();
            this.Player2Points = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.AnswerButton1 = new System.Windows.Forms.Button();
            this.AnswerButton4 = new System.Windows.Forms.Button();
            this.AnswerButton3 = new System.Windows.Forms.Button();
            this.AnswerButton2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.Player1Points);
            this.panel1.Controls.Add(this.Player2Points);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.QuestionLabel);
            this.panel1.Controls.Add(this.AnswerButton1);
            this.panel1.Controls.Add(this.AnswerButton4);
            this.panel1.Controls.Add(this.AnswerButton3);
            this.panel1.Controls.Add(this.AnswerButton2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 540);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Player1Points
            // 
            this.Player1Points.Font = new System.Drawing.Font("Power Clear", 14.25743F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Points.Location = new System.Drawing.Point(20, 40);
            this.Player1Points.Name = "Player1Points";
            this.Player1Points.Size = new System.Drawing.Size(89, 26);
            this.Player1Points.TabIndex = 11;
            this.Player1Points.Text = "0 Pts";
            this.Player1Points.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player2Points
            // 
            this.Player2Points.Font = new System.Drawing.Font("Power Clear", 14.25743F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Points.Location = new System.Drawing.Point(325, 40);
            this.Player2Points.Name = "Player2Points";
            this.Player2Points.Size = new System.Drawing.Size(89, 26);
            this.Player2Points.TabIndex = 10;
            this.Player2Points.Text = "0 Pts";
            this.Player2Points.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Power Clear", 14.25743F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(325, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 27);
            this.label3.TabIndex = 9;
            this.label3.Text = "Player 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Power Clear", 14.25743F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "Player 1";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.QuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.82178F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionLabel.Location = new System.Drawing.Point(20, 107);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.QuestionLabel.Size = new System.Drawing.Size(400, 53);
            this.QuestionLabel.TabIndex = 7;
            this.QuestionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AnswerButton1
            // 
            this.AnswerButton1.Font = new System.Drawing.Font("Power Clear", 14.25743F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerButton1.Location = new System.Drawing.Point(15, 260);
            this.AnswerButton1.Name = "AnswerButton1";
            this.AnswerButton1.Size = new System.Drawing.Size(400, 50);
            this.AnswerButton1.TabIndex = 6;
            this.AnswerButton1.Text = "Answer 1";
            this.AnswerButton1.UseVisualStyleBackColor = true;
            this.AnswerButton1.Click += new System.EventHandler(this.AnswerButton1_Click);
            // 
            // AnswerButton4
            // 
            this.AnswerButton4.Font = new System.Drawing.Font("Power Clear", 14.25743F);
            this.AnswerButton4.Location = new System.Drawing.Point(15, 470);
            this.AnswerButton4.Name = "AnswerButton4";
            this.AnswerButton4.Size = new System.Drawing.Size(400, 50);
            this.AnswerButton4.TabIndex = 5;
            this.AnswerButton4.Text = "Answer4";
            this.AnswerButton4.UseVisualStyleBackColor = true;
            this.AnswerButton4.Click += new System.EventHandler(this.AnswerButton4_Click);
            // 
            // AnswerButton3
            // 
            this.AnswerButton3.Font = new System.Drawing.Font("Power Clear", 14.25743F);
            this.AnswerButton3.Location = new System.Drawing.Point(15, 400);
            this.AnswerButton3.Name = "AnswerButton3";
            this.AnswerButton3.Size = new System.Drawing.Size(400, 50);
            this.AnswerButton3.TabIndex = 4;
            this.AnswerButton3.Text = "Answer 3";
            this.AnswerButton3.UseVisualStyleBackColor = true;
            this.AnswerButton3.Click += new System.EventHandler(this.AnswerButton3_Click);
            // 
            // AnswerButton2
            // 
            this.AnswerButton2.Font = new System.Drawing.Font("Power Clear", 14.25743F);
            this.AnswerButton2.Location = new System.Drawing.Point(15, 330);
            this.AnswerButton2.Name = "AnswerButton2";
            this.AnswerButton2.Size = new System.Drawing.Size(400, 50);
            this.AnswerButton2.TabIndex = 3;
            this.AnswerButton2.Text = "Answer 2";
            this.AnswerButton2.UseVisualStyleBackColor = true;
            this.AnswerButton2.Click += new System.EventHandler(this.AnswerButton2_Click);
            // 
            // ClientInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 565);
            this.Controls.Add(this.panel1);
            this.Name = "ClientInterface";
            this.Text = "ClientInterface";
            this.Load += new System.EventHandler(this.ClientInterface_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AnswerButton1;
        private System.Windows.Forms.Button AnswerButton4;
        private System.Windows.Forms.Button AnswerButton3;
        private System.Windows.Forms.Button AnswerButton2;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Player1Points;
        private System.Windows.Forms.Label Player2Points;


    }
}