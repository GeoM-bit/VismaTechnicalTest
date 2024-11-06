using VismaTechnicalTest.Abstractions;

namespace VismaTechnicalTest.Services.DiscountModels
{
    public class Discount(decimal discountRate) : IDiscount
    {
        private readonly decimal _discountRate = discountRate;

        public decimal CalculatePrice(decimal price)
        {
            return price - price * _discountRate;
        }
    }
}
