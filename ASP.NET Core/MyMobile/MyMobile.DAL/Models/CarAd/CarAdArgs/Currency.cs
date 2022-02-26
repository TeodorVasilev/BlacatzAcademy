namespace MyMobile.DAL.Models.CarAd.CarAdArgs
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CourseToDefault { get; set; }

        public ICollection<CarAd> CarAds { get; set; }
    }
}
