using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }
        public ICollection<Listing> CarAds { get; set; }
    }
}
