using MyMobile.DAL.Models.ViewModels.Listings;

namespace MyMobile.DAL.Models.ViewModels.Pages
{
    public class SearchPageViewModel
    {
        public SearchDetailsViewModel SearchDetailsViewModel { get; set; }
        public ListingsViewModel ListingViewModel { get; set; }
        public QuickSearchStoreViewModel QuickSearchStoreViewModel { get; set; }
    }
}
