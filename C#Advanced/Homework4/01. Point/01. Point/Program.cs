using _01._Point;

int[] numbers = new int[5] { 5, 7, 2, 9 ,4};

List<Point> points = numbers.Select(x => new Point(x, x * 2)).ToList();

foreach (var item in points)
{
    Console.WriteLine($"{item.X} - {item.Y}");
}