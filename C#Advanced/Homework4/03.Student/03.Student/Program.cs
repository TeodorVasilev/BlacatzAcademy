using _03.Student;

List<Student> students = new List<Student>();

students.Add(new Student("1", "Pesho1"));
students.Add(new Student("2", "Pesho2"));
students.Add(new Student("3", "Pesho3"));
students.Add(new Student("4", "Pesho4"));
students.Add(new Student("5", "Pesho5"));

Student student = FindStudent(Console.ReadLine(), students);

if(student != null)
{
    Console.WriteLine(student.Name);
}
else
{
    Console.WriteLine("No student with this number");
}

Student FindStudent(string facultyNumber, List<Student> students)
{
    return students.Find(x => x.FacultyNumber == facultyNumber); 
}