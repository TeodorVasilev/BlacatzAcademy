using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class CarAdComfort
    {
        public int Id { get; set; }
        public int CarAdId { get; set; }
        public Listing CarAd { get; set; }
        public int ComfortId { get; set; }
        public Comfort Comfort { get; set; }
    }
}
