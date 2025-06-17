using Microsoft.AspNetCore.Mvc;
using DungeonMentor.Models;

namespace DungeonMentor.Controllers
{
    public class TrainingController : Controller
    {
        private TrainingModule GetModuleById(int id)
        {
            return new TrainingModule
            {
                Id = id,
                Title = "Основы D&D: Кубики и Ролевые действия",
                Description = "Ты узнаешь, как работают броски и как их применять.",
                Lessons = new List<string>
            {
                "В D&D используется 20-гранный кубик (d20).",
                "Для проверки действий бросается d20 + бонус.",
                "Успех зависит от сложности (DC) задачи.",
                "Игрок описывает действие, Мастер называет бросок."
            },
                Quiz = new List<Question>
            {
                new Question
                {
                    Text = "Какой основной кубик используется в D&D 5e?",
                    Options = new List<string> { "d6", "d10", "d20", "d100" },
                    CorrectIndex = 2
                },
                new Question
                {
                    Text = "Что означает DC в проверке?",
                    Options = new List<string> { "Damage Count", "Difficulty Class", "Dice Calculation", "Dungeon Code" },
                    CorrectIndex = 1
                }
            }
            };
        }

        public IActionResult Index()
        {
            var modules = new List<TrainingModule>
            {
                GetModuleById(1),
                // Здесь можно добавить другие модули в будущем
            };
            return View(modules);
        }


        public IActionResult Module(int id)
        {
            var module = GetModuleById(id);
            return View(module);
        }

        [HttpGet]
        public IActionResult Quiz(int id)
        {
            var module = GetModuleById(id);
            return View(module);
        }

        [HttpPost]
        public IActionResult Quiz(int id, List<int> answers)
        {
            var module = GetModuleById(id);
            int score = 0;

            for (int i = 0; i < module.Quiz.Count; i++)
            {
                if (i < answers.Count && answers[i] == module.Quiz[i].CorrectIndex)
                    score++;
            }

            ViewBag.Score = (int)((score / (double)module.Quiz.Count) * 100);
            ViewBag.Total = module.Quiz.Count;
            ViewBag.Correct = score;
            ViewBag.ModuleTitle = module.Title;

            return View("QuizResult");
        }


    }
}
