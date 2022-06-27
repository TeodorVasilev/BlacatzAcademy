namespace SortStudents
{
    public class Student
    {
        public Student(string name, double grade)
        {
            this.Name = name;
            this.Grade = grade;
        }

        public string Name { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Grade}";
        }
    }
}
