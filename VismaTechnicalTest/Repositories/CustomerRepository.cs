using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers = new List<Customer>()
            {
                new(1, "Adam Jones"),
                new(2, "Mary Corey"),
                new(3, "John Doe"),
                new(4, "Will Brandy")
            };

        public Customer? GetCustomerById(int id)
        {
            return customers.FirstOrDefault(x => x.Id == id);
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public List<DiscountType> GetDiscountTypesForCustomer(int id)
        {
            if (id == 1)
                return
                [
                    DiscountType.VOLUME,
                    DiscountType.SPECIAL_DEAL
                ];
            else if (id == 2)
                return
                [
                    DiscountType.SEASONAL
                ];
            else if (id == 3)
                return
                [
                    DiscountType.LOYALTY
                ];
            else return [];
        }
    }
}
