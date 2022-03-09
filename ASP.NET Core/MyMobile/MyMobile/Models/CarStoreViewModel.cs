namespace MyMobile.Models
{
    public class CarStoreViewModel
    {
        public string Modification { get; set; }
        public int Mileage { get; set; }
        public int HorsePower { get; set; }
        public decimal UserPrice { get; set; }
        public int ManufactureMonth { get; set; }
        public int ManufactureYear { get; set; }
        public int CategoryId { get; set; }
        public int ConditionId { get; set; }
        public int CurrencyId { get; set; }
        public int RegionId { get; set; }
        public int TownId { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int VehicleCategoryId { get; set; }
        public int EngineId { get; set; }
        public int EurostandardId { get; set; }
        public int GearboxId { get; set; }
        public int ColorId { get; set; }
        public ICollection<int> CarAdInteriors { get; set; }
        public ICollection<int> CarAdComforts { get; set; }
        public ICollection<int> CarAdSecurities { get; set; }
    }
}
