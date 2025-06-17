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
        public IActionResult Module(string name)
        {
            ViewData["ModuleName"] = name;
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
