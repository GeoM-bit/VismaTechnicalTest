using VismaTechnicalTest.Common;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Abstractions
{
    public interface IDiscountProvider
    {
        public Dictionary<DiscountType, Func<ProductToOrder, IDiscount>> GetDiscountsDictionary();
    }
}
