namespace DiscountCalculator.API.DTO
{
    public class DiscountPriceRequest
    {
        public DiscountPriceRequest(decimal goldPrice, decimal weight, decimal discount)
        {
            GoldPrice = goldPrice;
            Weight = weight;
            Discount = discount;
        }

        public decimal GoldPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Discount { get; set; }
    }
}
