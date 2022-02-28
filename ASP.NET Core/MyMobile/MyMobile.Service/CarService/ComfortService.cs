using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Service.CarService
{
    public class ComfortService
    {
        public List<Comfort> GetComforts()
        {
            var comforts = new List<Comfort>();

            using (var context = new MyMobileContext())
            {
                comforts = context.Comforts.ToList();
            }

            return comforts;
        }
    }
}
