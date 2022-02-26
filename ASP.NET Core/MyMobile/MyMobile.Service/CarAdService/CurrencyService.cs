using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.Service.CarAdService
{
    public class CurrencyService
    {
        public List<Currency> GetCurrencies()
        {
            var currencies = new List<Currency>();

            using (var context = new MyMobileContext())
            {
                currencies = context.Currencies.ToList();
            }

            return currencies;
        }
    }
}
