namespace Smartphones
{
    public class Smartphone
    {
        public Smartphone(string brand, decimal Price, double Ram)
        {
            this.Brand = brand;
            this.Price = Price;
            this.Ram = Ram;
        }

        public string Brand { get; set; }
        public decimal Price { get; set; }
        public double Ram { get; set; }
    }
}
