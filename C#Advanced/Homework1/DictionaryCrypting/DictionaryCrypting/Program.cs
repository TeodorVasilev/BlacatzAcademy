Dictionary<string, int> letterCode = new Dictionary<string, int>();

for (int i = 0; i <= 255; i++)
{
    string key = ((char)i).ToString();

    if (!letterCode.ContainsKey(key))
    {
        letterCode.Add(key, i);
    }
}

Dictionary<int, string> codeLetter = new Dictionary<int, string>();

for (int i = 0; i <= 255; i++)
{
    string value = ((char)i).ToString();

    if (!codeLetter.ContainsKey(i))
    {
        codeLetter.Add(i, value);
    }
}

Console.WriteLine("1. Encrypt and send message");
Console.WriteLine("2. Decrypt message");

string input = Console.ReadLine();

if (input == "1")
{
    input = Console.ReadLine();

    List<int> encryptResult = new List<int>();
    for (int i = 0; i < input.Length; i++)
    {
        string key = input[i].ToString();
        key = key.ToUpper();
        if (letterCode.ContainsKey(key))
        {
            encryptResult.Add(letterCode[key]);
        }
    }

    Console.WriteLine(string.Join(" ", encryptResult));
}
else if (input == "2")
{
    input = Console.ReadLine();

    List<string> decryptResult = new List<string>();
    int[] numbers = input.Split().Select(int.Parse).ToArray();

    for (int i = 0; i < numbers.Length; i++)
    {
        if (codeLetter.ContainsKey(numbers[i]))
        {
            decryptResult.Add(codeLetter[numbers[i]]);
        }
    }

    Console.WriteLine(string.Join("", decryptResult));
}

