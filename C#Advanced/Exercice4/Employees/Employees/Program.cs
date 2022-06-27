using Employees;

List<Employee> employees = new List<Employee>()
{
    new Employee("Pehso", 600),
    new Employee("Gosho", 1600),
    new Employee("Minka", 1200),
    new Employee("Penka", 1000)
};

employees.Sort((e1,e2) => (int)(e1.Salary - e2.Salary));

employees.ForEach(e => Console.WriteLine(e.ToString()));