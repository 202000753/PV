namespace IPSCard.Models
{
    public class PrePaidCard
    {
        public Guid Id { get; private set; }
        public string HolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Credit { get; set; }

        public PrePaidCard()
        {
            Id = Guid.NewGuid();
            ExpiryDate = DateTime.UtcNow.AddYears(5);
        }

        public PrePaidCard(string holderName, decimal credit) : this()
        {
            this.HolderName = holderName;
            this.Credit = credit;
        }
    }
}
