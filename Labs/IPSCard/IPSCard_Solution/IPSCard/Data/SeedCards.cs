using IPSCard.Models;

namespace IPSCard.Data
{
    public static class SeedCards
    {
        public static List<PrePaidCard> Seed() => new()
        {
            new PrePaidCard("Bruno Teixeira", 1000m),
            new PrePaidCard("José Cordeiro", 1500m),
            new PrePaidCard("Vitor Xavier", 2000.50m)
        };

    }
}
