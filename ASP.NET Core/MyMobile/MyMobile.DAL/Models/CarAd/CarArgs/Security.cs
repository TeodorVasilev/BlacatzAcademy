namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class Security
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CarAdSecurity> CarAdSecurities { get; set; }
    }
}
