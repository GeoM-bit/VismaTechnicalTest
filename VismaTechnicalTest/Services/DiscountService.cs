using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DiscountCreator _discountCreator;

        public DiscountService(ICustomerRepository customerRepository, IDiscountRepository discountRepository)
        {
            _discountCreator = new DiscountCreator(customerRepository, discountRepository);
        }

        public decimal CalculatePrice(Customer customer, ProductToOrder product)
        {
            IDiscount discountCalculator = _discountCreator.CreateDiscount(customer, product);
            return discountCalculator.CalculatePrice(product.StandardPrice);              
        }

    }
}
