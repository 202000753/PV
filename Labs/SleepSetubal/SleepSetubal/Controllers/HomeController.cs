using Microsoft.AspNetCore.Mvc;
using SleepSetubal.Models;
using System.Diagnostics;

namespace SleepSetubal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Models.Room> rooms;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            rooms = new List<Models.Room> {new Models.Room
            {
                
                name = "Studio apartment",
                type = "T0",
                beds = new List<string> { "Single Bed" },
                price = 20,
                available = true
            },
            new Models.Room
            {
                name = "Quarto Individual",
                type = "T1",
                beds = new List<string> { "Single Bed, Single Bed" },
                price = 35,
                available = true
            },
            new Models.Room
            {
                name = "Quarto de Casal",
                type = "T1",
                beds = new List<string> { "Queen Size Bed" },
                price = 50,
                available = true
            },
            new Models.Room
            {
                name = "Quarto de Casal com sofá cama",
                type = "T2",
                beds = new List<string> { "Queen Size Bed, Sofa Bed" },
                price = 60,
                available = false
            }};
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

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult RecommendedRoom()
        {
            Models.Room room = rooms[0];

            ViewData["IndexRoom"] = "Quarto " + (rooms.IndexOf(room) + 1) + " de " + rooms.Count();

            return View(room);
        }

        public VirtualFileResult MakeReservation()
        {
            return File("~/documents/Studio Apartment.pdf", "application/pdf", "Studio Apartment.pdf");
        }
    }
}