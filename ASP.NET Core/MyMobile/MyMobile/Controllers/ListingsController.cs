using Microsoft.AspNetCore.Mvc;
using MyMobile.DAL.Models.CarAd;
using MyMobile.Models;
using MyMobile.Service.CarAdService;

namespace MyMobile.Controllers
{
    public class ListingsController : Controller
    {
        public IActionResult Search(AdQuickSearchStoreViewModel formData)
        {
            var listingService = new ListingService();
            var carAdViewModel = new CarAdViewModel();

            decimal maximalPrice = 0;
            int sortingId = 0;

            var carAd = new CarAd()
            {
                CategoryId = formData.CategoryId,
                MakeId = formData.MakeId,
                ModelId = formData.ModelId,
                EngineId = formData.EngineId,
                GearboxId = formData.GearboxId,
                ConditionId = formData.ConditionId,
                ManufactureYear = formData.Year,
                RegionId = formData.RegionId,
                TownId = formData.TownId,
                UserPrice = formData.MaximalPrice //fix property
            };

            maximalPrice = formData.MaximalPrice;
            sortingId = formData.SortingId;

            carAdViewModel.CarAds = listingService.GetCarAds(carAd, sortingId, maximalPrice);

            return View(carAdViewModel);
        }
    }
}
