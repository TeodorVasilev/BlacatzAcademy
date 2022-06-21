using _04.Vitamins;

int n = int.Parse(Console.ReadLine());

List<Human> humans = new List<Human>();
for (int i = 0; i < n; i++)
{
    string name = Console.ReadLine();
    humans.Add(new Human(name));
}
for (int i = 0; i < n; i++)
{
    List<Vitamin> vitamins = Console.ReadLine().Split(",").Select(vitaminName => new Vitamin(vitaminName)).ToList();
    humans[i].Vitamins = vitamins;
}

foreach (var human in humans)
{
    Console.Write(human.Name + " - ");
    Console.WriteLine(String.Join(", ", human.Vitamins));
}