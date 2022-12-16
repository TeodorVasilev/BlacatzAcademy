namespace Supermarket
{
    public class Category
    {
        public Category(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
