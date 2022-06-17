class Movie
{
    public string name { get; set; }
    public int year { get; set; }
    public string author { get; set; }

    public void PrintInfo()
    {
        Console.WriteLine($"Movie: {this.name} - Year: {this.year} - {this.author}");
    }
}

class Program
{
    public static void Main()
    {
        List<Movie> movies = new List<Movie>();

        string input = Console.ReadLine();
        while(input != "end")
        {
            string[] inputParameters = input.Split(',');
            Movie movie = new Movie();

            movie.name = inputParameters[0];
            movie.year = int.Parse(inputParameters[1]);
            movie.author = inputParameters[2];

            movies.Add(movie);

            input = Console.ReadLine();
        }

        for (int i = 0; i < movies.Count; i++)
        {
            movies[i].PrintInfo();
        }
    }
}