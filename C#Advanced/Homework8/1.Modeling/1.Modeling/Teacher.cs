namespace _1.Modeling
{
    public class Teacher : Person
    {
        public Teacher(string name, int age, string specialty, Enum role) : base(name, age)
        {
            this.Specialty = specialty;
            this.Role = role;
            this.Courses = new List<string>();
            this.Students = new List<Student>();
        }

        public string Specialty { get; set; }
        public List<string> Courses { get; set; }
        public List<Student> Students { get; set; }
        public Enum Role { get; set; }
    }
}
