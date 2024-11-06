namespace VismaTechnicalTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal StandardPrice { get; set; }
        public bool HasSpecialDiscount { get; set; }
        public decimal SpecialDiscount { get; set; }

        public Product(int Id, string Name, decimal StandardPrice, bool HasSpecialDiscount, decimal SpecialDiscount = 0)
        {
            this.Id = Id;
            this.Name = Name;
            this.StandardPrice = StandardPrice;
            this.HasSpecialDiscount = HasSpecialDiscount;
            this.SpecialDiscount = SpecialDiscount;
        }
    }
}
