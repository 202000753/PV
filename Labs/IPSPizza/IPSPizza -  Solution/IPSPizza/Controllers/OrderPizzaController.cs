using IPSPizza.Services.IngredientService;
using IPSPizza.Services.OrderService;
using IPSPizza.Services.OrderService.Models;
using Microsoft.AspNetCore.Mvc;

namespace IPSPizza.Controllers
{
    public class OrderPizzaController : Controller
    {
        private readonly ILogger<OrderPizzaController> _logger;
        private readonly IOrderService _orderService;

        public OrderPizzaController(ILogger<OrderPizzaController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Order(Pizza pizza)
        {
            var orderResult = await _orderService.OrderPizza(pizza);
            return ViewComponent("OrderPizza", orderResult);
        }
    }
}