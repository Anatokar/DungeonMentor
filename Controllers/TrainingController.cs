using DungeonMentor.Data;
using DungeonMentor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        // Показ доступных модулей
        public IActionResult Index()
        {
            var modules = new List<string> { "Основы DnD", "Боевая система", "Классы и расы" };
            return View(modules);
        }

        // Страница модуля
        public IActionResult Module(string name, bool showTest = false)
        {
            ViewData["ModuleName"] = name;
            ViewData["ShowTest"] = showTest;

            string content = name switch
            {
                "Основы DnD" => "Dungeons & Dragons (DnD) — это настольная ролевая игра, в которой игроки берут на себя роли персонажей и совместно создают воображаемые приключения под руководством Ведущего.",
                "Боевая система" => "Боевая система в DnD основана на инициативах, бросках кубиков и действиях. Персонажи и монстры по очереди совершают действия: атака, заклинание, перемещение и т.д.",
                "Классы и расы" => "Каждый персонаж в DnD принадлежит к расе (человек, эльф, дворф) и классу (воин, маг, плут и др.). Класс определяет стиль игры, способности и роль в команде.",
                _ => "Модуль не найден."
            };

            ViewData["Content"] = content;
            return View();
        }


        // Завершение модуля
        [HttpPost]
        public async Task<IActionResult> Complete(string moduleName, int score)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = new TrainingResult
            {
                UserId = userId,
                ModuleName = moduleName,
                Score = score,
                PassedAt = DateTime.UtcNow
            };

            _context.TrainingResults.Add(result);
            await _context.SaveChangesAsync();

            return View("Complete", result); // Отображаем Complete.cshtml с моделью
        }


        // История обучения пользователя
        public IActionResult History()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var myResults = _context.TrainingResults
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.PassedAt)
                .ToList();

            return View(myResults);
        }
    }
}
