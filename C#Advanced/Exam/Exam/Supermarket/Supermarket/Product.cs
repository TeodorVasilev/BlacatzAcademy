namespace Supermarket
{
    public class Product
    {
        public Product(string name, decimal price, int quantity, DateTime deadline, Category category)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Deadline = deadline;
            this.Category = category;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Deadline { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - Price: {this.Price}$ - Quantity: {this.Quantity} - Deadline: {this.Deadline} - Category: {this.Category.Name}";
        }
    }
}
