using Microsoft.AspNetCore.Mvc;
using DungeonMentor.Models;
using DungeonMentor.Data;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DungeonMentor.Controllers
{
    [Authorize]
    public class TrainingController : Controller
    {
        private readonly AppDbContext _context;

        public TrainingController(AppDbContext context)
        {
            _context = context;
        }

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
            // Пока просто 1 модуль, можно расширить
            var modules = new List<TrainingModule>
            {
                GetModuleById(1),
                GetModuleById(2), // если у тебя будут другие модули
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

            // Получаем строковый идентификатор пользователя из Claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                var existing = _context.UserProgress
                    .FirstOrDefault(p => p.UserId == userId && p.ModuleId == id);

                if (existing == null)
                {
                    _context.UserProgress.Add(new UserProgress
                    {
                        UserId = userId,
                        ModuleId = id,
                        Completed = true
                    });

                    _context.SaveChanges();
                }
            }

            return View("QuizResult");
        }
    }
}
