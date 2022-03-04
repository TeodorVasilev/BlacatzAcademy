using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Models
{
    public class CreateCarAdViewModel
    {
        public CreateCarAdViewModel()
        {
            this.Categories = new List<Category>();
            this.Conditions = new List<Condition>();
            this.Currencies = new List<Currency>();
            this.Regions = new List<Region>();
            this.Towns = new List<Town>(); //TODO from Region.Towns
            this.Makes = new List<Make>();
            this.Models = new List<Model>(); //TODO from Make.Models
            this.VehicleCategories = new List<VehicleCategory>();
            this.Engines = new List<Engine>();
            this.Gearboxes = new List<Gearbox>();
            this.Colors = new List<Color>();
            this.Interiors = new List<Interior>();
            this.Comforts = new List<Comfort>();
            this.ManufactureMonths = new List<int>();
            this.ManufactureYears = new List<int>();
        }

        public List<Category> Categories { get; set; }
        public List<Condition> Conditions { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<Region> Regions { get; set; }
        public List<Town> Towns { get; set; } //TODO from Region.Towns
        public List<Make> Makes { get; set; }
        public List<Model> Models { get; set; } //TODO from Make.Models
        public List<VehicleCategory> VehicleCategories { get; set; }
        public List<Engine> Engines { get; set; }
        public List<Gearbox> Gearboxes { get; set; }
        public List<Color> Colors { get; set; }
        public List<Interior> Interiors { get; set; }
        public List<Comfort> Comforts { get; set;}
        public List<Security> Securities { get; set; }
        public List<int> ManufactureMonths { get; set; } //
        public List<int> ManufactureYears { get; set; } //
    }
}
