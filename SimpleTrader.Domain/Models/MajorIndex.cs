namespace SimpleTrader.Domain.Models
{
    public enum MajorIndexType
    {
        DowJones, Nasdaq, SP500
    }

    public class MajorIndex
    {
        public string IndexName { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Changes { get; set; }
        public MajorIndexType Type { get; set; }
    }
}
