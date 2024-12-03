using System.Collections.Immutable;
using ConsimpleTestTask.Kernel;
using ConsimpleTestTask.Models.Clients;
using ConsimpleTestTask.Models.Products;
using ConsimpleTestTask.Models.Purchase;

namespace ConsimpleTestTask.Services
{
    public interface IClientService{
        /// <summary>
        /// Create new client with specified name and birthday
        /// </summary>
        /// <param name="name">Name of client</param>
        /// <param name="birthDate">Birth date of client</param>
        Task<Client> CreateClientAsync(string name, DateTimeOffset birthDate);

        /// <summary>
        /// Get all clients with todays birthday
        /// </summary>
        IImmutableList<Client> GetClientsWithTodayBirthday();

        /// <summary>
        /// Get clients that make purchaces last several days
        /// </summary>
        IImmutableList<Client> GetLastBuyers(int daysRange);

        /// <summary>
        /// Get client purchase categories
        /// </summary>
        /// <param name="clientId">Id of client</param>
        IImmutableList<string> GetBuyerCategories(Guid clientId);

        Client GetClient(Guid guid);
    }
    public class ClientService : IClientService
    {
        public ClientService(ConsimpleTestTaskContext dbContext)
        {
            DbContext = dbContext;
        }

        public ConsimpleTestTaskContext DbContext { get; }

        public async Task<Client> CreateClientAsync(string name, DateTimeOffset birthDate)
        {
            var client = new Client(
                name,
                birthDate,
                 DateTimeOffset.UtcNow);
            DbContext.Set<Client>().Add(client);
            await DbContext.SaveChangesAsync();
            return client;
        }

        public IImmutableList<string> GetBuyerCategories(Guid clientId)
        {
            return DbContext.Set<Purchase>()
            .Where(p => p.Client.Id == clientId)
            .SelectMany(p => p.Positions.Select(pos => pos.Product.Category))
            .Distinct()
            .ToImmutableList();
        }

        public Client GetClient(Guid guid)
        {
            return DbContext.Set<Client>().Single(p => p.Id == guid);
        }

        public IImmutableList<Client> GetClientsWithTodayBirthday()
        {
            return DbContext.Set<Client>().Where(c => c.BirthDate.DayOfYear == DateTimeOffset.UtcNow.DayOfYear).ToImmutableList();
        }

        public IImmutableList<Client> GetLastBuyers(int daysRange)
        {
            return DbContext.Set<Purchase>()
            .Where(p => p.Date.AddDays(daysRange).CompareTo(DateTimeOffset.UtcNow) >= 0)
            .Select(p => p.Client)
            .Distinct()
            .ToImmutableList();
        }
    }
}