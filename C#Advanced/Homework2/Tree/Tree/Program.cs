using Trees;

string input = Console.ReadLine();

List<Tree> trees = new List<Tree>();

while (input != "end")
{
    string[] data = input.Split(',');

    string type = data[0];
    int age = int.Parse(data[1]);

    Tree tree = new Tree(type, age);

    trees.Add(tree);

    input = Console.ReadLine();
}

Console.WriteLine(trees.Count);