namespace _1.Modeling
{
    public class Parent : Person
    {
        public Parent(string name, int age) : base(name, age)
        {
            this.Students = new List<Student>();
        }

        public List<Student> Students { get; set; }
    }
}
