namespace _1._CRUD
{
    public class Pizza
    {
        public Pizza(string name, decimal price, int quantity, List<string> ingredients)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Ingredients = ingredients;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
