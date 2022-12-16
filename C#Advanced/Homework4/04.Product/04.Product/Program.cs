using _04.Product;

List<Product> products = new List<Product>();

products.Add(new Product("Product1", 10));
products.Add(new Product("Product2", 5));
products.Add(new Product("Product3", 0));
products.Add(new Product("Product4", 8));
products.Add(new Product("Product5", 0));
products.Add(new Product("Product6", 0));
products.Add(new Product("Product7", 18));
products.Add(new Product("Product8", 19));
products.Add(new Product("Product9", 156));

List<Product> outOfStock = GetOutOfStockProducts(products);

if(outOfStock.Count != 0)
{
    foreach (var product in outOfStock)
    {
        Console.WriteLine(product.Name);
    }
}
else
{
    Console.WriteLine("No products out of stock");
}

List<Product> GetOutOfStockProducts(List<Product> products)
{
    List<Product> outOfStock = products.Where(p => p.Quantity == 0).ToList();

    return outOfStock;
}