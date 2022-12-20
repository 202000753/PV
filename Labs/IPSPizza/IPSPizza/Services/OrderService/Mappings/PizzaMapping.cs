using IPSPizza.Services.OrderService.Models;

namespace IPSPizza.Services.OrderService.Mappings;

public static class PizzaMapping
{
    public static PricingService.Models.PizzaType ConvertToPizzaType(this PizzaBase pizzaBase)
    {
        switch (pizzaBase)
        {
            default:
            case PizzaBase.TomatoSauce:
            case PizzaBase.BBQSauce:
                return PricingService.Models.PizzaType.RedSauce;
            case PizzaBase.WhiteCreamSauce:
                return PricingService.Models.PizzaType.WhiteSauce;
        }
    }

    public static PricingService.Models.PizzaSize ConvertToPizzaSize(this PizzaSize pizzaSize)
    {
        switch (pizzaSize)
        {
            default:
            case PizzaSize.Small:
                return PricingService.Models.PizzaSize.Small;
            case PizzaSize.Medium:
                return PricingService.Models.PizzaSize.Normal;
            case PizzaSize.Large:
                return PricingService.Models.PizzaSize.Big;
        }
    }
}
