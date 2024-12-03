using ConsimpleTestTask.Models.Clients;
using ConsimpleTestTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsimpleTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientController : ControllerBase
    {
        public ClientController(IClientService clientService)
        {
            ClientService = clientService;
        }

        public IClientService ClientService { get; }

        [HttpPost(Name = "CreateClient")]
        public async Task<Client> CreateClientAsync(string fullName, DateTimeOffset birthDate)
        {
            return await ClientService.CreateClientAsync(fullName, birthDate);
        }

        [HttpGet(Name = "GetBuyerCategories")]
        [ActionName("GetBuyerCategories")]
        public IEnumerable<string> GetBuyerCategories(Guid clientId)
        {
            return ClientService.GetBuyerCategories(clientId);
        }

        [HttpGet(Name = "GetClientsWithTodayBirthday")]
        [ActionName("GetClientsWithTodayBirthday")]
        public IEnumerable<Client> GetClientsWithTodayBirthday()
        {
            return ClientService.GetClientsWithTodayBirthday();
        }

        [HttpGet(Name = "GetLastBuyers")]
        [ActionName("GetLastBuyers")]
        public IEnumerable<Client> GetLastBuyers(int daysRange)
        {
            return ClientService.GetLastBuyers(daysRange);
        }

        [HttpGet(Name = "GetClient")]
        [ActionName("GetClient")]
        public Client GetClient(Guid clientId)
        {
            return ClientService.GetClient(clientId);
        }
    }
}