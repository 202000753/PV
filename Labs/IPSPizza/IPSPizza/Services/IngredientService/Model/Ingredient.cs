namespace IPSPizza.Services.IngredientService.Model;

public class Ingredient
{
    public Guid IngredientId { get; set; }
    public IngredientType Type { get; set; }
    public string? Name { get; set; }
}

public enum IngredientType
{
    Protein, Vegetable, Cheeses
}
