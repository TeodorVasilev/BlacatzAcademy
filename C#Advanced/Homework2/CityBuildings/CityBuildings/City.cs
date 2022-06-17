namespace CityBuildings
{
    public class City
    {
        public City()
        {
            this.Buildings = new List<Building>();
        }

        public List<Building> Buildings { get; set; }
    }
}
