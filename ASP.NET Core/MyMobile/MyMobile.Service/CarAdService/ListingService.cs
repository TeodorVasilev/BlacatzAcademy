using Microsoft.EntityFrameworkCore;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd;

namespace MyMobile.Service.CarAdService
{
    public class ListingService
    {
        public IQueryable<CarAd> FilterQuery(IQueryable<CarAd> query, CarAd carAd, int sortingId, decimal maximalPrice)
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

        public List<CarAd> GetCarAds(CarAd carAd, int sortingId, decimal maximalPrice)
        {
            var carAds = new List<CarAd>();

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
                    .Include(c => c.Gearbox);

                string str = query.ToQueryString();
                carAds = query.ToList();
            }

            return carAds;
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
                    .Include(c => c.Color)
                    .Include(c => c.Engine)
                    .Include(c => c.Eurostandard)
                    .Include(c => c.Gearbox)
                    .Include(c => c.VehicleCategory)
                    .Include(c => c.CarAdComforts)
                    .ThenInclude(e => e.Comfort)
                    .ToList();
                //include all properties and then fix the looks
                //pages and stuff in controller
            }

            return carAds;
        }
    }
}
