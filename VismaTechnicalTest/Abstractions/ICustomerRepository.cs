using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Abstractions
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomers();
        public Customer? GetCustomerById(int id);
        public List<DiscountType> GetDiscountTypesForCustomer(Customer customer);
    }
}
