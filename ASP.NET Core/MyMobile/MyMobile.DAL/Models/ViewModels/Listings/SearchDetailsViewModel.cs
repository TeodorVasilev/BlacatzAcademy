using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Models.ViewModels.Listings
{
    public class SearchDetailsViewModel
    {
        public int? ManufactureYear { get; set; }
        public Category? Category { get; set; }
        public Make? Make { get; set; }
        public Model? Model { get; set; }
        public Engine? Engine { get; set; }
        public Gearbox? Gearbox { get; set; }
        public Condition? Condition { get; set; }
        public Region? Region { get; set; }
        public Town? Town { get; set; }
    }
}
