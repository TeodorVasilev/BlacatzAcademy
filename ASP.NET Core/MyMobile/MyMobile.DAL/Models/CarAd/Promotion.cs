namespace MyMobile.DAL.Models.CarAd.CarAdArgs
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Listing> CarAds { get; set; }
    }
}
