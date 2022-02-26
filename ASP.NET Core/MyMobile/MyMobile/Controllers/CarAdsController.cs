using Microsoft.AspNetCore.Mvc;
using MyMobile.DAL.Models.CarAd;
using MyMobile.Models;
using MyMobile.Service.CarAdService;
using MyMobile.Service.CarService;

namespace MyMobile.Controllers
{
    public class CarAdsController : Controller
    {
        public IActionResult Index()
        {
            var carAdService = new CarAdService();
            var carAdsViewModel = new CarAdViewModel();

            carAdsViewModel.CarAds = carAdService.GetCarAds();

            return View(carAdsViewModel);
        }

        public IActionResult Create()
        {
            var categoryService = new CategoryService();
            var conditionService = new ConditionService();
            var currencyService = new CurrencyService();
            var regionService = new RegionService();
            var townService = new TownService();
            var makeService = new MakeService();
            var modelService = new ModelService();

            var createViewModel = new CreateCarAdViewModel()
            {
                Categories = categoryService.GetCategories(),
                Conditions = conditionService.GetConditions(),
                Currencies = currencyService.GetCurrencies(),
                Regions = regionService.GetRegions(),
                Towns = townService.GetTowns(),
                Makes = makeService.GetMakes(),
                Models = modelService.GetModels()
            };


            return View(createViewModel);
        }

        [HttpPost]
        public IActionResult Store(CarAd carAd)
        {
            var adService = new CarAdService();
            adService.Create(carAd);

            return Content("Обявата Ви е успешно публикувана");
        }
    }
}
