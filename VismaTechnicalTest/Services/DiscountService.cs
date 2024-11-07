using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountCreator _discountCreator;

        public DiscountService(IDiscountCreator discountCreator)
        {
            _discountCreator = discountCreator;
        }

        public decimal CalculatePrice(int customerId, ProductToOrder product)
        {
            IDiscount discountCalculator = _discountCreator.CreateDiscount(customerId, product);

            return discountCalculator.CalculatePrice(product.StandardPrice);              
        }
    }
}
