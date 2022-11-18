using Microsoft.AspNetCore.Mvc;
using SleepSetubal.Models;
using System.Diagnostics;

namespace SleepSetubal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Room> rooms;
        private int indexRoom = 0;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //Nivel 2
            rooms = new List<Room> {
                 new Room
                 {
                     Name = "Studio apartment",
                     Type = "T0",
                     Beds = new List<string>{"Single Bed"},
                     Price = 20,
                     Available = true
                 },
                 new Room
                 {
                     Name = "Quarto Individual",
                     Type = "T1",
                     Beds = new List<string>{"Single Bed, Single Bed"},
                     Price = 35,
                     Available = true
                 },
                 new Room
                 {
                     Name = "Quarto de Casal",
                     Type = "T1",
                     Beds = new List<string>{"Queen Size Bed"},
                     Price = 50,
                     Available = true
                 },
                 new Room
                 {
                     Name = "Quarto de Casal com sofá cama",
                     Type = "T2",
                     Beds = new List<string>{"Queen Size Bed, Sofa Bed"},
                     Price = 60,
                     Available = false
                 }
            };
        }

        public IActionResult Index()
        {
            return View();
        }
        // Nivel 1
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Nivel 2
        public IActionResult RecommendedRoom()
        {
            Room recommendedRoom = rooms[indexRoom];

            ViewData["IndexRoom"] = string.Format("Quarto {0} de {1}", rooms.IndexOf(recommendedRoom) + 1, rooms.Count);

            return View(recommendedRoom);
        }

        //Nivel 5
        /**public VirtualFileResult MakeReservation()
        {
            Room room = rooms[indexRoom];

            string filename = room.Name+ ".pdf";

            return File($"~/documents/{filename}", "application/pdf", filename);
        }*/

        //Desafio
        public VirtualFileResult MakeReservation(string name)
        {
            string filename = name + ".pdf";
            return File($"~/documents/{filename}", "application/pdf", filename);
        }
    }
}