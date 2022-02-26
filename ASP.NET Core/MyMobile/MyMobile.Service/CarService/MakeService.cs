using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Service.CarService
{
    public class MakeService
    {
        public List<Make> GetMakes()
        {
            var makes = new List<Make>();

            using (var context = new MyMobileContext())
            {
                makes = context.Makes.ToList();
            }

            return makes;
        }
    }
}
