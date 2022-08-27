using MyMobile.DAL.Models.ViewModels.Listings;

namespace MyMobile.DAL.Models.ViewModels.Pages
{
    public class HomePageViewModel
    {
        public ListingsViewModel CarAdViewModel { get; set; }
        public QuickSearchViewModel AdQuickSearchViewModel { get; set; }
    }
}
