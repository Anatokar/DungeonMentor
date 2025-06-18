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

        public IActionResult Index()
        {
            var modules = TrainingModule.GetModules();
            return View(modules.Select(m => m.Title).ToList());
        }

        public IActionResult Module(string name)
        {
            var module = TrainingModule.GetModules().FirstOrDefault(m => m.Title == name);
            if (module == null) return NotFound();

            ViewData["ModuleName"] = module.Title;
            ViewData["Content"] = module.Description;
            ViewData["ModuleId"] = module.Id;

            return View();
        }

        [HttpGet]
        public IActionResult Quiz(int id)
        {
            var module = TrainingModule.GetModules().FirstOrDefault(m => m.Id == id);
            if (module == null) return NotFound();

            ViewBag.ModuleId = module.Id; // Передаем ID модуля в представление
            return View(module);
        }

        [HttpPost]
        public async Task<IActionResult> Quiz(int id, Dictionary<int, int> answers)
        {
            var module = TrainingModule.GetModules().FirstOrDefault(m => m.Id == id);
            if (module == null) return NotFound();

            int correct = 0;
            for (int i = 0; i < module.Quiz.Count; i++)
            {
                if (answers.ContainsKey(i) && answers[i] == module.Quiz[i].CorrectIndex)
                {
                    correct++;
                }
            }

            double score = (correct * 100.0) / module.Quiz.Count;
            var roundedScore = (int)Math.Round(score);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = new TrainingResult
            {
                UserId = userId,
                ModuleName = module.Title,
                Score = roundedScore,
                PassedAt = DateTime.UtcNow
            };

            _context.TrainingResults.Add(result);
            await _context.SaveChangesAsync();

            ViewBag.Score = roundedScore;
            ViewBag.Correct = correct;
            ViewBag.Total = module.Quiz.Count;
            ViewBag.Passed = roundedScore >= 80;
            ViewBag.ModuleName = module.Title;
            ViewBag.ModuleId = module.Id; // Добавляем передачу ID модуля

            return View("QuizResult");
        }

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