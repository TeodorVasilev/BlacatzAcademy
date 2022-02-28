namespace MyMobile.DAL.Models.CarAd.CarArgs
{
    public class Comfort
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CarAdComfort> CarAdComforts { get;}
    }
}
