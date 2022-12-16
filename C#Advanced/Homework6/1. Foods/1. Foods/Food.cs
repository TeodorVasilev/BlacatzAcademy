namespace _1._Foods
{
    public abstract class Food
    {
        public Food(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Energy { get; set; }

        public abstract double GetEnergy();
    }
}
