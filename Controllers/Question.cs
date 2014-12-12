using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthsOfWinPreFon.Controllers
{
    public delegate void Reaction(string response);

    public class Question
    {
        public string QuestionText { get; set; }

        public List<string> PossibleAnswers { get; set; }

        public Reaction QuestionReaction;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="questionText"></param>
        /// <param name="answers"></param>
        public Question(string questionText, List<string> answers, Reaction action)
        {
            QuestionText = questionText;
            PossibleAnswers = answers;
            QuestionReaction = action;
        }

        public override string ToString()
        {
            StringBuilder tstr = new StringBuilder();
            tstr.Append(this.QuestionText + " [");
            for (int i = 0; i < this.PossibleAnswers.Count; i++)
            {
                string choice = this.PossibleAnswers[i];
                tstr.Append(choice);

                if (i < this.PossibleAnswers.Count - 1)
                    tstr.Append("/");
            }
            tstr.Append("]");

            return tstr.ToString();
        }
    }
}
