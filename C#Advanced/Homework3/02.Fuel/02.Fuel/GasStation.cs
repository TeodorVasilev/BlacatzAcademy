namespace _02.Fuel
{
    public class GasStation
    {
        public GasStation(string name)
        {
            this.Fuels = new List<Fuel>();
            this.Name = name;
        }

        public string Name { get; set; }
        public List<Fuel> Fuels { get; set; }
    }
}
