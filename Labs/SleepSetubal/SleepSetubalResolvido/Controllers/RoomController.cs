using Microsoft.AspNetCore.Mvc;
using SleepSetubal.Models;

namespace SleepSetubal.Controllers
{
    //Nivel 3
    public class RoomController : Controller
    {
        private List<Room> rooms;

        public RoomController()
        {
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

        public IActionResult ListRooms()
        {
            return View(rooms);
        }
        //Nivel 4
        public IActionResult AvailableRooms()
        {
            return View(rooms.Where(r => r.Available).ToList());
        }
    }
}
