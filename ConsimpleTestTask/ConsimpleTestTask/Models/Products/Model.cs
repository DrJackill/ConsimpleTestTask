namespace ConsimpleTestTask.Models.Products
{
    public class Product
    {
        public Product(string name, string category, string article, int price)
        {
            Name = name;
            Category = category;
            Article = article;
            Price = price;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Article { get; set; }

        public int Price { get; set; }
    }
}