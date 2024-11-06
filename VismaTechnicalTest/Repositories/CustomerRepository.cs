using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new(1, "Adam Jones"),
                new(2, "Mary Corey"),
                new(3, "John Doe"),
                new(4, "Will Brandy")
            };
        }

        public List<DiscountType> GetDiscountTypesForCustomer(Customer customer)
        {
            if (customer.Id == 1)
                return
                [
                    DiscountType.VOLUME,
                    DiscountType.SPECIAL_DEAL
                ];
            else if (customer.Id == 2)
                return
                [
                    DiscountType.SEASONAL
                ];
            else if (customer.Id == 3)
                return
                [
                    DiscountType.LOYALTY
                ];
            else return [];
        }
    }
}
