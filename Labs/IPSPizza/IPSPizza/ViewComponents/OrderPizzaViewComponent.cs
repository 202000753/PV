using IPSPizza.Services.IngredientService;
using IPSPizza.Services.OrderService;
using IPSPizza.Services.OrderService.Models;
using IPSPizza.Services.PricingService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace IPSPizza.ViewComponents
{
    public class OrderPizzaViewComponent : ViewComponent
    {
        private readonly IOrderService _orderService;

        public OrderPizzaViewComponent(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IViewComponentResult> InvokeAsync(OrderResult orderResult)
        {
            if (orderResult == null)
            {
                //return View("Views/Shared/Components/OrderPizza/Order");
                return View("Order");
            }

            return View();
        }
    }
}
