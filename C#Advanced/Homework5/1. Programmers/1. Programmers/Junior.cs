namespace _1._Programmers
{
    public class Junior : Intern
    {
        public Junior(string name, int age, string company, decimal salary) 
        : base(name, age)
        {
            this.Company = company;
            this.Salary = salary;
        }

        public string Company { get; set; }
        public decimal Salary { get; set; }
    }
}
