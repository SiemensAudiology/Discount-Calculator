using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator.Service.DiscountService
{
    public interface IDiscountService
    {
        int CalculatePrice(int goldPrice, int weight, int discount = 0);
    }
}
