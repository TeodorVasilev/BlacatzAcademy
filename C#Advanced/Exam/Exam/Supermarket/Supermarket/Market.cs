using System.Globalization;

namespace Supermarket
{
    public class Market
    {
        public Market()
        {
            this.Employees = new List<Employee>();
            this.Clients = new List<Client>();
            this.Categories = new List<Category>();
            this.Products = new List<Product>();
        }

        public List<Employee> Employees { get; set; }
        public List<Client> Clients { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

        public void ShowCategories()
        {
            for (int i = 0; i < this.Categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {this.Categories[i]}");
            }
        }
        public void ShowProducts()
        {
            for (int i = 0; i < this.Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {this.Products[i]}");
            }
        }
        public void ShowCategoryProducts(Category category)
        {
            var products = this.Products.Where(p => p.Category.Name == category.Name).ToList();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}");
            }
        }
        public void ShowEmployees()
        {
            for (int i = 0; i < this.Employees.Count; i++)
            {
                Console.WriteLine($"{i + 1}. - {Employees[i]}");
            }
        }
        public void ShowEmployeeTasks()
        {
            foreach (var employee in this.Employees)
            {
                Console.WriteLine($"{employee}");

                foreach (var task in employee.Tasks)
                {
                    Console.WriteLine($"-- {task}");
                }
            }
        }
        public void ShowClients()
        {
            for (int i = 0; i < this.Clients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {this.Clients[i]}");
            }
        }
        public void AddData()
        {

            Console.WriteLine("Add employees, tasks, clients, client cards, categories or products and type end to go back");

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputArgs = input.Split(',');
                string dataType = inputArgs[0];

                if (dataType == "Employee")
                {
                    var employee = new Employee(inputArgs[1], inputArgs[2], inputArgs[3], decimal.Parse(inputArgs[4]), int.Parse(inputArgs[5]));
                    this.Employees.Add(employee);
                    Console.WriteLine("Employee added");
                }
                else if (dataType == "Task")
                {
                    var task = new EmployeeTask(inputArgs[2], inputArgs[3], DateTime.ParseExact(inputArgs[4], "dd-MM-yyyy", CultureInfo.InvariantCulture));
                    var employee = this.Employees.Where(e => e.FirstName + " " + e.LastName == inputArgs[1]).FirstOrDefault();
                    if (employee != null)
                    {
                        employee.Tasks.Add(task);
                        Console.WriteLine("Task added");
                    }
                    else
                    {
                        Console.WriteLine("No such employee");
                    }
                }
                else if (dataType == "Client")
                {
                    var client = new Client(inputArgs[1], inputArgs[2], inputArgs[3]);
                    this.Clients.Add(client);
                    Console.WriteLine("Client added");
                }
                else if (dataType == "Card")
                {
                    var card = new ClientCard(inputArgs[1]);
                    var client = this.Clients.Where(c => c.Id == inputArgs[1]).FirstOrDefault();
                    if (client != null)
                    {
                        client.ClientCard = card;
                        Console.WriteLine("Card added");
                    }
                    else
                    {
                        Console.WriteLine("Invalid client number");
                    }
                }
                else if (dataType == "Category")
                {
                    var category = new Category(inputArgs[1]);
                    this.Categories.Add(category);
                    Console.WriteLine("Category added");
                }
                else if (dataType == "Product")
                {
                    var category = this.Categories.Where(c => c.Name == inputArgs[5]).FirstOrDefault();
                    if (category != null)
                    {
                        var product = new Product(inputArgs[1], decimal.Parse(inputArgs[2]), int.Parse(inputArgs[3]), DateTime.ParseExact(inputArgs[4], "dd-MM-yyyy", CultureInfo.InvariantCulture), category);
                        this.Products.Add(product);
                        Console.WriteLine("Product added");
                    }
                    else
                    {
                        Console.WriteLine("Invalid category");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
