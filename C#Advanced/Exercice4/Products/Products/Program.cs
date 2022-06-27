using Products;

List<Product> products = new List<Product>()
{
    new Product("Telefon", 500m),
    new Product("Televizor", 800m),
    new Product("Peralna", 300m),
    new Product("Hladilnqk", 700m),
    new Product("Computer", 1000m),
    new Product("Telefon", 1500m),
    new Product("Televizor", 1800m),
    new Product("Masa", 50m),
};

foreach (var product in products)
{
    Console.WriteLine(product.ToString());
}

var ordered = products.OrderBy(p => p.Name).ThenBy(p => p.Price).ToList();

Console.WriteLine("Ordered");
foreach (var product in ordered)
{
    Console.WriteLine(product.ToString());
}