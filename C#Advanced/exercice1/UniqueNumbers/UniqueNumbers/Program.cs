HashSet<int> numbers = new HashSet<int>();

for (int i = 0; i < 10; i++)
{
    int number = int.Parse(Console.ReadLine());

    numbers.Add(number);    
}

Console.WriteLine(String.Join(", ", numbers));