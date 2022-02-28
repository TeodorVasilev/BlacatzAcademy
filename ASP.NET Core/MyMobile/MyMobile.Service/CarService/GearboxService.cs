using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Service.CarService
{
    public class GearboxService
    {
        public List<Gearbox> GetGearboxes()
        {
            var gearboxes = new List<Gearbox>();

            using(var context = new MyMobileContext())
            {
                gearboxes = context.Gearboxes.ToList();
            }

            return gearboxes;
        }
    }
}
