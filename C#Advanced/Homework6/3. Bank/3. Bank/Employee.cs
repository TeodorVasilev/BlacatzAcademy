namespace _3._Bank
{
    public class Employee
    {
        public Employee(string id, string name, string lastName, decimal salary, Enum role)
        {
            this.Id = id;
            this.Name = name; 
            this.LastName = lastName;
            this.Salary = salary;
            this.Role = role;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Enum Role { get; set; }
    }
}
