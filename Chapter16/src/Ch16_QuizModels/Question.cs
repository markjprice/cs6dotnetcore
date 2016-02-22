namespace Packt.QuizWebApp
{
    public class Question
    {
        public int QuestionID { get; set; } // identity
        public string QuestionText { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; } // e.g. B
        // the other side of the one-to-many relationship
        public virtual Quiz Quiz { get; set; }
    }
}
