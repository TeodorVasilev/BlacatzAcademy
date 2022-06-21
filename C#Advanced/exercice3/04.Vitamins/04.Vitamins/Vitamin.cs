namespace _04.Vitamins
{
    public class Vitamin
    {
        public Vitamin(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
