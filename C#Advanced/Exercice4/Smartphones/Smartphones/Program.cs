using Smartphones;

List<Smartphone> smartphones = new List<Smartphone>() 
{
    new Smartphone("Nokia", 30, 1),
    new Smartphone("Samsung", 100, 4),
    new Smartphone("Motorola", 20, 1),
    new Smartphone("Huawei", 50, 2),
    new Smartphone("Iphone", 200, 4),
    new Smartphone("Alcatel", 80, 3),
    new Smartphone("Xiomi", 550, 2),
};

string[] data = Console.ReadLine().Split(", ");

decimal minPrice = decimal.Parse(data[0]);
decimal maxPrice = decimal.Parse(data[1]);
double minRam = double.Parse(data[2]);

List<Smartphone> filtered = smartphones.Where(x => x.Price >= minPrice && x.Price <= maxPrice && x.Ram >= minRam).ToList();

foreach (var item in filtered)
{
    Console.WriteLine(item.Brand);
}