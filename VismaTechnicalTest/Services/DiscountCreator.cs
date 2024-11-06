using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;
using VismaTechnicalTest.Services.DiscountModels;

namespace VismaTechnicalTest.Services
{
    public class DiscountCreator
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDiscountRepository _discountRepository;
        public DiscountCreator(ICustomerRepository customerRepository, IDiscountRepository discountRepository)
        {
            _customerRepository = customerRepository;
            _discountRepository = discountRepository;
        }

        public IDiscount CreateDiscount(Customer customer, ProductToOrder product)
        {
            List<DiscountType> customerDiscounts = _customerRepository.GetDiscountTypesForCustomer(customer);
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
