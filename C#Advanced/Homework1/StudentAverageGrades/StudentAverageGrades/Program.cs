using StudentAverageGrades;

Console.WriteLine("Enter number of students:");
int n = int.Parse(Console.ReadLine());

List<Student> students = new List<Student>();


Console.WriteLine("Enter student,grade");
for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    string[] data = input.Split(",");

    string name = data[0];
    double grade = double.Parse(data[1]);

    Student student = new Student(); 

    student.Name = name;
    student.Grade = grade;

    students.Add(student);
}

students = students.OrderByDescending(student => student.Grade).ToList();

foreach (var student in students)
{
    Console.WriteLine($"{student.Name} - {student.Grade}");
}

Console.WriteLine($"Average: {students.Average(x => x.Grade)}");