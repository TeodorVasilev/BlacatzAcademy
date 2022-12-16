namespace Supermarket
{
    public class Employee
    {
        public Employee(string firstName, string lastName, string position, decimal salary, int yearsServed)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
            this.Salary = salary;
            this.YearsServed = yearsServed;
            this.Tasks = new List<EmployeeTask>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int YearsServed { get; set; }
        public List<EmployeeTask> Tasks { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}, {this.Position}, Salary: {this.Salary}$, Years served: {this.YearsServed}";
        }
    }
}
