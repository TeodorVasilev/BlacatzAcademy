namespace MyMobile.DAL.Models.CarAd.CarAdArgs
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Listing> CarAds { get; set; }
        public ICollection<Town> Towns { get; set; }
    }
}
