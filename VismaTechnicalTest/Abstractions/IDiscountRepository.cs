using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Abstractions
{
    public interface IDiscountRepository
    {
        public Dictionary<DiscountType, Func<ProductToOrder, IDiscount>> GetDiscountsDictionary();
    }
}
