namespace MyMobile.Service.CarAdService
{
    public class ManufactureDateService
    {
        public List<int> GetMonths()
        {
            // to do
            var months = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            return months;
        }

        public List<int> GetYears()
        {
            //to do

            var startDate = 1960;
            var endDate = 2022;
            var years = new List<int>();

            for (int i = startDate; i <= endDate; i++)
            {
                years.Add(i);
            }

            return years;
        }
    }
}
