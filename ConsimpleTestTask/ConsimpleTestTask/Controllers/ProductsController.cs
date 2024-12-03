using ConsimpleTestTask.Models.Products;
using ConsimpleTestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsimpleTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        public IProductService ProductService { get; }

        [HttpPost(Name = "CreateProduct")]
        public async Task<Product> CreateProduct(string name, string category, string article, int price)
        {
            return await ProductService.CreateProductAsync(name, category, article, price);
        }
    }
}