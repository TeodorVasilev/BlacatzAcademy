namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class CarAdSecurity
    {
        public int Id { get; set; }
        public int CarAdId { get; set; }
        public CarAd CarAd { get; set; }
        public int SecurityId { get; set; }
        public Security Security { get; set; }
    }
}
