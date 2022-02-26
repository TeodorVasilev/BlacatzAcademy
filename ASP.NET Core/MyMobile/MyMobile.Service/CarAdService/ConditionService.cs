using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarAdArgs;

namespace MyMobile.Service.CarAdService
{
    public class ConditionService
    {
        public List<Condition> GetConditions()
        {
            var conditions = new List<Condition>();

            using(var context = new MyMobileContext())
            {
                conditions = context.Conditions.ToList();
            }

            return conditions;
        }
    }
}
