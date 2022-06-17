public class TV
{
    public string Make { get; set; }
    public string Model { get; set; }
    public double Screen { get; set; }
    public decimal Price { get; set; }

    public void PrintInfo()
    {
        Console.WriteLine($"{this.Make}, {this.Model}, {this.Screen}, {this.Price}");
    }
}

public class Program
{
    public static void Main()
    {
        TV tv = new TV();

        tv.Make = Console.ReadLine();
        tv.Model = Console.ReadLine();
        tv.Screen = double.Parse(Console.ReadLine());
        tv.Price = decimal.Parse(Console.ReadLine());

        tv.PrintInfo();
    }
}