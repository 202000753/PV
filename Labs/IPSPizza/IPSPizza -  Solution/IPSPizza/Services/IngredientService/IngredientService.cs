using IPSPizza.Services.IngredientService.Model;

namespace IPSPizza.Services.IngredientService;

public class IngredientService : IIngredientService
{
    private readonly IEnumerable<Ingredient> _ingredients = new List<Ingredient>()
    {
        new Ingredient
        {
            IngredientId= Guid.NewGuid(),
            Name = "Pepperoni",
            Type = IngredientType.Protein
        },
        new Ingredient
        {
            IngredientId= Guid.NewGuid(),
            Name = "Fried Chicken",
            Type = IngredientType.Protein
        },
        new Ingredient
        {
            IngredientId= Guid.NewGuid(),
            Name = "Bacon",
            Type = IngredientType.Protein
        },
        new Ingredient
        {
            IngredientId= Guid.NewGuid(),
            Name = "Cheddar",
            Type = IngredientType.Cheeses
        },
        new Ingredient
        {
            IngredientId= Guid.NewGuid(),
            Name = "Parmesan",
            Type = IngredientType.Cheeses
        },
        new Ingredient
        {
            IngredientId= Guid.NewGuid(),
            Name = "Onions",
            Type = IngredientType.Vegetable
        },
        new Ingredient
        {
            IngredientId= Guid.NewGuid(),
            Name = "Tomatos",
            Type = IngredientType.Vegetable
        },
        new Ingredient
        {
            IngredientId= Guid.NewGuid(),
            Name = "Mushrooms",
            Type = IngredientType.Vegetable
        },
    };

    public async Task<IEnumerable<Ingredient>> GetIngredients()
    {
        // Simulate DB access
        await Task.Delay(250);
        return _ingredients;
    }
}
