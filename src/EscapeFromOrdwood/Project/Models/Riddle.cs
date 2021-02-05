using System.Collections.Generic;
using EscapeFromOrdwood.Project.Models;

namespace EscapeFromOrdwood.Project.Interfaces
{
    public class Riddle : IRiddle
    {
        public string FirstClue { get; set; }
        public string SecondClue { get; set; }
        public string Answer { get; set; }
        public string CorrectAnswerEventText { get; set; }
        public Item Reward { get; set; }

        public bool IsCompleted { get; set; }
    
        public Riddle(string firstClue, string secondClue, string answer, string correctAnswerEventText, Item reward, bool isCompleted)
        {
            FirstClue = firstClue;
            SecondClue = secondClue;
            Answer = answer;
            CorrectAnswerEventText = correctAnswerEventText;
            Reward = reward;
            IsCompleted = isCompleted;
        }
    
    }
}