using Microsoft.AspNetCore.Mvc;
using DungeonMentor.Models;

namespace DungeonMentor.Controllers
{
    public class TrainingController : Controller
    {
        // Список всех модулей
        public IActionResult Index()
        {
            var modules = new List<TrainingModule>
            {
                new TrainingModule
                {
                    Id = 1,
                    Title = "Основы D&D: Кубики и Ролевые действия",
                    Description = "Научись кидать кубики и описывать действия персонажа.",
                },
                new TrainingModule
                {
                    Id = 2,
                    Title = "Классы персонажей",
                    Description = "Разберись, чем отличается воин от мага и кого выбрать.",
                }
            };

            return View(modules);
        }

        // Открытие конкретного модуля
        public IActionResult Module(int id)
        {
            // В будущем заменим на загрузку из базы
            var module = new TrainingModule
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
                }
            };

            return View(module);
        }
    }
}