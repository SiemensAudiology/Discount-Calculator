using DiscountCalculator.Service.DiscountService;
using NUnit.Framework;

namespace DiscountCalculator.Tests
{
    public class DiscountServiceTests
    {

        private DiscountService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DiscountService();
        }

        [Test]
        public void CalculatePrice_WhenNoDiscountIsSupplied()
        {

            var price = _sut.CalculatePrice(1000, 10);
            
            Assert.True(price == 10000);
        }

        [Test]
        public void CalculatePrice_WhenDiscountIsSupplied()
        {
            var price = _sut.CalculatePrice(1000, 10, 5);

            Assert.True(price == 9500);
        }
    }
} 