namespace Pirates.GameObjects
{
    partial class QuestionDialog
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
            this.questText = new System.Windows.Forms.Label();
            this.a1 = new System.Windows.Forms.Button();
            this.a2 = new System.Windows.Forms.Button();
            this.a3 = new System.Windows.Forms.Button();
            this.openAnswer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // questText
            // 
            this.questText.AutoSize = true;
            this.questText.Location = new System.Drawing.Point(13, 13);
            this.questText.Name = "questText";
            this.questText.Size = new System.Drawing.Size(35, 13);
            this.questText.TabIndex = 0;
            this.questText.Text = "label1";
            // 
            // a1
            // 
            this.a1.Location = new System.Drawing.Point(12, 190);
            this.a1.Name = "a1";
            this.a1.Size = new System.Drawing.Size(75, 23);
            this.a1.TabIndex = 1;
            this.a1.Text = "button1";
            this.a1.UseVisualStyleBackColor = true;
            this.a1.Click += new System.EventHandler(this.a1_Click);
            // 
            // a2
            // 
            this.a2.Location = new System.Drawing.Point(93, 190);
            this.a2.Name = "a2";
            this.a2.Size = new System.Drawing.Size(75, 23);
            this.a2.TabIndex = 2;
            this.a2.Text = "button2";
            this.a2.UseVisualStyleBackColor = true;
            this.a2.Click += new System.EventHandler(this.a2_Click);
            // 
            // a3
            // 
            this.a3.Location = new System.Drawing.Point(174, 190);
            this.a3.Name = "a3";
            this.a3.Size = new System.Drawing.Size(75, 23);
            this.a3.TabIndex = 3;
            this.a3.Text = "button3";
            this.a3.UseVisualStyleBackColor = true;
            this.a3.Click += new System.EventHandler(this.a3_Click);
            // 
            // openAnswer
            // 
            this.openAnswer.Location = new System.Drawing.Point(16, 164);
            this.openAnswer.Name = "openAnswer";
            this.openAnswer.Size = new System.Drawing.Size(233, 20);
            this.openAnswer.TabIndex = 4;
            // 
            // QuestionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 225);
            this.Controls.Add(this.openAnswer);
            this.Controls.Add(this.a3);
            this.Controls.Add(this.a2);
            this.Controls.Add(this.a1);
            this.Controls.Add(this.questText);
            this.Name = "QuestionDialog";
            this.Text = "QuestionDialog";
            this.Load += new System.EventHandler(this.QuestionDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questText;
        private System.Windows.Forms.Button a1;
        private System.Windows.Forms.Button a2;
        private System.Windows.Forms.Button a3;
        private System.Windows.Forms.TextBox openAnswer;
    }
}