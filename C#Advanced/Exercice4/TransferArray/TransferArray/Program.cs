int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
int[] even = arr.Where(x => x % 2 == 0).ToArray();

Console.WriteLine(String.Join(",", even));