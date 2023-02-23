using IPSPizza.Services.OrderService;
using IPSPizza.Services.OrderService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IPSPizza.ViewComponents;

public class OrderPizzaViewComponent : ViewComponent
{
    private readonly IOrderService _orderService;
    public OrderPizzaViewComponent(IOrderService orderService)
    {
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    public async Task<IViewComponentResult> InvokeAsync(OrderResult? orderResult)
    {
        if (orderResult == null) return await GetOrderView();

        return View("Result", orderResult);
    }

    private async Task<IViewComponentResult> GetOrderView()
    {
        var ingredients = await _orderService.GetIngredients();
        ViewBag.Ingredients = new SelectList(ingredients.Select(i => new { Value = i.Ingredient.IngredientId.ToString(), Text = $"{i.Ingredient.Name} - {i.Price}€" }), "Value", "Text");

        ViewBag.Bases = new SelectList(Enum.GetValues<PizzaBase>().Select(b => new { Value = (int)b, Text = b }), "Value", "Text");
        ViewBag.Sizes = new SelectList(Enum.GetValues<PizzaSize>().Select(s => new { Value = (int)s, Text = s }), "Value", "Text");
        return View("Order");
    }
}
