using Microsoft.AspNetCore.Mvc;
using MyMobile.DAL.Models.CarAd;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;
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
            var vehicleCategoryService = new VehicleCategoryService();
            var engineService = new EngineService();
            var gearboxService = new GearboxService();
            var colorService = new ColorService();
            var interiorService = new InteriorService();
            var comfortService = new ComfortService();
            var securityService = new SecurityService();
            var dateService = new ManufactureDateService();

            var createViewModel = new CreateCarAdViewModel()
            {
                Categories = categoryService.GetCategories(),
                Conditions = conditionService.GetConditions(),
                Currencies = currencyService.GetCurrencies(),
                Regions = regionService.GetRegions(),
                Towns = townService.GetTowns(),
                Makes = makeService.GetMakes(),
                Models = modelService.GetModels(),
                VehicleCategories = vehicleCategoryService.GetVehicleCategories(),
                Engines = engineService.GetEngines(),
                Gearboxes = gearboxService.GetGearboxes(),
                Colors = colorService.GetColors(),
                Interiors = interiorService.GetInteriors(),
                Comforts = comfortService.GetComforts(),
                Securities = securityService.GetSecurities(),
                ManufactureMonths = dateService.GetMonths(),
                ManufactureYears = dateService.GetYears()
            };


            return View(createViewModel);
        }

        [HttpPost]
        public IActionResult Store(CarStoreViewModel formData)
        {
            CarAd carAd = new CarAd();
            carAd.HorsePower = formData.HorsePower;
            carAd.Modification = formData.Modification;
            carAd.Mileage = formData.Mileage;
            carAd.UserPrice = formData.UserPrice;
            carAd.ManufactureYear = formData.ManufactureYear; //
            carAd.ManufactureMonth = formData.ManufactureMonth; //
            carAd.CategoryId = formData.CategoryId;
            carAd.CurrencyId = formData.CurrencyId;
            carAd.ConditionId =formData.ConditionId;
            carAd.RegionId = formData.RegionId;
            carAd.TownId = formData.TownId ;
            carAd.MakeId = formData.MakeId ;
            carAd.ModelId = formData.ModelId ;
            carAd.ColorId = formData.ColorId ;
            carAd.EngineId = formData.EngineId ;
            carAd.GearboxId = formData.GearboxId ;
            carAd.VehicleCategoryId = formData.VehicleCategoryId ;
            carAd.CarAdInteriors = formData.CarAdInteriors
                .Select(c => new CarAdInterior() { InteriorId = c })
                .ToList();
            carAd.CarAdComforts = formData.CarAdComforts
                .Select(c => new CarAdComfort() { ComfortId = c })
                .ToList();
            carAd.CarAdSecurities = formData.CarAdSecurities
                .Select(c => new CarAdSecurity() { SecurityId = c })
                .ToList();

            var carAdService = new CarAdService();
            carAdService.Create(carAd);

            return Content("Обявата Ви е успешно публикувана");
        }
    }
}
