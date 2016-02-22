using System.Collections.Generic;

namespace Packt.QuizWebApp
{
    public class Quiz
    {
        public string QuizID { get; set; } // e.g. CSHARP
        public string Title { get; set; } // e.g. C# and OOP
        public string Description { get; set; }

        // one-to-many relationship with a collection of Questions
        public virtual ICollection<Question> Questions { get; set; }
        
        // constructor to instantiate an empty collection
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }
    }
}
