using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using Microsoft.EntityFrameworkCore;

namespace MyMobile.Service.CarAdService
{
    public class CarAdService
    {
        public CarAd GetCarAd(int id)
        {
            CarAd carAd = new CarAd();

            using(var context = new MyMobileContext())
            {
                carAd = context.CarAds.Where(ca => ca.Id == id)
                                      .Include(c => c.Category)
                                      .Include(c => c.Condition)
                                      .Include(c => c.Currency)
                                      .Include(c => c.Region)
                                      .Include(c => c.Town)
                                      .Include(c => c.Color)
                                      .Include(c => c.Engine)
                                      .Include(c => c.Eurostandard)
                                      .Include(c => c.Gearbox)
                                      .Include(c => c.VehicleCategory)
                                      .Include(c => c.CarAdComforts)
                                      .ThenInclude(e => e.Comfort)
                                      .Include(c => c.CarAdInteriors)
                                      .ThenInclude(e => e.Interior)
                                      .Include(c => c.CarAdSecurities)
                                      .ThenInclude(e => e.Security)
                                      .FirstOrDefault();
            }

            return carAd;
        }

        public void Create(CarAd ad)
        {
            using (var context = new MyMobileContext())
            {
                ad.DefaultPriceBgn = CalculateDefaultPrice(ad.CurrencyId, ad.UserPrice);
                ad.Name = SetName(ad.MakeId, ad.ModelId, ad.Modification);
                ad.DateAdded = DateTime.Now;
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
        
        public string SetName(int makeId, int modelId, string modification)
        {
            var makeName = "";
            var modelName = "";

            using (var context = new MyMobileContext())
            {
                makeName = context.Makes.Where(m => m.Id == makeId).FirstOrDefault().Name;
                modelName = context.Models.Where(m => m.Id == modelId).FirstOrDefault().Name;
            }

            var adName = $"{makeName} {modelName} {modification}";

            return adName;
        }

        public decimal CalculateDefaultPrice(int currencyId, decimal userPrice)
        {
            var currency = new Currency();

            using (var context = new MyMobileContext())
            {
                currency = context.Currencies.Where(c => c.Id == currencyId).FirstOrDefault();

                decimal defaultPriceBgn = userPrice * currency.CourseToDefault;

                return defaultPriceBgn;
            }
        }
    }
}
