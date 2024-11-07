using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Abstractions
{
    public interface IDiscountCreator
    {
        public IDiscount CreateDiscount(int customerId, ProductToOrder product);
    }
}
