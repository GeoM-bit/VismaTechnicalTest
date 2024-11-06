using VismaTechnicalTest.Abstractions;

namespace VismaTechnicalTest.Services.DiscountModels
{
    public class CompositeDiscount : IDiscount
    {
        public List<IDiscount> _discounts = new();
        public void AddDiscount(IDiscount discount)
        {
            if (discount is not NoDiscount)
            {
                _discounts.Add(discount);
            }
        }

        public decimal CalculatePrice(decimal price)
        {
            foreach (IDiscount discount in _discounts)
                price = discount.CalculatePrice(price);

            return price;
        }
    }
}
