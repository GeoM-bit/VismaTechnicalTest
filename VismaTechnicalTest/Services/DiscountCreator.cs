using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;
using VismaTechnicalTest.Services.DiscountAplicability;
using VismaTechnicalTest.Services.DiscountModels;

namespace VismaTechnicalTest.Services
{
    public class DiscountCreator
    {
        //this should be injected somehow
        private static readonly Dictionary<DiscountType, Func<ProductToOrder, IDiscount>> discountTypesDictionary =
            new()
            {
                { DiscountType.VOLUME, new VolumeDiscountAplicability().GetDiscount },
                { DiscountType.SEASONAL, new SeasonalDiscountAplicability().GetDiscount },
                { DiscountType.SPECIAL_DEAL, new SpecialDealDiscountAplicability().GetDiscount },
                { DiscountType.LOYALTY, new LoyaltyDiscountAplicability().GetDiscount }
            };
        public static IDiscount CreateDiscount(Customer customer, ProductToOrder product)
        {
            List<DiscountType> customerDiscounts = GetDiscountsForCustomer(customer);

            CompositeDiscount compositeDiscount = new();

            foreach (DiscountType discountType in customerDiscounts)
            {
                if (discountTypesDictionary.TryGetValue(discountType, out var discount))
                {
                    compositeDiscount.AddDiscount(discount(product));
                }
            }

            return compositeDiscount._discounts.Count != 0 ? compositeDiscount : new NoDiscount();
        }

        //this should be in called from a repo
        private static List<DiscountType> GetDiscountsForCustomer(Customer customer)
        {
            if (customer.Id == 1)
                return
                [
                    DiscountType.VOLUME,
                    DiscountType.SPECIAL_DEAL
                ];
            return [];
        }
    }
}
