using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Models.ViewModels.Listings
{
    public class ListingViewModel
    {
        public ListingViewModel()
        {
            this.CarAds = new List<Listing>();
        }

        public List<Listing> CarAds { get; set; }

        public Listing Listing { get; set; }
        public double TotalPages { get; set; }
    }
}
