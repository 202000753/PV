
using IPSPizza.Services.IngredientService;
using IPSPizza.Services.IngredientService.Model;
using IPSPizza.Services.OrderService.Mappings;
using IPSPizza.Services.OrderService.Models;
using IPSPizza.Services.PricingService;

namespace IPSPizza.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly IIngredientService _ingredientService;
    private readonly IPricingService _pricingService;

    public OrderService(IIngredientService ingredientService, IPricingService pricingService)
    {
        _ingredientService = ingredientService;
        _pricingService = pricingService;
    }

    public async Task<IEnumerable<OrderIngredient>> GetIngredients()
    {
        var ingredients = await _ingredientService.GetIngredients();
        List<OrderIngredient> orderIngredients = new List<OrderIngredient>();

        foreach (var ingredient in ingredients)
        {
            orderIngredients.Add(new OrderIngredient { Ingredient = ingredient, Price = await _pricingService.GetPriceForIngredient(ingredient) });
        }

        return orderIngredients;
    }

    public async Task<OrderResult> OrderPizza(Pizza pizza)
    {
        decimal price = 0;
        price += await _pricingService.GetPriceForSize(PizzaMapping.ConvertToPizzaSize(pizza.Size));
        price += await _pricingService.GetPriceForBase(PizzaMapping.ConvertToPizzaType(pizza.Base));
        var ingredients = await _ingredientService.GetIngredients();

        foreach (Guid id in pizza.IngredientIds)
        {
            var ingredient = ingredients.FirstOrDefault(ing => ing.IngredientId == id);
            price += await _pricingService.GetPriceForIngredient(ingredient);
        }

        return new OrderResult { OrderedPizza = pizza, Price = price };
    }
}
