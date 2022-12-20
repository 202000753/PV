namespace IPSPizza.Services.OrderService.Models;

public class Pizza
{
    public PizzaSize Size { get; set; }
    public PizzaBase Base { get; set; }
    public IEnumerable<Guid>? IngredientIds { get; set; }
}

public enum PizzaBase
{
    TomatoSauce, BBQSauce, WhiteCreamSauce
}

public enum PizzaSize
{
    Small, Medium, Large
}
