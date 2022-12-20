namespace IPSPizza.Services.OrderService.Models;

public class OrderResult
{
    public Guid OrderResultId { get; set; }
    public Pizza? OrderedPizza { get; set; }
    public decimal Price { get; set; }
}
