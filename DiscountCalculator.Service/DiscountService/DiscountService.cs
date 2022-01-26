using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator.Service.DiscountService
{
    public class DiscountService : IDiscountService
    {
        public int CalculatePrice(int goldPrice, int weight, int discount = 0)
        {
            var price = goldPrice * weight;

            if (discount == 0)
                return price;

            return price - (discount % price * 100);
        }
    }
}
