namespace MyMobile.Models
{
    public class HomePageViewModel
    {
        /// <summary>
        /// initialize in controller
        /// </summary>
        public HomePageViewModel()
        {
            this.CarAdViewModel = new CarAdViewModel();
            this.AdQuickSearchViewModel = new AdQuickSearchViewModel();
        }

        public CarAdViewModel CarAdViewModel { get; set; }
        public AdQuickSearchViewModel AdQuickSearchViewModel { get; set; }
    }
}
