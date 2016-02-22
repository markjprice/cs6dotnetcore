using Packt.QuizWebApp;
using System.Collections.Generic;

namespace Ch16_QuizWebApp.ViewModels.Home
{
    public class FinishViewModel
    {
        public Quiz Quiz { get; set; }
        public Dictionary<int, string> Answers { get; set; }
        public int CorrectAnswers { get; set; }
    }
}
