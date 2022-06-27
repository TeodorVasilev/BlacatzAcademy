namespace Products
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price:f2}";
        }
    }
}
