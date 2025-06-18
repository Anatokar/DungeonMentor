using Microsoft.AspNetCore.Mvc;

namespace DungeonMentor.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}