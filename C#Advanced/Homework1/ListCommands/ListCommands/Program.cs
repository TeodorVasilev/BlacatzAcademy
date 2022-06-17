string input = Console.ReadLine();

List<int> numbers = new List<int>();

while (input.ToLower() != "end")
{
    string[] splited = input.Split();

    string command = splited[0];
    int number = int.Parse(splited[1]);

    if (command.ToLower() == "add")
    {
        numbers.Add(number);
    }
    else if (command.ToLower() == "remove")
    {
        if (numbers.Contains(number))
        {
            while (numbers.Contains(number))
            {
                numbers.Remove(number);
            }
        }
        else
        {
            int smallestDif = int.MaxValue;
            int index = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < number)
                {
                    int diff = number - numbers[i];
                    if (diff < smallestDif)
                    {
                        smallestDif = diff;
                        index = i;
                    }
                }
            }

            numbers.RemoveAt(index);
        }
    }

    input = Console.ReadLine();
}

Console.WriteLine(string.Join(", ", numbers));