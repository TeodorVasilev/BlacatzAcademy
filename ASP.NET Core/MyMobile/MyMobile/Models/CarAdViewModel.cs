using MyMobile.DAL.Models.CarAd;

namespace MyMobile.Models
{
    public class CarAdViewModel
    {
        public CarAdViewModel()
        {
            this.CarAds = new List<CarAd>();
        }

        public List<CarAd> CarAds { get; set; }

        public CarAd CarAd { get; set; }
    }
}
