namespace _04.Product
{
    public class Product
    {
        public Product(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
