namespace _1.Modeling
{
    public class School
    {
        public School()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
            this.Parents = new List<Parent>();
        }

        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Parent> Parents { get; set; }
    }
}
