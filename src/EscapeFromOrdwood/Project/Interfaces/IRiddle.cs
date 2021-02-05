using System.Collections.Generic;
using EscapeFromOrdwood.Project.Models;

namespace EscapeFromOrdwood.Project.Interfaces
{
    public interface IRiddle
    {
        string FirstClue { get; set; }
        string SecondClue { get; set; }
        string Answer { get; set; }
        string CorrectAnswerEventText { get; set; }
        Item Reward { get; set; }
        bool IsCompleted { get; set; }
    }
}