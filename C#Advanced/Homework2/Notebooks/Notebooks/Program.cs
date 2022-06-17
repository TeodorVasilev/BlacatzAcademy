using Notebooks;

Notebook nb = new Notebook();
nb.Write("Hello", 1);
Console.WriteLine(nb.Read(1));