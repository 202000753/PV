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

        [HttpPost]
        public IActionResult Index(string holderName)
        {
            if (string.IsNullOrEmpty(holderName)) return View(cards);

            var filteredCards = cards.Where(c => c.HolderName.ToLower().Contains(holderName.ToLower(), StringComparison.InvariantCulture)).ToList();
            return View(filteredCards);
        }

        public IActionResult Edit(Guid id)
        {
            var card = cards.FirstOrDefault(c => c.Id == id);
            if (card is null) return View("Index", cards);

            return View(card);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, PrePaidCard prePaidCard)
        {
            var card = cards.FirstOrDefault(c => c.Id == id);
            if (card is null) return View("index");
            card.Credit = prePaidCard.Credit;

            return View("Index", cards);
        }
    }
}
