using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;
using VismaTechnicalTest.Services.DiscountModels;

namespace VismaTechnicalTest.Services
{
    public class DiscountCreator : IDiscountCreator
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDiscountRepository _discountRepository;
        public DiscountCreator(ICustomerRepository customerRepository, IDiscountRepository discountRepository)
        {
            _customerRepository = customerRepository;
            _discountRepository = discountRepository;
        }

        public IDiscount CreateDiscount(int customerId, ProductToOrder product)
        {
            var customerDiscounts = _customerRepository.GetDiscountTypesForCustomer(customerId);
            var discountTypesDictionary = _discountRepository.GetDiscountsDictionary();

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
    }
}
