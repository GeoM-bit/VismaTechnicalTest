namespace VismaTechnicalTest.Models
{
    public class ProductToOrder : Product
    {
        public int Quantity { get; set; }
        public decimal DiscountedPrice { get; set; }

        public ProductToOrder() : base() { }
    }
}
