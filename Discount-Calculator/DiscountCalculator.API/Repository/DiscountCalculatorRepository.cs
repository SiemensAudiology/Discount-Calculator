namespace DiscountCalculator.API.Repository
{
    public class DiscountCalculatorRepository
    {
        public decimal CalculateTotalPrice(decimal price, decimal? discount, decimal quantity)
        {
            if(!discount.HasValue) discount = 0;

            return ((price * quantity) - ((price * quantity) - (price * quantity * discount.Value)/100));
        }
    }
}
