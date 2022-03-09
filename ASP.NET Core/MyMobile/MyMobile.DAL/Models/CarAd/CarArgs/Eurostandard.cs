namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class Eurostandard
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CarAd> CarAds { get; set; }
    }
}
