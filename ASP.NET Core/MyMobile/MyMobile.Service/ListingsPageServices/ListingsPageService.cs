using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;
using MyMobile.DAL.Models.ViewModels.Create;
using MyMobile.DAL.Models.ViewModels.Listings;
using MyMobile.DAL.Models.ViewModels.Pages;
using MyMobile.Service.AccountService;
using MyMobile.Service.CarAdService;

namespace MyMobile.Service.ListingsPageServices
{
    public class ListingsPageService
    {
        public SearchPageViewModel LoadListings(QuickSearchStoreViewModel formData, int? page)
        {
            var searchPageViewModel = new SearchPageViewModel();
            searchPageViewModel.SearchDetailsViewModel = new SearchDetailsViewModel();
            searchPageViewModel.QuickSearchStoreViewModel = formData;

            using (var context = new MyMobileContext())
            {
                searchPageViewModel.SearchDetailsViewModel.Category = context.Categories.Where(c => c.Id == formData.CategoryId).FirstOrDefault();
                searchPageViewModel.SearchDetailsViewModel.Make = context.Makes.Where(m => m.Id == formData.MakeId).FirstOrDefault();
                searchPageViewModel.SearchDetailsViewModel.Model = context.Models.Where(m => m.Id == formData.ModelId).FirstOrDefault();
                searchPageViewModel.SearchDetailsViewModel.Engine = context.Engines.Where(e => e.Id == formData.EngineId).FirstOrDefault();
                searchPageViewModel.SearchDetailsViewModel.Gearbox = context.Gearboxes.Where(g => g.Id == formData.GearboxId).FirstOrDefault();
                searchPageViewModel.SearchDetailsViewModel.Region = context.Regions.Where(r => r.Id == formData.RegionId).FirstOrDefault();
                searchPageViewModel.SearchDetailsViewModel.Town = context.Towns.Where(t => t.Id == formData.TownId).FirstOrDefault();
                searchPageViewModel.SearchDetailsViewModel.ManufactureYear = formData.Year;
            }

            //list of multiple selected conditions
            //quickSearchViewModel.Conditions = conditionService.GetConditions();

            var listingService = new ListingService();
            searchPageViewModel.ListingViewModel = new ListingViewModel();

            decimal maximalPrice = 0;
            int sortingId = 0;

            var carAd = new Listing()
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

            searchPageViewModel.ListingViewModel.CarAds = listingService.GetCarAds(carAd, sortingId, maximalPrice, page);
            searchPageViewModel.ListingViewModel.TotalPages = listingService.GetTotalPages(carAd, sortingId, maximalPrice);

            return searchPageViewModel;
        }

        public List<Model> ListModelsById(int makeId)
        {
            var searchPageViewModel = new SearchPageViewModel();
            using (var context = new MyMobileContext())
            {
                return context.Models.Where(m => m.MakeId == makeId).ToList();
            }
        }

        public ListingViewModel LoadListing(int id)
        {
            var listingViewModel = new ListingViewModel();
            var listingService = new ListingService();
            //get from context check listing service class
            var listing = listingService.GetListingById(id);

            listingViewModel.Listing = listing;

            return listingViewModel;
        }

        public CreateListingViewModel LoadCreateForm()
        {
            var createListingViewModel = new CreateListingViewModel();

            using (var context = new MyMobileContext())
            {
                createListingViewModel.Categories = context.Categories.ToList();
                createListingViewModel.Conditions = context.Conditions.ToList();
                createListingViewModel.Currencies = context.Currencies.ToList();
                createListingViewModel.Regions = context.Regions.ToList();
                createListingViewModel.Towns = context.Towns.ToList();
                createListingViewModel.Makes = context.Makes.ToList();
                createListingViewModel.Models = context.Models.ToList();
                createListingViewModel.VehicleCategories = context.VehicleCategories.ToList();
                createListingViewModel.Engines = context.Engines.ToList();
                createListingViewModel.Eurostandards = context.Eurostandards.ToList();
                createListingViewModel.Gearboxes = context.Gearboxes.ToList();
                createListingViewModel.Colors = context.Colors.ToList();
                createListingViewModel.Interiors = context.Interiors.ToList();
                createListingViewModel.Comforts = context.Comforts.ToList();
                createListingViewModel.Securities = context.Securities.ToList();

            }

            return createListingViewModel;
        }

        public EditListingViewModel LoadeEditListingPage(int id)
        {
            //load the ad in the create form

            var viewModel = new EditListingViewModel();

            viewModel.ListingViewModel = LoadListing(id);
            viewModel.CreateListingViewModel = LoadCreateForm();

            return viewModel;
        }

        public void StoreListing(StoreListingViewModel formData)
        {
            Listing carAd = new Listing();
            carAd.HorsePower = (int)formData.HorsePower;
            carAd.Modification = formData.Modification;
            carAd.Mileage = (int)formData.Mileage;
            carAd.UserPrice = (decimal)formData.UserPrice;
            carAd.ManufactureYear = (int)formData.ManufactureYear; //remove
            carAd.ManufactureMonth = (int)formData.ManufactureMonth; //remove
            carAd.CategoryId = (int)formData.CategoryId;
            carAd.CurrencyId = (int)formData.CurrencyId;
            carAd.ConditionId = (int)formData.ConditionId;
            carAd.RegionId = (int)formData.RegionId;
            carAd.TownId = (int)formData.TownId;
            carAd.MakeId = (int)formData.MakeId;
            carAd.ModelId = (int)formData.ModelId;
            carAd.ColorId = (int)formData.ColorId;
            carAd.EngineId = (int)formData.EngineId;
            carAd.EurostandardId = (int)formData.EurostandardId;
            carAd.GearboxId = (int)formData.GearboxId;
            carAd.VehicleCategoryId = (int)formData.VehicleCategoryId;
            carAd.AppUserId = formData.userId;
            carAd.CarAdInteriors = formData.CarAdInteriors
                .Select(c => new CarAdInterior() { InteriorId = c })
                .ToList();
            carAd.CarAdComforts = formData.CarAdComforts
                .Select(c => new CarAdComfort() { ComfortId = c })
                .ToList();
            carAd.CarAdSecurities = formData.CarAdSecurities
                .Select(c => new CarAdSecurity() { SecurityId = c })
                .ToList();

            var listingService = new ListingService();
            listingService.Create(carAd);
        }
    }
}
