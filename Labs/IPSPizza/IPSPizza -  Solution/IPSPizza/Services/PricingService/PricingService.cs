using IPSPizza.Services.IngredientService.Model;
using IPSPizza.Services.PricingService.Models;

namespace IPSPizza.Services.PricingService
{
    public class PricingService : IPricingService
    {
        public async Task<decimal> GetPriceForBase(PizzaType pizzaType)
        {
            //Simualte DB access
            await Task.Delay(100);
            return pizzaType switch
            {
                PizzaType.RedSauce => 4m,
                PizzaType.WhiteSauce => 5m,
                _ => throw new ArgumentException("Unkown Pizza Base"),
            };
        }

        public async Task<decimal> GetPriceForIngredient(Ingredient ingredient)
        {
            //Simualte DB access
            await Task.Delay(100);
            return ingredient.Type switch
            {
                IngredientType.Protein => 1m,
                IngredientType.Vegetable => 0.75m,
                IngredientType.Cheeses => 1.25m,
                _ => throw new ArgumentException("Unkown Ingredient Type"),
            };
        }

        public async Task<decimal> GetPriceForSize(PizzaSize pizzaSize)
        {
            //Simualte DB access
            await Task.Delay(100);
            return pizzaSize switch
            {
                PizzaSize.Small => 6.5m,
                PizzaSize.Normal => 8.5m,
                PizzaSize.Big => 12m,
                _ => throw new ArgumentException("Unkown Piza Size"),
            };
        }
    }
}
