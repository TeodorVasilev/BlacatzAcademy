using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Service.CarService
{
    public class InteriorService
    {
        public List<Interior> GetInteriors()
        {
            var interiors = new List<Interior>();

            using (var context = new MyMobileContext())
            {
                interiors = context.Interiors.ToList();
            }

            return interiors;
        }
    }
}
