using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;
using VismaTechnicalTest.Services.DiscountAplicability;

namespace VismaTechnicalTest.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        public Dictionary<DiscountType, Func<ProductToOrder, IDiscount>> GetDiscountsDictionary()
        {
            return new()
            {
                { DiscountType.VOLUME, new VolumeDiscountAplicability().GetDiscount },
                { DiscountType.SEASONAL, new SeasonalDiscountAplicability().GetDiscount },
                { DiscountType.SPECIAL_DEAL, new SpecialDealDiscountAplicability().GetDiscount },
                { DiscountType.LOYALTY, new LoyaltyDiscountAplicability().GetDiscount }
            };
        }
    }
}
