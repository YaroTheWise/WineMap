namespace WineMap.Specification.Models
{
    public class Price
    {
        public int? PriceId { get; set; }
        public int Volume { get; set; }
        public decimal Value { get; set; }
        public decimal? Discount { get; set; }
    }
}