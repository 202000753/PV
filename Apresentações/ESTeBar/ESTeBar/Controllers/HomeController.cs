using ESTeBar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESTeBar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
        public IActionResult ValidateAge()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateAge(Person person)
        {
            if (person.Age >= 18)
            {
                ViewBag.Message = "Podes entrar no bar!";
            }
            else
            {
                ViewBag.Message = "Desculpa, não tens idade para entrar no bar!";
            }

            return View("ValidateAge2");
        }
    }
}