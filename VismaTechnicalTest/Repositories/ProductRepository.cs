using VismaTechnicalTest.Abstractions;
using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product(1,"Chair", 10, true, 0.015m),
                new Product(2,"Desk", 15, false),
                new Product(3,"Sideboard", 20, true, 0.03m),
                new Product(4,"Sofa", 25, false),
                new Product(5,"Table", 17, false)
            };
        }
    }
}
