using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pirates.GameObjects
{
    class LogicalTreasureQuest : TreasureQuest
    {
        List<Question> questions;

        public LogicalTreasureQuest() {
            gold = WorldInfo.getInfo().r.Next(20, 90);
            food = WorldInfo.getInfo().r.Next(300, 900);
            createQuestions();
            run();
        }

        public void run()
        {
            int q = WorldInfo.getInfo().r.Next(0, questions.Count);
            int i = 0;
            foreach (Question qe in questions)
            {
                if (i == q)
                {
                    askQuestion(qe);
                    break;
                }
            }
        }

        private void askQuestion(Question qe)
        {
            bool isOpen = qe is OpenQuestion;
            QuestionDialog q = new QuestionDialog(isOpen, qe.quest, isOpen ? null : new string[] {((CloseQuestion) qe).firstAnswer, ((CloseQuestion) qe).secondAnswer, ((CloseQuestion) qe).correctAnswer});
            q.ShowDialog();
            if (qe.isAnswerCorrect(q.answer))
            {
                MessageBox.Show("Znalazłeś i zdobyłeś " + gold + " szutk złota i " + food + " jednostek jedzenia", "", MessageBoxButtons.OK);
                Players.PlayersInfo.info.food += food;
                Players.PlayersInfo.info.money += gold;
            }
            else
            {
                MessageBox.Show("Znalazłeś, ale nie zdobyłeś " + gold + " szutk złota i " + food + " jednostek jedzenia", "", MessageBoxButtons.OK);
            }
        }

        void createQuestions()
        {
            questions = new List<Question>();
            questions.Add(new CloseQuestion("Pewien stary pasterz chciał rozdzielić część swojego stada owiec pomiędzy trzech synów. Powiedział im tak: \n- Najstarszy dostanie trzecią część, średni czwartą, a najmłodszy piątą. Jest tylko jeden warunek: musicie się podzielić sprawiedliwie i dokładnie tak jak powiedziałem, albo nici ze spadku! \nPo chwili przyprowadził dzieciom 47 owieczek(w stadzie nie było baranów) i odszedł. \nNo i powstał problem, ponieważ 47 nie jest podzielne przez 3, ani przez 4, ani przez 5. \nIle powinien dostać najmłodszy z synów, aby zatrzymać ojcowiznę?", "20", "11", "12"));
            questions.Add(new CloseQuestion("Pewien stary pasterz chciał rozdzielić część swojego stada owiec pomiędzy trzech synów. Powiedział im tak: \n- Najstarszy dostanie trzecią część, średni czwartą, a najmłodszy piątą. Jest tylko jeden warunek: musicie się podzielić sprawiedliwie i dokładnie tak jak powiedziałem, albo nici ze spadku! \nPo chwili przyprowadził dzieciom 47 owieczek(w stadzie nie było baranów) i odszedł. \nNo i powstał problem, ponieważ 47 nie jest podzielne przez 3, ani przez 4, ani przez 5. \nIle powinien dostać najstarszy z synów, aby zatrzymać ojcowiznę?", "17", "25", "20"));
            questions.Add(new CloseQuestion("Pewien stary pasterz chciał rozdzielić część swojego stada owiec pomiędzy trzech synów. Powiedział im tak: \n- Najstarszy dostanie trzecią część, średni czwartą, a najmłodszy piątą. Jest tylko jeden warunek: musicie się podzielić sprawiedliwie i dokładnie tak jak powiedziałem, albo nici ze spadku! \nPo chwili przyprowadził dzieciom 47 owieczek(w stadzie nie było baranów) i odszedł. \nNo i powstał problem, ponieważ 47 nie jest podzielne przez 3, ani przez 4, ani przez 5. \nIle powinien dostać najmłodszy z synów, aby zatrzymać ojcowiznę?", "24", "10", "12"));
            questions.Add(new CloseQuestion("Pewien stary pasterz chciał rozdzielić część swojego stada owiec pomiędzy trzech synów. Powiedział im tak: \n- Najstarszy dostanie trzecią część, średni czwartą, a najmłodszy piątą. Jest tylko jeden warunek: musicie się podzielić sprawiedliwie i dokładnie tak jak powiedziałem, albo nici ze spadku! \nPo chwili przyprowadził dzieciom 47 owieczek(w stadzie nie było baranów) i odszedł. \nNo i powstał problem, ponieważ 47 nie jest podzielne przez 3, ani przez 4, ani przez 5. \nIle powinien dostać średni z synów, aby zatrzymać ojcowiznę?", "13", "15", "16"));
            questions.Add(new OpenQuestion("Jeśli po diecezji jest zupa, po zupie ironia, a po ironi śruba a wczoraj był czwartek. ta jaki dzień tygodnia bedzie za 2 dni?", "Niedziela"));
            questions.Add(new CloseQuestion("Dla uczczenia swoich szóstych urodzin Samantha zasadziła drzewo w ogrodzie rodziców.\nCzęsto przyglądała sie, jak tata sadzi rózne rzeczy i zrobila wszystko tak , jak nalezy.\nNie zapomniała nawet podlać drzewa.\nJej mama wpadła jednak w szał. Powiedziała, że drzewo należy do niej i nie miała prawa go sadzić.\nTato tylko się uśmiechnął i wytłumaczył dziewczynce , że to drzewo nigdy nie urośnie. Dlaczego?", "Bo zasadziła do góry nogami", "Bo to sztuczne drzewo", "Bo to drzewo genealogiczne"));
        }
    }
}
