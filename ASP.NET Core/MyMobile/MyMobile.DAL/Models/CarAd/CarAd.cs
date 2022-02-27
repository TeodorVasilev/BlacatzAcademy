using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.DAL.Models.CarAd
{
    public class CarAd
    {
        public int Id { get; set; }
        //NAME = Make.Name + Model.Name + Engine.Modification
        public string Name { get; set; }
        public string Modification { get; set; }
        public int HorsePower { get; set; }
        public int Mileage { get; set; }
        public decimal DefaultPriceBgn { get; set; }
        public decimal UserPrice { get; set; }

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
    }
}
