using Supermarket;
using System.Globalization;

var market = new Market();

ShowMenu();
string input = Console.ReadLine();

while (input != "exit")
{
    if (input == "1")
    {
        market.AddData();
    }
    else if (input == "2")
    {
        Client client = null;

        if (client == null)
        {
            client = LoginClient(market);
        }

        if(client != null)
        {
            while (true)
            {
                var category = SelectCategory(market);

                if (category != null)
                {
                    var clientProducts = SelectProducts(market, category);
                    client.Cart.AddRange(clientProducts);

                    if(client.Cart.Count == 0)
                    {
                        continue;
                    }

                    if(category != null)
                    {
                        continue;
                    }
                    else
                    {
                        Checkout(client);
                        break;
                    }
                }
                else
                {
                    Checkout(client);
                    break;
                }
            }
        }
    }
    else if(input == "3")
    {
        market.ShowEmployees();
    }
    else if(input == "4")
    {
        market.ShowEmployeeTasks();
    }
    else if(input == "5")
    {
        market.ShowClients();
    }
    else if (input == "6")
    {
        return;
    }

    ShowMenu();
    input = Console.ReadLine();
}

static Category SelectCategory(Market market)
{
    market.ShowCategories();

    Category category = null;

    while (category == null)
    {
        Console.WriteLine("Enter selected category name or type 'end' to go back");

        string input = Console.ReadLine();

        if (input == "end")
        {
            return null;
        }

        category = market.Categories.Where(c => c.Name == input).FirstOrDefault();

        if (category == null)
        {
            Console.WriteLine("Invalid category");
            continue;
        }
    }

    return category;
}

static List<Product> SelectProducts(Market market, Category category)
{
    market.ShowCategoryProducts(category);

    var products = new List<Product>();

    Console.WriteLine("Enter {Product Name},{Quantity} to add product to your cart or type 'end' to go back.");

    string input = Console.ReadLine();

    while (input != "end")
    {
        string[] inputArgs = input.Split(',');
        string productName = inputArgs[0];
        int productQuantity = int.Parse(inputArgs[1]);

        var product = market.Products.Where(p => p.Name == productName).FirstOrDefault();

        if(product.Quantity < productQuantity)
        {
            Console.WriteLine("Not enough quantity of this product try again");
            Console.WriteLine("Enter {Product Name},{Quantity} to add product to your cart or type 'end' to go back.");
            input = Console.ReadLine();
            continue;
        }
        else
        {
            var productToAdd = new Product(product.Name, product.Price, productQuantity, product.Deadline, product.Category);
            market.Products.Where(p => p.Name == productName).FirstOrDefault().Quantity -= productQuantity;
            products.Add(productToAdd);
            Console.WriteLine("Product successfully added to cart");
            Console.WriteLine("Enter {Product Name},{Quantity} to add product to your cart or type 'end' to go back.");
            input = Console.ReadLine();
            continue;
        }

        input = Console.ReadLine(); 
    }
         
    return products;
}

static Client LoginClient(Market market)
{
    Client client = null;

    while (client == null)
    {
        Console.WriteLine("Enter your client number or type 'end' to go back");
        string input = Console.ReadLine();

        if (input == "end")
        {
            return null;
        }

        client = market.Clients.Where(c => c.Id == input).FirstOrDefault();

        if (client == null)
        {
            Console.WriteLine("Invalid client number");
            continue;
        }

    }
    return client;
}

static void Checkout(Client client)
{
    if (client.Cart.Count != 0)
    {
        decimal price = 0;
        decimal discount = 0;

        foreach (var product in client.Cart)
        {
            price += product.Price * product.Quantity;
        }

        if (client.ClientCard != null)
        {
            discount = client.ClientCard.GetDiscount(price);
        }

        var totalPrice = price - (price * discount);
        Console.WriteLine($"Total price: {totalPrice:F2}$");
    }
}

static void ShowMenu()
{
    Console.WriteLine("1. Add data");
    Console.WriteLine("2. Buy products");
    Console.WriteLine("3. Show employees");
    Console.WriteLine("4. Show employees tasks");
    Console.WriteLine("5. Show clients");
    Console.WriteLine("6. Exit");
}
