namespace _03.Student
{
    public class Student
    {
        public Student(string facultyNumber, string name)
        {
            this.FacultyNumber = facultyNumber;
            this.Name = name;
        }

        public string FacultyNumber { get; set; }
        public string Name { get; set; }
    }
}
