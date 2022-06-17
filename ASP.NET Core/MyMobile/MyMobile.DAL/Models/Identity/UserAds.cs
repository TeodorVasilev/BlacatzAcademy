using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Models.Identity
{
    public class UserAds
    {
        public int Id { get; set; }
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int CarAdId { get; set; }
        public Listing CarAd { get; set; }
    }
}
