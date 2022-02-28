using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarArgs;

namespace MyMobile.Service.CarService
{
    public class ColorService
    {
        public List<Color> GetColors()
        {
            var colors = new List<Color>();

            using (var context = new MyMobileContext())
            {
                colors = context.Colors.ToList();
            }

            return colors;
        }
    }
}
