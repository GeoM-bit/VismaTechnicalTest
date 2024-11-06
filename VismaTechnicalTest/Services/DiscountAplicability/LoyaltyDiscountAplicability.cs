using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;
using VismaTechnicalTest.Services.DiscountModels;

namespace VismaTechnicalTest.Services.DiscountAplicability
{
    public class LoyaltyDiscountAplicability : IDiscountAplicability
    {
        public IDiscount GetDiscount(ProductToOrder product)
        {
            return product.Quantity > 0 ? new Discount(Constants.LoyaltyDiscountRate) : new NoDiscount();
        }
    }
}
