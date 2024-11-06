using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;
using VismaTechnicalTest.Services.DiscountModels;

namespace VismaTechnicalTest.Services.DiscountAplicability
{
    public class VolumeDiscountAplicability : IDiscountAplicability
    {
        public IDiscount GetDiscount(ProductToOrder product)
        {
            return product.Quantity >= Constants.MinimumVolumeForDiscount ? new Discount(Constants.VolumeDiscountRate) : new NoDiscount();
        }
    }
}
