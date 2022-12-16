namespace _1.Modeling
{
    public class Student : Person
    {
        public Student(string name, int age, string studyClass) : base(name, age)
        {
            this.StudyClass = studyClass;
            this.Grades = new List<Grade>();
        }

        public string StudyClass { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
