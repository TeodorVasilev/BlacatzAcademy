using System.Text;

namespace _03._Song
{
    public class Author
    {
        public Author(string name)
        {
            this.Name = name;
            this.Songs = new List<Song>();
        }

        public string Name { get; set; }

        public List<Song> Songs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name}");
            foreach (Song song in this.Songs)
            {
                sb.AppendLine($"- {song.ToString()}");
            }

            return sb.ToString();
        }
    }
}
