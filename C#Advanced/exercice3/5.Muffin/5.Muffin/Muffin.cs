namespace _5.Muffin
{
    public class Muffin
    {
        public Muffin(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public decimal Price  { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"{this.Name} - {this.Price}");
        }
    }
}
