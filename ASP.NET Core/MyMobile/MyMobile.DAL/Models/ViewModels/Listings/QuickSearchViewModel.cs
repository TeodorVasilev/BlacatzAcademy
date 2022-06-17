using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Models.ViewModels.Listings
{
    public class QuickSearchViewModel
    {
        public List<int> Years { get; set; }
        public List<Category> Categories { get; set; }
        public List<Make> Makes { get; set; }
        public List<Model> Models { get; set; }
        public List<Engine> Engines { get; set; }
        public List<Gearbox> Gearboxes { get; set; }
        public List<Condition> Conditions { get; set; }
        public List<Region> Regions { get; set; }
        public List<Town> Towns { get; set; }
        // result order
    }
}
