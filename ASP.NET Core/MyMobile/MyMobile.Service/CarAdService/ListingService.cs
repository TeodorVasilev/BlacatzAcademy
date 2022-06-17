using Microsoft.EntityFrameworkCore;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.Identity;
using MyMobile.DAL.Models.ViewModels.Create;

namespace MyMobile.Service.CarAdService
{
    public class ListingService
    {
        private int perPage = 2;
        public IQueryable<Listing> FilterQuery(IQueryable<Listing> query, Listing carAd, int sortingId, decimal maximalPrice)
        {
            if (carAd.CategoryId != 0)
            {
                query = query.Where(ca => ca.CategoryId == carAd.CategoryId);
            }

            if (carAd.MakeId != 0)
            {
                query = query.Where(ca => ca.MakeId == carAd.MakeId);
            }

            if (carAd.ModelId != 0)
            {
                query = query.Where(ca => ca.ModelId == carAd.ModelId);
            }

            if (carAd.UserPrice != 0)
            {
                query = query.Where(ca => ca.DefaultPriceBgn <= maximalPrice);
            }

            if (carAd.ManufactureYear != 0)
            {
                query = query.Where(ca => ca.ManufactureYear >= carAd.ManufactureYear);
            }

            if (carAd.EngineId != 0)
            {
                query = query.Where(ca => ca.EngineId == carAd.EngineId);
            }

            if (carAd.GearboxId != 0)
            {
                query = query.Where(ca => ca.GearboxId == carAd.GearboxId);
            }

            if (carAd.RegionId != 0)
            {
                query = query.Where(ca => ca.RegionId == carAd.RegionId);
            }

            if (carAd.TownId != 0)
            {
                query = query.Where(ca => ca.TownId == carAd.TownId);
            }

            //sorting
            //<option value="1">Марка/Модел/Цена</option>
            //<option value="2">Цена</option>
            //<option value="3">Дата на производство</option>
            //<option value="4">Пробег</option>
            //<option value="5">Най-новите обяви</option>
            //<option value="6">Най-новите обяви от посл. 2 дни</option>

            if (sortingId == 1)
            {
                query = query
                    .OrderBy(ca => ca.MakeId)
                    .ThenBy(ca => ca.ModelId)
                    .ThenBy(ca => ca.DefaultPriceBgn);
            }
            else if (sortingId == 2)
            {
                query = query
                    .OrderBy(ca => ca.DefaultPriceBgn);
            }
            else if (sortingId == 3)
            {
                query = query
                    .OrderBy(ca => ca.ManufactureYear);
            }
            else if (sortingId == 4)
            {
                query = query
                    .OrderBy(ca => ca.Mileage);
            }
            else if (sortingId == 5)
            {
                query = query
                    .OrderByDescending(ca => ca.DateAdded);
            }


            return query;
        }

        public double GetTotalPages(Listing carAd, int sortingId, decimal maximalPrice)
        {
            using (var context = new MyMobileContext())
            {
                //var townsServer = new TownService();
                //var towns = townsServer.GetTowns();
                var town = context.Towns.ToList();
                var townById = context.Towns.Where(x => x.Id == 1).FirstOrDefault();
                //repository pattern
                var query = context.CarAds.AsQueryable();
                query = FilterQuery(query, carAd, sortingId, maximalPrice);

                double totalCars = query.Count();
                //85
                //8.5 -> 9
                double pages = totalCars / this.perPage;
                pages = Math.Ceiling(pages);

                return pages;
            }

            return 0;
        }

        public List<Listing> GetCarAds(Listing carAd, int sortingId, decimal maximalPrice, int? curPage)
        {
            var carAds = new List<Listing>();
            int page = curPage != null ? curPage.Value : 1;
            using (var context = new MyMobileContext())
            {
                //SELECT * FROM Cars WHERE makeId = 5
                var query = context.CarAds.AsQueryable();
                query = FilterQuery(query, carAd, sortingId, maximalPrice);
                //check how to properly filter the ads and add all the properties
                query = query
                    .Include(c => c.Category)
                    .Include(c => c.Condition)
                    .Include(c => c.Currency)
                    .Include(c => c.Region)
                    .Include(c => c.Town)
                    .Include(c => c.Color)
                    .Include(c => c.Engine)
                    .Include(c => c.Gearbox)
                    .Skip((page - 1) * this.perPage)
                    .Take(this.perPage);

                string str = query

                    .ToQueryString();
                carAds = query.ToList();
            }

            return carAds;
        }

        public List<Listing> GetNewestCarAds()
        {
            var carAds = new List<Listing>();

            using (var context = new MyMobileContext())
            {
                carAds = context.CarAds
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
                    .OrderByDescending(c => c.DateAdded)
                    .Take(6)
                    .ToList();
                //include all properties and then fix the looks
                //pages and stuff in controller
            }

            return carAds;
        }

        public List<Listing> GetUserListings(int id)
        {
            var carAds = new List<Listing>();

            using (var context = new MyMobileContext())
            {
                carAds = context.CarAds.Where(ca => ca.AppUserId == id)
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
                    .OrderByDescending(c => c.DateAdded)
                    .ToList();
            }

            return carAds;
        }

        public Listing GetListingById(int id)
        {
            Listing carAd = new Listing();

            using (var context = new MyMobileContext())
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

        public void Create(Listing ad)
        {
            using (var context = new MyMobileContext())
            {
                ad.DefaultPriceBgn = CalculateDefaultPrice(ad.CurrencyId, ad.UserPrice);
                ad.Name = SetName(ad.MakeId, ad.ModelId, ad.Modification);
                ad.DateAdded = DateTime.Now;
                context.CarAds.Add(ad);
                //context.UserAds.Add(new UserAds() { AppUserId = ad.AppUserId, CarAdId = ad.Id });
                context.SaveChanges();
            }
        }

        public void Update(int id, StoreListingViewModel formData)
        {

            //add all properties fix view model properties and make this to be saved only when something is changed

            using (var context = new MyMobileContext())
            {
                var carAd = context.CarAds.Where(ca => ca.Id == id).FirstOrDefault();

                if(formData.MakeId != null)
                {
                    carAd.MakeId = (int)formData.MakeId;
                }

                carAd.DefaultPriceBgn = CalculateDefaultPrice(carAd.CurrencyId, carAd.UserPrice);
                carAd.Name = SetName(carAd.MakeId, carAd.ModelId, carAd.Modification);

                context.SaveChanges();
            }
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
