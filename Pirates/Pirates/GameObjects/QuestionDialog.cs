using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pirates.GameObjects
{
    public partial class QuestionDialog : Form
    {
        private string[] answers;
        private string quest;
        private bool isOpen;
        public string answer;

        public QuestionDialog(bool isOpen, string question, string[] answers)
        {
            this.isOpen = isOpen;
            this.quest = question;
            this.answers = answers;
            InitializeComponent();
        }



        private void a1_Click(object sender, EventArgs e)
        {
            answer = a1.Text;
            Close();
        }

        private void a2_Click(object sender, EventArgs e)
        {
            answer = isOpen ? openAnswer.Text : a2.Text;
            Close();
        }

        private void a3_Click(object sender, EventArgs e)
        {
            answer = a2.Text;
            Close();
        }

        private void QuestionDialog_Load(object sender, EventArgs e)
        {
            questText.Text = quest;
            openAnswer.Visible = isOpen;
            a1.Visible = !isOpen;
            a3.Visible = !isOpen;
            if (isOpen)
            {
                a2.Text = "Zatwierdź";
            }
            else
            {
                int last = answers.Length - 1;
                int i = WorldInfo.getInfo().r.Next(0, 3);
                a1.Text = answers[i];                
                answers[i] = answers[last];
                answers[last] = a1.Text;
                i = WorldInfo.getInfo().r.Next(0, 2);
                a2.Text = answers[i];
                a3.Text = answers[i == 0 ? 1 : 0];
            }
        }
    }
}
