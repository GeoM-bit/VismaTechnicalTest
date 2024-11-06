using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Abstractions
{
    public interface IDiscountService
    {
        public decimal CalculatePrice(Customer customer, ProductToOrder product);
    }
}
