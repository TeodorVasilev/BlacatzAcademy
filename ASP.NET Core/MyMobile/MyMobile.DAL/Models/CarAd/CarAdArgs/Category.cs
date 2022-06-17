namespace MyMobile.DAL.Models.CarAd.CarAdArgs
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Listing> CarAds { get; set; }
    }
}
