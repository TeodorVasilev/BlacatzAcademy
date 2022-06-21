using _06.Flowers;

List<Flower> flowers = new List<Flower>();
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] inputParameters = Console.ReadLine().Split(", ");
    Flower flower = new Flower(inputParameters[1], int.Parse(inputParameters[0]));
    flowers.Add(flower);
}

for (int i = 0; i < flowers.Count; i++)
{
    Gardener.WaterFlower(flowers[i]);
    flowers[i].PrintInfo();
}