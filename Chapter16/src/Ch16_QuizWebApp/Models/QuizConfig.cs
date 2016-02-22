using Packt.QuizWebApp;
using Microsoft.AspNet.Builder;
using Microsoft.Data.Entity;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Ch16_QuizWebApp.Models
{
    public static class QuizConfig
    {
        public static void UseSampleQuestions(this IApplicationBuilder app, string path)
        {
            // load a sample JSON file of questions
            string json = File.ReadAllText(Path.Combine(path, "samplequestions.json"));

            var settings = new JsonSerializerSettings
                { PreserveReferencesHandling = PreserveReferencesHandling.All };

            List<Quiz> quizzes = JsonConvert.DeserializeObject<List<Quiz>>(json, settings);

            // Configure the in-memory database option
            var optionsBuilder = new DbContextOptionsBuilder<QuizContext>();
            optionsBuilder.UseInMemoryDatabase();

            using (var context = new QuizContext(optionsBuilder.Options))
            {
                foreach (Quiz quiz in quizzes)
                {
                    // mark each quiz and its question entities as Added
                    context.Add(quiz, GraphBehavior.IncludeDependents);
                }
                // Save the entities to the data store
                context.SaveChanges();
            }
        }
    }
}
