using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DungeonMentor.Data;
using DungeonMentor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DungeonMentor.Controllers
{
    [Authorize]
    public class MiniScenarioController : Controller
    {
        private readonly AppDbContext _context;

        public MiniScenarioController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var history = _context.Messages
                .Where(m => m.UserId == userId)
                .OrderBy(m => m.CreatedAt)
                .Select(m => m.Text)
                .ToList();

            return View(history);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string userMessage)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Добавляем сообщение пользователя
            var userMsg = new Message
            {
                UserId = userId,
                Text = "Игрок: " + userMessage,
                CreatedAt = DateTime.UtcNow
            };
            _context.Messages.Add(userMsg);

            // Генерируем ответ ИИ (заглушка)
            string aiResponseText = $"Мастер: Я получил сообщение: '{userMessage}'. Что ты будешь делать дальше?";
            var aiMsg = new Message
            {
                UserId = userId,
                Text = aiResponseText,
                CreatedAt = DateTime.UtcNow.AddMilliseconds(1) // чуть позже, чтобы не было одинаковых дат
            };
            _context.Messages.Add(aiMsg);

            await _context.SaveChangesAsync();

            // Получаем всю историю заново из базы
            var history = _context.Messages
                .Where(m => m.UserId == userId)
                .OrderBy(m => m.CreatedAt)
                .Select(m => m.Text)
                .ToList();

            return View("Index", history);
        }
    }
}
