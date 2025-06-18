using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DungeonMentor.Controllers
{
    [Authorize]
    public class CharacterGeneratorController : Controller
    {
        private static readonly string[] Races = new[] { "Человек", "Эльф", "Дворф", "Полурослик", "Тифлинг", "Драконорожденный" };
        private static readonly string[] Classes = new[] { "Воин", "Маг", "Жрец", "Плут", "Следопыт", "Колдун" };
        private static readonly string[] Genders = new[] { "Мужской", "Женский", "Небинарный" };

        public IActionResult Index()
        {
            var model = GenerateCharacter();
            return View(model);
        }

        [HttpPost]
        public IActionResult Generate()
        {
            var model = GenerateCharacter();
            return View("Index", model);
        }

        private CharacterViewModel GenerateCharacter()
        {
            var rand = new Random();

            return new CharacterViewModel
            {
                Race = Races[rand.Next(Races.Length)],
                Class = Classes[rand.Next(Classes.Length)],
                Gender = Genders[rand.Next(Genders.Length)],
                Description = "Это базовая подсказка для вашего персонажа. Используйте её как стартовую точку."
            };
        }
    }

    public class CharacterViewModel
    {
        public string Race { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
    }
}
