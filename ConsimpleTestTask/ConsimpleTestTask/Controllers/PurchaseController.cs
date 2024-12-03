using System.Collections.Immutable;
using ConsimpleTestTask.Models.Purchase;
using ConsimpleTestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsimpleTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseController : ControllerBase
    {
        public PurchaseController(IPurchasesService purchasesService)
        {
            PurchasesService = purchasesService;
        }

        public IPurchasesService PurchasesService { get; }

        [HttpPost(Name = "CreatePurchase")]
        public async Task<Purchase> CreatePurchase(Guid clientId, [FromBody] ProductPositionList productPositionList)
        {
            return await PurchasesService.CreatePurchaseAsync(clientId, productPositionList);
        }
    }

    public record ProductPositionList(IEnumerable<ProductPosition> ProductPosition);

    public record ProductPosition(Guid ProductId, int ProductNumber);
}