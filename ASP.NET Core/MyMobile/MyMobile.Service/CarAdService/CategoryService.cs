using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.Service.CarAdService
{
    public class CategoryService
    {
        public List<Category> GetCategories()
        {
            var categories = new List<Category>();

            using (var context = new MyMobileContext())
            {
                categories = context.Categories.ToList();
            }

            return categories;
        }
    }
}
