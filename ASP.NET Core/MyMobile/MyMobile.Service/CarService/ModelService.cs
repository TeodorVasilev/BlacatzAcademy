using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Service.CarService
{
    public class ModelService
    {
        public List<Model> GetModels()
        {
            var models = new List<Model>();

            using (var context = new MyMobileContext())
            {
                models = context.Models.ToList();
            }

            return models;
        }
    }
}
