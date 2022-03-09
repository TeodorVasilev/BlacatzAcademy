using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Service.CarService
{
    public class EurostandardService
    {
        public List<Eurostandard> GetEurostandards()
        {
            var eurostandards = new List<Eurostandard>();

            using (var context = new MyMobileContext())
            {
                eurostandards = context.Eurostandards.ToList();
            }

            return eurostandards;
        }
    }
}
