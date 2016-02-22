using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace Packt.QuizWebApp
{
    public class QuizContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }

        // Best practice is to allow the options to be 
        // passed into a constructor so that we remove any 
        // assumptions about where the data is stored: in-memory, 
        // SQL Server, and so on.
        public QuizContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().HasMany<Question>().WithOne(q => q.Quiz);
            base.OnModelCreating(modelBuilder);
        }
    }
}
