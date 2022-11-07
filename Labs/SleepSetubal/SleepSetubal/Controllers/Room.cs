using Microsoft.AspNetCore.Mvc;

namespace SleepSetubal.Controllers
{
    public class Room : Controller
    {
        private List<Models.Room> rooms;

        public Room(ILogger<Room> logger)
        {
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

        public IActionResult ListRooms()
        {
            return View(rooms);
        }

        public IActionResult AvailableRooms()
        {
            var availableRooms = from r in rooms where r.available == true select r;
            //availableRooms = from r in rooms where r.name == "a" select r;

            return View(availableRooms);
        }
    }
}
