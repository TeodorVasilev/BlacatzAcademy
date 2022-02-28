using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Service.CarService
{
    public class SecurityService
    {
        public List<Security> GetSecurities()
        {
            var securities = new List<Security>();

            using (var context = new MyMobileContext())
            {
                securities = context.Securities.ToList();
            }    

            return securities;
        }
    }
}
