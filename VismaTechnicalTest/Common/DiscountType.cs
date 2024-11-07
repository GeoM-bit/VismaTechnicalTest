namespace VismaTechnicalTest.Common
{
    public enum DiscountType
    {
        VOLUME,
        SEASONAL,
        SPECIAL_DEAL,
        LOYALTY
    }

    public static class EnumExtensions
    {
        public static readonly Dictionary<DiscountType, string> discountMessages = new()
        {
            { DiscountType.VOLUME, $"Volume discount: {Math.Round(Constants.VolumeDiscountRate * 100, 1)}% discount applied for at least {Constants.MinimumVolumeForDiscount} products of the same type." },
            { DiscountType.SEASONAL, $"Seasonal discount: {Math.Round(Constants.SeasonalDiscountRate * 100, 1)}% discount applied for all products."},
            { DiscountType.SPECIAL_DEAL, "Special deals discount: see product details."},
            { DiscountType.LOYALTY, $"Loyalty discount: {Math.Round(Constants.LoyaltyDiscountRate * 100, 1)}% discount applied for all products." },
        };
        public static string GetDiscountMessage(this DiscountType value)
        {
            return discountMessages.TryGetValue(value, out string description) ? description : value.ToString();
        }
    }
}
