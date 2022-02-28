using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Service.CarAdService
{
    public class VehicleCategoryService
    {
        public List<VehicleCategory> GetVehicleCategories()
        {
            var vehicleCategories = new List<VehicleCategory>();

            using(var context = new MyMobileContext())
            {
                vehicleCategories = context.VehicleCategories.ToList();
            }

            return vehicleCategories;
        }
    }
}
