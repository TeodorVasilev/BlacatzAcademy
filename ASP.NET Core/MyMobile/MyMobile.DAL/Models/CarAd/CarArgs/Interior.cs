namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class Interior
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CarAdInterior> CarAdInteriors { get; set; }
    }
}
