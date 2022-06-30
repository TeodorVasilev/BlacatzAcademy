namespace _02.Fuel
{
    public class Fuel
    {
        public Fuel(string type, decimal price)
        {
            this.Type = type;
            this.Price = price;
        }

        public string Type { get; set; }

        public decimal Price { get; set; }
    }
}
