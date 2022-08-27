using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.Identity;
using MyMobile.DAL.Models.ViewModels.Create;
using MyMobile.DAL.Models.ViewModels.Listings;
using MyMobile.Service.AccountService;
using MyMobile.Service.CarAdService;

namespace MyMobile.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IUserService userService;
        private readonly IListingService listingService;

        public ListingsController(IUserService userService, IListingService listingService)
        {
            this.userService = userService;
            this.listingService = listingService;
        }

        public IActionResult Create()
        {
            return View(this.listingService.LoadCreateForm());
        }
        public IActionResult Delete(int id)
        {
            this.listingService.Delete(id);
            return RedirectToAction("ListPendingAds", "Administration");
        }
        public IActionResult ListModelsByMakeId(int makeId)
        {
            return Json(this.listingService.ListModelsById(makeId));
        }
        public IActionResult ListTownsByRegionId(int regionId)
        {
            return Json(this.listingService.ListTownsById(regionId));
        }
        public IActionResult Store(StoreListingViewModel formData)
        {
            if (User.Identity.IsAuthenticated)
            {
                formData.userId = this.userService.GetUserId();
                this.listingService.Create(formData);
                return RedirectToAction("MyAds", "Account");
            }
            else
            {
                this.listingService.Create(formData);
            }
            //fix method if condition and redirection when adding new listing as logged user or as annon

            return RedirectToAction("Index","Home");
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            return View(this.listingService.LoadEditListingPage(id));
        }
        public IActionResult EditStore(int id, StoreListingViewModel formData)
        {
            this.listingService.Update(id, formData);
            return RedirectToAction("MyAds", "Account");
        }
        public IActionResult Search(QuickSearchStoreViewModel formData, int? page)
        {
            return View(this.listingService.LoadListings(formData, page));
        }
        public IActionResult Listing(int id)
        {
            return View(this.listingService.LoadListing(id));
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult PendingListing(int id)
        {
            return View(this.listingService.LoadPendingListing(id));
        }
        public IActionResult ApproveListing(int id)
        {
            this.listingService.Approve(id);
            return RedirectToAction("ListPendingAds", "Administration");
        }

        [Authorize]
        public IActionResult Promote(int id)
        {
            var model = this.listingService.LoadPromoPage(id);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult PromoteStore(int promoId, int listingId)
        {
            this.listingService.Promote(promoId, listingId);
            return RedirectToAction("MyAds", "Account");
        }
    }
}
