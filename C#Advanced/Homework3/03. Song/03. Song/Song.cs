namespace _03._Song
{
    public class Song
    {
        public Song(string name, double duration)
        {
            this.Name = name;
            this.Duration = duration;
        }

        public string Name { get; set; }
        public double Duration { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
