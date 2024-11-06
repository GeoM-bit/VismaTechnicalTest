using VismaTechnicalTest.Abstractions;

namespace VismaTechnicalTest.Services.Discount
{
    public class NoDiscount : IDiscount
    {
        public decimal CalculatePrice(decimal price)
        {
            return price;
        }
    }
}
