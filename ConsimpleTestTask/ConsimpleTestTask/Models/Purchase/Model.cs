using ConsimpleTestTask.Models.Clients;
using ConsimpleTestTask.Models.Products;

namespace ConsimpleTestTask.Models.Purchase
{
    public class Purchase
    {
        public Purchase(DateTimeOffset date, int totalValue, Client client, IEnumerable<Position> positions)
        :this(date, totalValue)
        {
            Positions = positions;
            Client = client;
        }
        private Purchase(DateTimeOffset date, int totalValue)
        {
            Date = date;
            TotalValue = totalValue;
        }

        public Guid Id { get; set; }
        public DateTimeOffset Date { get; }
        public int TotalValue { get; }
        public Client Client { get; }
        public IEnumerable<Position> Positions { get; }
    }

    public class Position
    {
        public Position(Product product, int productNumber)
        : this(productNumber)
        {
            Product = product;
        }

        private Position(int productNumber){
            ProductNumber = productNumber;
        }

        public Guid Id { get; set; }
        
        public Product Product { get; }
        public int ProductNumber { get; }
    }
}