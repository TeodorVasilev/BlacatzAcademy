using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using Microsoft.EntityFrameworkCore;

namespace MyMobile.Service.CarAdService
{
    public class CarAdService
    {
        public void Create(CarAd ad)
        {
            using (var context = new MyMobileContext())
            {
                ad.DefaultPriceBgn = CalculateDefaultPrice(ad.CurrencyId, ad.UserPrice);
                ad.Name = SetName(ad.MakeId, ad.ModelId);
                context.CarAds.Add(ad);
                context.SaveChanges();
            }
        }

        public void Update(int id)
        {
            //to do
        }

        public void Delete(int id)
        {
            using (var context = new MyMobileContext())
            {
                var carAd = context.CarAds.FirstOrDefault(c => c.Id == id);

                context.CarAds.Remove(carAd);
            }
        }

        public List<CarAd> GetCarAds()
        {
            var carAds = new List<CarAd>();

            using (var context = new MyMobileContext())
            {
                carAds = context.CarAds
                    .Include(c => c.Category)
                    .Include(c => c.Condition)
                    .Include(c => c.Currency)
                    .Include(c => c.Region)
                    .Include(c => c.Town)
                    .ToList();
            }

            return carAds;
        }

        public string SetName(int makeId, int modelId)
        {
            var makeName = "";
            var modelName = "";

            using (var context = new MyMobileContext())
            {
                makeName = context.Makes.Where(m => m.Id == makeId).FirstOrDefault().Name;
                modelName = context.Models.Where(m => m.Id == modelId).FirstOrDefault().Name;
            }

            var adName = $"{makeName} {modelName}";

            return adName;
        }

        public decimal CalculateDefaultPrice(int currencyId, decimal userPrice)
        {
            var currency = new Currency();

            using (var context = new MyMobileContext())
            {
                currency = context.Currencies.FirstOrDefault(c => c.Id == currencyId);
            }

            decimal defaultPriceBgn = userPrice * currency.CourseToDefault;

            return defaultPriceBgn;
        }
    }
}
