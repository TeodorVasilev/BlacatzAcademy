namespace _3._Bank
{
    public class Bank
    {
        public Bank()
        {
            this.Employees = new List<Employee>();
        }

        public List<Employee> Employees { get; set; }

        public decimal TotalSalary()
        {
            decimal total = 0;

            foreach (var employee in this.Employees)
            {
                total += employee.Salary;
            }

            return total;
        }

        public void EmployesList()
        {
            foreach (var employee in this.Employees)
            {
                Console.WriteLine($"{employee.Name} {employee.LastName}");
            }
        }
    }
}
