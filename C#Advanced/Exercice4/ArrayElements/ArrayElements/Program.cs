int[] numbers = new int[10] { 1, 2 ,2 ,4 ,5 ,6 ,7 ,2 ,9 ,10 };

int input = int.Parse(Console.ReadLine());

int numCnt = numbers.Where(x => x == input).Count();

Console.WriteLine(numCnt);