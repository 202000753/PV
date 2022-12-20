using IPSCard.Data;
using IPSCard.Models;
using Microsoft.AspNetCore.Mvc;

namespace IPSCard.Controllers
{
    public class CardsController : Controller
    {
        private static List<PrePaidCard> cards = SeedCards.Seed();

        public IActionResult Index()
        {
            return View(cards);
        }

        [HttpPost]
        public IActionResult Index(string holderName)
        {
            if (string.IsNullOrEmpty(holderName)) return View(cards);

            var filteredCards = cards.Where(c => c.HolderName.ToLower().Contains(holderName.ToLower(), StringComparison.InvariantCulture)).ToList();
            return View(filteredCards);
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

        public IActionResult Details(Guid id)
        {
            var card = cards.FirstOrDefault(c => c.Id == id);
            if (card is null) return View("Index", cards);

            return View(card);
        }


        public IActionResult Delete(Guid id)
        {
            var card = cards.FirstOrDefault(c => c.Id == id);
            if (card is null) return View("index");

            return View(card);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            cards = cards.Where(c => c.Id != id).ToList();

            return View("Index", cards);
        }
    }
}
