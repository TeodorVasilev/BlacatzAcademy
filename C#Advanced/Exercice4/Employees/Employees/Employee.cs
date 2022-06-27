namespace Employees
{
    public class Employee
    {
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {this.Salary}";
        }
    }
}
