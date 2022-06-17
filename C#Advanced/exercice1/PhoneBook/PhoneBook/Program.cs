Dictionary<string, string> phoneBook = new Dictionary<string, string>();

for (int i = 0; i < 3; i++)
{
    string name = Console.ReadLine();
    string phone = Console.ReadLine();

    phoneBook.Add(name, phone);
}

Console.WriteLine(string.Join(",", phoneBook));