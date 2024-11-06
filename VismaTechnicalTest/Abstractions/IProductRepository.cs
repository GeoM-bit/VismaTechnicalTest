using VismaTechnicalTest.Models;

namespace VismaTechnicalTest.Abstractions
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
    }
}
