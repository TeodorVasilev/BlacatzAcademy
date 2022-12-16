using _3._Bank;

var emp1 = new Employee("1", "pencho", "pavlov", 1000, Role.Banker);
var emp2 = new Employee("2", "vicho", "huligana", 2000, Role.InvestmentAnalyst);
var emp3 = new Employee("3", "kiro", "kirov", 3000, Role.LoanProcessor);
var emp4 = new Employee("4", "ivan", "ganev", 4000, Role.CreditAnalyst);

var bank = new Bank();

bank.Employees.Add(emp1);
bank.Employees.Add(emp2);
bank.Employees.Add(emp3);
bank.Employees.Add(emp4);

Console.WriteLine(bank.TotalSalary());
bank.EmployesList();