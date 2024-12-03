using ConsimpleTestTask.Kernel;
using ConsimpleTestTask.Models.Products;

namespace ConsimpleTestTask.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Create new product with specified params
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <param name="category">Category of product</param>
        /// <param name="article">Article of product</param>
        /// <param name="price">Price of product</param>
        Task<Product> CreateProductAsync(string name, string category, string article, int price);

        Product GetProduct(Guid guid);
    }

    public class ProductService : IProductService
    {
        public ProductService(ConsimpleTestTaskContext dbContext)
        {
            DbContext = dbContext;
        }

        public ConsimpleTestTaskContext DbContext { get; }

        public async Task<Product> CreateProductAsync(string name, string category, string article, int price)
        {
            var product = new Product(name, category, article, price);
            DbContext.Set<Product>().Add(product);
            await DbContext.SaveChangesAsync();
            return product;
        }

        public Product GetProduct(Guid guid)
        {
            return DbContext.Set<Product>().Single(p => p.Id == guid);
        }
    }
}