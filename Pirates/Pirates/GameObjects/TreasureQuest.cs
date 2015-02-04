using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Pirates.GameObjects
{
    abstract class Question
    {
        public String quest { set; get; }
        public abstract bool isAnswerCorrect(String answer);                
    }

    class CloseQuestion : Question
    {
        public String firstAnswer;
        public String secondAnswer;
        public String correctAnswer;

        public CloseQuestion(string quest, string firstAnswer, string secondAnswer, string correctAnswer) {
            this.correctAnswer = correctAnswer;
            this.firstAnswer = firstAnswer;
            this.secondAnswer = secondAnswer;
            this.quest = quest;
        }

        public override bool isAnswerCorrect(string answer)
        {
            return correctAnswer.Equals(answer);
        }

    }

    class OpenQuestion : Question
    {        
        public String correctAnswer;

        public OpenQuestion(string quest, string correctAnswer)
        {
            this.correctAnswer = correctAnswer;            
            this.quest = quest;
        }

        public override bool isAnswerCorrect(string answer)
        {
            if (answer.Length == 0)
            {
                answer = "";
            }
            return correctAnswer.ToLower().Equals(answer.ToLower());
        }

    }

    class TreasureQuest
    {
        public int gold;
        public int food;

        public static TreasureQuest getTreasureQuest()
        {
            int questProbability = WorldInfo.getInfo().r.Next(0, 250);
            if (questProbability < 40)
            {
                return new NoTreasureQuest();
            }
            /*else if (questProbability < 70)
            {
                return new HistoricTreasureQuest();
            }
            else if (questProbability < 80)
            {
                return new ShipTreasureQuest();
            }*/
            else if (questProbability < 90)
            {
                return new LogicalTreasureQuest();
            }
            /*else if (questProbability < 95)
            {
                return new GeographyTreasureQuest();
            }*/
            else
            {
                return new OrbisonTreasureQuest();
            }
        }
    }

    class NoTreasureQuest : TreasureQuest
    {
        public NoTreasureQuest()
        {
            
        }
    }
}
