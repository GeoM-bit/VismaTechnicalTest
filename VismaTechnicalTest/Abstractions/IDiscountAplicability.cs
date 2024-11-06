using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Abstractions
{
    public interface IDiscountAplicability
    {
        IDiscount GetDiscount(ProductToOrder product);
    }
}
