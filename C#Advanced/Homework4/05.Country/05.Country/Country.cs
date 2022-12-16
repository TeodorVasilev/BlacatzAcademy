namespace _05.Country
{
    public class Country
    {
        public Country(string name)
        {
            this.Name = name;
            this.Cities = new List<City>();
        }

        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
