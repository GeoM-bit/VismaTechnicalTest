using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Models;
using VismaTechnicalTest.Services.DiscountModels;

namespace VismaTechnicalTest.Services.DiscountAplicability
{
    public class SpecialDealDiscountAplicability : IDiscountAplicability
    {
        public IDiscount GetDiscount(ProductToOrder product)
        {
            return product.Quantity > 0 && product.HasSpecialDiscount ? new Discount(product.SpecialDiscount) : new NoDiscount();
        }
    }
}
