namespace VismaTechnicalTest.Models
{
    public class ProductToOrder : Product
    {
        public int Quantity { get; set; }
        public ProductToOrder(int Id, string Name, decimal StandardPrice, bool HasSpecialDiscount, int Quantity, decimal SpecialDiscount = 0) : base(Id, Name, StandardPrice, HasSpecialDiscount, SpecialDiscount)
        {
            this.Quantity = Quantity;
        }
    }
}
