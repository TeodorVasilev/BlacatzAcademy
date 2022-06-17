namespace Trees
{
    public class Tree
    {
        public Tree(string type, int age)
        {
            this.Type = type;
            this.Age = age;
        }

        public string Type { get; set; }
        public int Age { get; set; }
    }
}
