using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Abstractions
{
    public interface IDiscountService
    {
        public decimal CalculatePrice(int customerId, ProductToOrder product);
    }
}
