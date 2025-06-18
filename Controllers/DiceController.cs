using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DungeonMentor.Controllers
{
    [Authorize]
    public class DiceController : Controller
    {
        private static readonly Dictionary<string, int> DiceTypes = new()
        {
            { "d4", 4 },
            { "d6", 6 },
            { "d8", 8 },
            { "d10", 10 },
            { "d12", 12 },
            { "d20", 20 },
            { "d100", 100 }
        };

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.DiceTypes = DiceTypes.Keys;
            return View();
        }

        [HttpPost]
        public IActionResult Roll(string diceType, int quantity)
        {
            if (!DiceTypes.ContainsKey(diceType) || quantity < 1 || quantity > 100)
            {
                ModelState.AddModelError("", "Неверные параметры броска.");
                ViewBag.DiceTypes = DiceTypes.Keys;
                return View("Index");
            }

            var maxValue = DiceTypes[diceType];
            var random = new Random();
            var rolls = new List<int>();

            for (int i = 0; i < quantity; i++)
            {
                rolls.Add(random.Next(1, maxValue + 1));
            }

            int total = 0;
            foreach (var roll in rolls) total += roll;

            ViewBag.DiceTypes = DiceTypes.Keys;
            ViewBag.SelectedDice = diceType;
            ViewBag.Quantity = quantity;
            ViewBag.Rolls = rolls;
            ViewBag.Total = total;

            return View("Index");
        }
    }
}
