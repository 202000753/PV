using IPSPizza.Services.IngredientService.Model;

namespace IPSPizza.Services.OrderService.Models;
public class OrderIngredient
{
    public Ingredient Ingredient { get; set; }
    public decimal Price { get; set; }
}
