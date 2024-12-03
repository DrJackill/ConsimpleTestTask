using ConsimpleTestTask.Controllers;
using ConsimpleTestTask.Kernel;
using ConsimpleTestTask.Models.Purchase;

namespace ConsimpleTestTask.Services
{
    public interface IPurchasesService
    {
        /// <summary>
        /// Create new purchase with specified params
        /// </summary>
        /// <param name="clientId">Client id</param>
        /// <param name="products">List of pair values that represent position in check</param>
        Task<Purchase> CreatePurchaseAsync(Guid clientId, ProductPositionList products);
    }

    public class PurchasesService : IPurchasesService
    {
        public PurchasesService(ConsimpleTestTaskContext dbContext, IClientService clientService, IProductService productService)
        {
            DbContext = dbContext;
            ClientService = clientService;
            ProductService = productService;
        }

        public ConsimpleTestTaskContext DbContext { get; }
        public IClientService ClientService { get; }
        public IProductService ProductService { get; }

        public async Task<Purchase> CreatePurchaseAsync(Guid clientId, ProductPositionList products)
        {
            var client = ClientService.GetClient(clientId);
            var totalValue = 0;
            var positions = new List<Position>();
            foreach (var productPosition in products.ProductPosition){
                var product = ProductService.GetProduct(productPosition.ProductId);
                totalValue += product.Price * productPosition.ProductNumber;
                positions.Add(new Position(product, productPosition.ProductNumber));
            }
            var purchase = new Purchase(DateTimeOffset.UtcNow, totalValue, client, positions);
            DbContext.Set<Purchase>().Add(purchase);
            await DbContext.SaveChangesAsync();
            return purchase;
        }
    }
}