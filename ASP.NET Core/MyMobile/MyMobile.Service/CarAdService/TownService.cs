using Microsoft.EntityFrameworkCore;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.Service.CarAdService
{
    public class TownService
    {
        public List<Town> GetTowns()
        {
            var towns = new List<Town>();

            using (var context = new MyMobileContext())
            {
                towns = context.Towns.ToList();
            }

            return towns;
        }
    }
}
