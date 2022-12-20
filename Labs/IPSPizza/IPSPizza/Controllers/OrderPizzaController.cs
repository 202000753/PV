using Microsoft.AspNetCore.Mvc;

namespace IPSPizza.Controllers;

public class OrderPizzaController : Controller
{
    private readonly ILogger<OrderPizzaController> _logger;

    public OrderPizzaController(ILogger<OrderPizzaController> logger)
    {
        _logger = logger;
    }
}