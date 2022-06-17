using CatObjects;

Cat cat = new Cat();

cat.Name = Console.ReadLine();
cat.Age = int.Parse(Console.ReadLine());
cat.Color = Console.ReadLine();

Console.WriteLine(cat.Name);
Console.WriteLine(cat.Age);
Console.WriteLine(cat.Color);