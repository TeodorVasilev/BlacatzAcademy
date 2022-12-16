namespace _1._Programmers
{
    public class Intern
    { 
        public Intern(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Knowledge = new List<string>();
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Knowledge { get; set; }
    }
}
