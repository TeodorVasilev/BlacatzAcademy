namespace _06.Flowers
{
    public class Flower
    {
        public Flower(string name, int water)
        {
            this.Name = name;
            this.Water = water;
        }

        public int Water { get; set; }
        public string Name { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"{this.Name} - {this.Water}");
        }
    }
}
