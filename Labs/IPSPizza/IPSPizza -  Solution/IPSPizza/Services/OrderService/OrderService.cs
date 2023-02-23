using IPSPizza.Services.IngredientService;
using IPSPizza.Services.OrderService.Mappings;
using IPSPizza.Services.OrderService.Models;
using IPSPizza.Services.PricingService;
using System.Collections.Concurrent;

namespace IPSPizza.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IPricingService _pricingService;
        private readonly IIngredientService _ingredientService;
        public OrderService(IPricingService pricingService, IIngredientService ingredientService)
        {
            _pricingService = pricingService;
            _ingredientService = ingredientService;
        }

        public async Task<IEnumerable<OrderIngredient>> GetIngredients()
        {
            var ingredients = await _ingredientService.GetIngredients();
            if (ingredients == null || !ingredients.Any()) throw new Exception("Unable to get ingredients");

            var orderIngredients = new List<OrderIngredient>();

            foreach (var ingredient in ingredients)
            {
                var price = await _pricingService.GetPriceForIngredient(ingredient);

                orderIngredients.Add(new OrderIngredient
                {
                    Ingredient = ingredient,
                    Price = price
                });
            }
            return orderIngredients;
        }

        public async Task<OrderResult> OrderPizza(Pizza pizza)
        {
            return new OrderResult
            {
                OrderResultId = Guid.NewGuid(),
                OrderedPizza = pizza,
                Price = await CalculatePizzaCost(pizza)
            };
        }

        private async Task<decimal> CalculatePizzaCost(Pizza pizza)
        {
            var sizeCost = await _pricingService.GetPriceForSize(pizza.Size.ConvertToPizzaSize());
            var baseCost = await _pricingService.GetPriceForBase(pizza.Base.ConvertToPizzaType());
            var ingredientCost = await GetIngredientsCost(pizza.IngredientIds);

            return sizeCost + baseCost + ingredientCost;
        }

        private async Task<decimal> GetIngredientsCost(IEnumerable<Guid> ingredientIds)
        {
            var ingredients = await _ingredientService.GetIngredients();
            var totalCost = new ConcurrentBag<decimal>();
            Parallel.ForEach(ingredientIds, async id =>
            {
                var ingredient = ingredients.FirstOrDefault(i => i.IngredientId == id);                
                var cost = await _pricingService.GetPriceForIngredient(ingredient);
                totalCost.Add(cost);
            });
            return totalCost.Sum();
        }
    }
}
