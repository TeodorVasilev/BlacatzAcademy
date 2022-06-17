using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class CarAdInterior
    {
        public int Id { get; set; }

        public int CarAdId { get; set; }
        public Listing CarAd { get; set; }
        public int InteriorId { get; set; }
        public Interior Interior { get; set; }
    }
}
