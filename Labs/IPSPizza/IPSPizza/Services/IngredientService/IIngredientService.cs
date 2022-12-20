using IPSPizza.Services.IngredientService.Model;

namespace IPSPizza.Services.IngredientService;

public interface IIngredientService
{
    public Task<IEnumerable<Ingredient>> GetIngredients();
}
