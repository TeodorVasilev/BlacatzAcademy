using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Models.ViewModels.Listings
{
    public class PromoteViewModel
    {
        public int ListingId { get; set; }
        public int PromotionId { get; set; }
        public List<Promotion> Promotions { get; set; }
    }
}
