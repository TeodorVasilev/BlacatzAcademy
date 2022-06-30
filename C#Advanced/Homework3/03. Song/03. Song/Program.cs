using _03._Song;

List<Song> songs = new List<Song>()
{
    new Song("Song 1", 3),
    new Song("Song 2", 3),
    new Song("Song 3", 3),
};

List<Author> authors = new List<Author>();

Author author = new Author("Author 1");
author.Songs = songs;
authors.Add(author);

Author author1 = new Author("Author 2");
author1.Songs = songs;
authors.Add(author1);

foreach (var item in authors)
{
    Console.WriteLine(item);
}