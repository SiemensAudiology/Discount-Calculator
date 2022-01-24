namespace DiscountCalculator.API.DTO
{
    public class DiscountPriceResponse
    {
        public DiscountPriceResponse(DiscountPriceRequest discountPriceRequest, decimal totalPrice)
        {
            GoldPrice = discountPriceRequest.GoldPrice;
            Weight = discountPriceRequest.Weight;
            Discount = discountPriceRequest.Discount;
            TotalPrice = totalPrice;
        }

        public decimal GoldPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }


    }
}
