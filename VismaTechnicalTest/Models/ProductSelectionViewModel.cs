using VismaTechnicalTest.Common;

namespace VismaTechnicalTest.Models
{
    public class ProductSelectionViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<ProductToOrder> ProductsToOrder { get; set; } = new();
        public List<DiscountType> AvailableDiscounts { get; set; }

        public static readonly Dictionary<DiscountType, string> DiscountMessages = new()
        {
            { DiscountType.VOLUME, $"Volume discount: {Math.Round(Constants.VolumeDiscountRate*100, 1)}% discount applied for at least {Constants.MinimumVolumeForDiscount} products of the same type. " },
            { DiscountType.SEASONAL, $"Seasonal discount: {Math.Round(Constants.SeasonalDiscountRate*100, 1)}% discount applied for all products."},
            { DiscountType.SPECIAL_DEAL, "Special deals discount: see product details."},
            { DiscountType.LOYALTY, $"Loyalty discount: {Math.Round(Constants.LoyaltyDiscountRate*100, 1)}% discount applied for all products." }
        };

        public string GetDiscountMessage(DiscountType discountType)
        {
            return DiscountMessages.TryGetValue(discountType, out var message) ? message : discountType.ToString();
        }
    }
}
