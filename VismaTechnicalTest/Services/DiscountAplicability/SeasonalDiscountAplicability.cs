using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;
using VismaTechnicalTest.Services.DiscountModels;

namespace VismaTechnicalTest.Services.DiscountAplicability
{
    public class SeasonalDiscountAplicability : IDiscountAplicability
    {
        public IDiscount GetDiscount(ProductToOrder product)
        {
            return product.Quantity > 0 && (DateTime.Now.Month == 7 || DateTime.Now.Month == 12) ?
                new Discount(Constants.SeasonalDiscountRate) : new NoDiscount();
        }
    }
}
