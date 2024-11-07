using VismaTechnicalTest.Abstractions;

namespace VismaTechnicalTest.Services.DiscountModels
{
    public class CompositeDiscount : IDiscount
    {
        public List<IDiscount> discounts = new();
        public void AddDiscount(IDiscount discount)
        {
            if (discount is not NoDiscount)
            {
                discounts.Add(discount);
            }
        }

        public decimal CalculatePrice(decimal price)
        {
            foreach (IDiscount discount in discounts)
                price = discount.CalculatePrice(price);

            return price;
        }
    }
}
