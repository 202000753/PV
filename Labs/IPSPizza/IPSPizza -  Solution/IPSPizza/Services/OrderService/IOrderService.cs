using IPSPizza.Services.OrderService.Models;

namespace IPSPizza.Services.OrderService
{
    public interface IOrderService
    {
        public Task<OrderResult> OrderPizza(Pizza pizaz);
        public Task<IEnumerable<OrderIngredient>> GetIngredients();
    }
}
