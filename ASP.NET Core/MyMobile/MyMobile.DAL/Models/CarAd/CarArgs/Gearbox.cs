using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class Gearbox
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Listing> CarAds { get; set; }
    }
}
