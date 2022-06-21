using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.Identity;
using MyMobile.DAL.Models.ViewModels.Create;
using MyMobile.DAL.Models.ViewModels.Listings;
using MyMobile.Service.AccountService;
using MyMobile.Service.CarAdService;
using MyMobile.Service.ListingsPageServices;

namespace MyMobile.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IUserService _userService;

        public ListingsController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Search(QuickSearchStoreViewModel formData, int? page)
        {
            var listingsPageService = new ListingsPageService();
            return View(listingsPageService.LoadListings(formData, page));
        }

        public IActionResult Listing(int id)
        {
            var listingsPageService = new ListingsPageService();
            return View(listingsPageService.LoadListing(id));
        }

        public IActionResult ListModelsById(int makeId)
        {
            var listingsPageService = new ListingsPageService();
            return Json(listingsPageService.ListModelsById(makeId));
        }

        public IActionResult Create()
        {
            var listingPageService = new ListingsPageService();
            return View(listingPageService.LoadCreateForm());
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var listingPageService = new ListingsPageService();
            return View(listingPageService.LoadeEditListingPage(id));
        }

        public IActionResult EditStore(int id, StoreListingViewModel formData)
        {
            var listingService = new ListingService();
            listingService.Update(id, formData);
            return RedirectToAction("MyAds", "Account");
        }

        public IActionResult Store(StoreListingViewModel formData)
        {
            var listingsPageService = new ListingsPageService();
            if (User.Identity.IsAuthenticated)
            {
                formData.userId = _userService.GetUserId();
                listingsPageService.StoreListing(formData);
                return RedirectToAction("MyAds", "Account");
            }
            else
            {
                listingsPageService.StoreListing(formData);
            }
            //fix method if condition and redirection when adding new listing as logged user or as unlogeduser

            return RedirectToAction("Index","Home");
        }
    }
}
