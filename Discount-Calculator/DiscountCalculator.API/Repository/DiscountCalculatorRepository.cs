namespace DiscountCalculator.API.Repository
{
    public class DiscountCalculatorRepository
    {
        public decimal CalculateTotalPrice(decimal price, decimal discount, decimal quantity)
        {
            var weightedPrice = price * quantity;
            var discountPrice = weightedPrice * discount/100;
            return weightedPrice - discountPrice;
        }
    }
}
