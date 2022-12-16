string[] names = new string[4] { "goSHo", "peSho", "toOho", "alexander" };

string[] names2 = names.Select(x => x[0].ToString().ToUpperInvariant() + x.Substring(1).ToLowerInvariant()).ToArray();

Console.WriteLine(String.Join(", ", names2));
