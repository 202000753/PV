using ESTGym.Data;
using ESTGym.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESTGym.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ESTGymContext _context;

        public HomeController(ILogger<HomeController> logger, ESTGymContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var people = _context.Person.ToList();

            return View(people.Where(p => IsAdult(p)));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [NonAction]
        public static bool IsAdult(Person person)
        {
            return person.Age >= 18;
        }
    }
}