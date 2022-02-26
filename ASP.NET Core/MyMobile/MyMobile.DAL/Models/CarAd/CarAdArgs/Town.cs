namespace MyMobile.DAL.Models.CarAd.CarAdArgs
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<CarAd> CarAds { get; set; }
    }
}
