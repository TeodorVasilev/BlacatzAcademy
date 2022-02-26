namespace MyMobile.DAL.Models.CarAd.CarAdArgs
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CarAd> CarAds { get; set; }
        public ICollection<Town> Towns { get; set; }
    }
}
