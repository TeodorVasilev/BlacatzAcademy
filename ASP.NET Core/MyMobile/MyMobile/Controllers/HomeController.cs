using Microsoft.AspNetCore.Mvc;
using MyMobile.DAL.Models.CarAd;
using MyMobile.Models;
using MyMobile.Service.CarAdService;
using MyMobile.Service.CarService;
using System.Diagnostics;

namespace MyMobile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var homepageViewModel = new HomePageViewModel();

            var listingService = new ListingService();
            var categoryService = new CategoryService();
            var makeService = new MakeService();
            var modelService = new ModelService();
            var engineService = new EngineService();
            var gearboxService = new GearboxService();
            var conditionService = new ConditionService();
            var regionService = new RegionService();
            var townService = new TownService();
            var manufactureService = new ManufactureDateService();


            homepageViewModel.CarAdViewModel.CarAds = listingService.GetCarAds();
            
            homepageViewModel.AdQuickSearchViewModel.Categories = categoryService.GetCategories();
            homepageViewModel.AdQuickSearchViewModel.Makes = makeService.GetMakes();
            homepageViewModel.AdQuickSearchViewModel.Models = modelService.GetModels();
            homepageViewModel.AdQuickSearchViewModel.Engines = engineService.GetEngines();
            homepageViewModel.AdQuickSearchViewModel.Gearboxes = gearboxService.GetGearboxes();
            homepageViewModel.AdQuickSearchViewModel.Regions = regionService.GetRegions();
            homepageViewModel.AdQuickSearchViewModel.Towns = townService.GetTowns();
            homepageViewModel.AdQuickSearchViewModel.Years = manufactureService.GetYears();
            homepageViewModel.AdQuickSearchViewModel.Conditions = conditionService.GetConditions();

            return View(homepageViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}