int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

Console.WriteLine(String.Join(", ", nums.Distinct()));