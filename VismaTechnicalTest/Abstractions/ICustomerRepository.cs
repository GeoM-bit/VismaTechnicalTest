using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Abstractions
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomers();
        public List<DiscountType> GetDiscountTypesForCustomer(Customer customer);
    }
}
