using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MakeId { get; set; }
        public Make Make { get; set; }
        public ICollection<Listing> CarAds { get; set; }
    }
}
