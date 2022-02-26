using Microsoft.EntityFrameworkCore;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.Service.CarAdService
{
    public class RegionService
    {
        public List<Region> GetRegions()
        {
            var regions = new List<Region>();

            using(var context = new MyMobileContext())
            {
                regions = context.Regions
                    .Include(r => r.Towns)
                    .ToList();
            }

            return regions;
        }
    }
}
