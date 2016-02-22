using Packt.QuizWebApp;

namespace Ch16_QuizWebApp.ViewModels.Home
{
    public class QuestionViewModel
    {
        public Question Question { get; set; }
        public string Answer { get; set; }
        public int Number { get; set; }
        public int Total { get; set; }
    }
}
