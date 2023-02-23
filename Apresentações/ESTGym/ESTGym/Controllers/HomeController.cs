using ESTGym.Data;
using ESTGym.Models;
using ESTGym.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESTGym.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ESTGymContext _context;
        private readonly IToday _today;
        public HomeController(ILogger<HomeController> logger, ESTGymContext context, IToday today)
        {
            _logger = logger;
            _context = context;
            _today = today;
        }

        public IActionResult Index()
        {
            Today today = new Today();
            ViewData["TodayDate"] = today;
 
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
    }
}