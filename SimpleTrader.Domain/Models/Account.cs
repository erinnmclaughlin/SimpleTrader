namespace SimpleTrader.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; } = null!;
        public double Balance { get; set; }

        public ICollection<AssetTransaction>? AssetTransactions { get; set; }
    }
}
