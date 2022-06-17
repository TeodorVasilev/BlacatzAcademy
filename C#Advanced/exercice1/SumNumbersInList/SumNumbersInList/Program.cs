List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

Console.WriteLine(numbers.Sum());