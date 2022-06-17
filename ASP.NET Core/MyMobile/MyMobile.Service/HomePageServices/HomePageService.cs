using MyMobile.DAL.Models.ViewModels.Listings;
using MyMobile.DAL.Models.ViewModels.Pages;
using MyMobile.Service.CarAdService;

namespace MyMobile.Service.HomePageServices
{
    public class HomePageService
    {
        public HomePageViewModel LoadHome()
        {
            var homepageViewModel = new HomePageViewModel();
            homepageViewModel.CarAdViewModel = new ListingViewModel();
            homepageViewModel.AdQuickSearchViewModel = new QuickSearchViewModel();
            var listingService = new ListingService();

            ////sorted by date added
            homepageViewModel.CarAdViewModel.CarAds = listingService.GetNewestCarAds();

            using (MyMobile.DAL.Data.MyMobileContext context = new DAL.Data.MyMobileContext())
            {
                homepageViewModel.AdQuickSearchViewModel.Categories = context.Categories.ToList();
                homepageViewModel.AdQuickSearchViewModel.Makes = context.Makes.ToList();
                homepageViewModel.AdQuickSearchViewModel.Models = context.Models.ToList();
                homepageViewModel.AdQuickSearchViewModel.Categories = context.Categories.ToList();
                homepageViewModel.AdQuickSearchViewModel.Makes = context.Makes.ToList();
                homepageViewModel.AdQuickSearchViewModel.Models = context.Models.ToList();
                homepageViewModel.AdQuickSearchViewModel.Engines = context.Engines.ToList();
                homepageViewModel.AdQuickSearchViewModel.Gearboxes = context.Gearboxes.ToList();
                homepageViewModel.AdQuickSearchViewModel.Regions = context.Regions.ToList();
                homepageViewModel.AdQuickSearchViewModel.Towns = context.Towns.ToList();
                homepageViewModel.AdQuickSearchViewModel.Conditions = context.Conditions.ToList();
            }

            return homepageViewModel;
        }
    }
}
