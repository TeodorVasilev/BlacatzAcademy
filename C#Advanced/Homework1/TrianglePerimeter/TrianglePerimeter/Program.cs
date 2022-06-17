using TrianglePerimeter;

Console.WriteLine("Enter side A value:");
double a = double.Parse(Console.ReadLine());
Console.WriteLine("Enter side B value:");
double b = double.Parse(Console.ReadLine());
Console.WriteLine("Enter side C value:");
double c = double.Parse(Console.ReadLine());

Triangle triangle = new Triangle();

triangle.A = a;
triangle.B = b;
triangle.C = c;

Console.WriteLine("The perimeter of the triangle is:");
Console.WriteLine(triangle.GetPerimeter());