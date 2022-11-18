using IPSCard.Data;
using IPSCard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace IPSCard.Controllers
{
    public class CardsController : Controller
    {
        private static List<PrePaidCard> cards = SeedCards.Seed();

        public IActionResult Index()
        {
            return View(cards);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PrePaidCard prePaidCard)
        {
            cards.Add(prePaidCard);
            
            return View("Index", cards);
        }
    }
}
