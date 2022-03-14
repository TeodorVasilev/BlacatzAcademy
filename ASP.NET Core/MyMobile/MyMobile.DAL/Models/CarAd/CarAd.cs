using MyMobile.DAL.Interfaces.Models;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Models.CarAd
{
    public class CarAd : IEntityWithId
    {
        public int Id { get; set; }
        //NAME = Make.Name + Model.Name + Engine.Modification
        public string Name { get; set; }
        public string Modification { get; set; }
        public int HorsePower { get; set; }
        public int Mileage { get; set; }
        public decimal DefaultPriceBgn { get; set; }
        public decimal UserPrice { get; set; }
        public int ManufactureMonth { get; set; } //
        public int ManufactureYear { get; set; } //
        public DateTime DateAdded { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ConditionId { get; set; }
        public Condition Condition { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int TownId { get; set; }
        public Town Town { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int EngineId { get; set; }
        public Engine Engine { get; set; }
        public int EurostandardId { get; set; }
        public Eurostandard Eurostandard { get; set; }
        public int GearboxId { get; set; }
        public Gearbox Gearbox { get; set; }
        public int VehicleCategoryId { get; set; }
        public VehicleCategory VehicleCategory { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }

        public ICollection<CarAdInterior> CarAdInteriors { get; set; }
        public ICollection<CarAdComfort> CarAdComforts { get; set; }
        public ICollection<CarAdSecurity> CarAdSecurities { get; set; }
    }
}
