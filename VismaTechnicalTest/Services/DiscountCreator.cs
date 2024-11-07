using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;
using VismaTechnicalTest.Services.DiscountModels;

namespace VismaTechnicalTest.Services
{
    public class DiscountCreator : IDiscountCreator
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDiscountProvider _discountProvider;
        public DiscountCreator(ICustomerRepository customerRepository, IDiscountProvider discountProvider)
        {
            _customerRepository = customerRepository;
            _discountProvider = discountProvider;
        }

        public IDiscount CreateDiscount(int customerId, ProductToOrder product)
        {
            var customerDiscounts = _customerRepository.GetDiscountTypesForCustomer(customerId);
            var discountTypesDictionary = _discountProvider.GetDiscountsDictionary();

            CompositeDiscount compositeDiscount = new();

            foreach (DiscountType discountType in customerDiscounts)
            {
                if (discountTypesDictionary.TryGetValue(discountType, out var discount))
                {
                    compositeDiscount.AddDiscount(discount(product));
                }
            }

            return compositeDiscount.discounts.Count != 0 ? compositeDiscount : new NoDiscount();
        }
    }
}
