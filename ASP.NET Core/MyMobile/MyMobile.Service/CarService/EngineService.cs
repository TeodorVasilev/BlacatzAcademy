using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Service.CarService
{
    public class EngineService
    {
        public List<Engine> GetEngines()
        {
            var engines = new List<Engine>();

            using(var context = new MyMobileContext())
            {
                engines = context.Engines.ToList();
            }

            return engines;
        }
    }
}
