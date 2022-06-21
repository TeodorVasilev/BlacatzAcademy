namespace _5.Muffin
{
    public class Bakery
    {
        public Bakery()
        {
            this.Muffins = new List<Muffin>();
        }

        public List<Muffin> Muffins { get; set; }

        public void Order(string name,decimal price)
        {
            Muffin m = new Muffin(name, price);
            this.Muffins.Add(m);
        }

        public void PrintOrders()
        {
            Console.WriteLine("Bakery info:");
            foreach (Muffin m in Muffins)
            {
                m.PrintInfo();  
            }
        }
    }
}
