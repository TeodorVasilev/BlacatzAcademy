using SortStudents;

List<Student> students = new List<Student>()
{
    new Student("Pesho", 2),
    new Student("Pesho", 6),
    new Student("Pesho", 3),
    new Student("Pesho", 4),
};

var ordered = students.OrderBy(p => p.Grade).ToList();

foreach (var student in ordered)
{
    Console.WriteLine(student.ToString());
}
