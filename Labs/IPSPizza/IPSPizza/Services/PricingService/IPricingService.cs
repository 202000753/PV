using IPSPizza.Services.IngredientService.Model;
using IPSPizza.Services.PricingService.Models;

namespace IPSPizza.Services.PricingService;

public interface IPricingService
{
    public Task<decimal> GetPriceForIngredient(Ingredient ingredient);
    public Task<decimal> GetPriceForBase(PizzaType pizzaBase);
    public Task<decimal> GetPriceForSize(PizzaSize pizzaSize);
}
