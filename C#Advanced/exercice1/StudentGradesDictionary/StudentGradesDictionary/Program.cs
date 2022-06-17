Dictionary<string, double> studentsGrades = new Dictionary<string, double>();

studentsGrades.Add("Pesho", 5.50);
studentsGrades.Add("Gosho", 4.50);
studentsGrades.Add("Tosho", 3);

foreach (var kvp in studentsGrades)
{
    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
}