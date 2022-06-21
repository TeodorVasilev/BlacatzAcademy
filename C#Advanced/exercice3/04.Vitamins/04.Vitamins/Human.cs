namespace _04.Vitamins
{
    public class Human
    {
        public Human(string name)
        {
            this.Name = name;
            this.Vitamins = new List<Vitamin>(); 
        }

        public string Name { get; set; }
        public List<Vitamin> Vitamins { get; set; }
    }
}
