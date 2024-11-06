using VismaTechnicalTest.Abstractions;

namespace VismaTechnicalTest.Services.DiscountModels
{
    public class NoDiscount : IDiscount
    {
        public decimal CalculatePrice(decimal price)
        {
            return price;
        }
    }
}
