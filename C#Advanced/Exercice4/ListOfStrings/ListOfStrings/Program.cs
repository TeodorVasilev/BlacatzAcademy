List<string> strings = new List<string>() { "this", "is", "sample", "linq", "skip", "take" };

Console.WriteLine(String.Join(", ", strings));

var modified = strings.Skip(2).Select(x => x.ToUpper());

Console.WriteLine(String.Join(", ", modified));