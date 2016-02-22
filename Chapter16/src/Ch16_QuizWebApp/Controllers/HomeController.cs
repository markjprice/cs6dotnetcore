using Packt.QuizWebApp;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Ch16_QuizWebApp.Controllers
{
    public class HomeController : Controller
    {
        private QuizContext db;

        public JsonSerializerSettings settings = new JsonSerializerSettings
            { PreserveReferencesHandling = PreserveReferencesHandling.All } ;

        #region Helper methods to store state in Session
        public void SetQuiz(Quiz input)
        {
            string json = JsonConvert.SerializeObject(input, Formatting.None, settings);
            HttpContext.Session.SetString("usersquiz", json);
        }

        public Quiz GetQuiz()
        {
            string json = HttpContext.Session.GetString("usersquiz");
            return JsonConvert.DeserializeObject<Quiz>(json, settings);
        }

        public void SetAnswers(Dictionary<int, string> input)
        {
            string json = JsonConvert.SerializeObject(input, settings);
            HttpContext.Session.SetString("usersanswers", json);
        }

        public Dictionary<int, string> GetAnswers()
        {
            string json = HttpContext.Session.GetString("usersanswers");
            return JsonConvert.DeserializeObject<Dictionary<int, string>>(json, settings);
        }
        #endregion

        public HomeController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuizContext>();
            optionsBuilder.UseInMemoryDatabase();
            db = new QuizContext(optionsBuilder.Options);
        }

        public async Task<IActionResult> Index()
        {
            var model = await db.Quizzes.ToListAsync();
            ViewData["Title"] = "Home";
            return View(model);
        }

        public IActionResult TakeQuiz(string id)
        {
            Quiz model = db.Quizzes.Where(q => q.QuizID == id).Include(q => q.Questions).FirstOrDefault();
            if (model == null)
            {
                return HttpNotFound($"A quiz with the ID of {id} was not found.");
            }
            SetQuiz(model);
            SetAnswers(new Dictionary<int, string>());
            ViewData["Title"] = "Take Quiz";
            return View(model);
        }

        public IActionResult Question(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound("You must pass an id of a question.");
            }
            var quiz = GetQuiz();
            var answers = GetAnswers();
            var model = new ViewModels.Home.QuestionViewModel
            {
                Question = quiz.Questions.Skip(id.Value - 1).Take(1).FirstOrDefault(),
                Answer = answers.ContainsKey(id.Value - 1) ? answers[id.Value - 1] : string.Empty,
                Number = id.Value,
                Total = quiz.Questions.Count()
            };
            ViewData["Title"] = $"Question {model.Number} of {model.Total}";
            return View(model);
        }

        [HttpPost]
        public IActionResult Question(int? id, string submit, string answer)
        {
            if (!id.HasValue)
            {
                return HttpNotFound("You must pass an id of a question.");
            }
            var answers = GetAnswers();
            answers[id.Value - 1] = answer;
            SetAnswers(answers);
            if (submit == "Previous")
            {
                id--;
            }
            else if (submit == "Next")
            {
                id++;
            }
            else if (submit == "Finish")
            {
                return RedirectToAction("Finish");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Question", new { id = id });
        }

        public IActionResult Finish()
        {
            var quiz = GetQuiz();
            var model = new ViewModels.Home.FinishViewModel
            {
                Quiz = quiz,
                Answers = GetAnswers()
            };
            for (int i = 0; i < model.Quiz.Questions.Count; i++)
            {
                if (model.Quiz.Questions.ToList()[i].CorrectAnswer == model.Answers[i]) model.CorrectAnswers++;
            }
            ViewData["Title"] = "End of Quiz";
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
