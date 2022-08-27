using Microsoft.EntityFrameworkCore;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;
using MyMobile.DAL.Models.ViewModels.Create;
using MyMobile.DAL.Models.ViewModels.Listings;
using MyMobile.DAL.Models.ViewModels.Pages;

namespace MyMobile.Service.CarAdService
{
    public class ListingService : IListingService
    {
        private int perPage = 2;
        public void Create(StoreListingViewModel formData)
        {
            Listing carAd = new Listing();
            carAd.HorsePower = (int)formData.HorsePower;
            carAd.Modification = formData.Modification;
            carAd.Mileage = (int)formData.Mileage;
            carAd.UserPrice = (decimal)formData.UserPrice;
            carAd.ManufactureYear = (int)formData.ManufactureYear;
            carAd.ManufactureMonth = (int)formData.ManufactureMonth; 
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
            carAd.DefaultPriceBgn = this.CalculateDefaultPrice(carAd.CurrencyId, carAd.UserPrice);
            carAd.Name = this.SetName(carAd.MakeId, carAd.ModelId, carAd.Modification);
            carAd.DateAdded = DateTime.Now;

            using (var context = new MyMobileContext())
            {
                context.CarAds.Add(carAd);
                context.SaveChanges();
            }
        }
        public void Update(int id, StoreListingViewModel formData)
        {

            //add all properties fix view model properties and make this to be saved only when something is changed

            using (var context = new MyMobileContext())
            {
                var carAd = context.CarAds.Where(ca => ca.Id == id).FirstOrDefault();

                if(formData.MakeId != null)
                {
                    carAd.MakeId = (int)formData.MakeId;
                }

                carAd.DefaultPriceBgn = CalculateDefaultPrice(carAd.CurrencyId, carAd.UserPrice);
                carAd.Name = SetName(carAd.MakeId, carAd.ModelId, carAd.Modification);

                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var context = new MyMobileContext())
            {
                var carAd = context.CarAds.FirstOrDefault(c => c.Id == id);

                context.CarAds.Remove(carAd);
                context.SaveChanges();
            }
        }
        public void Approve(int id)
        {
            using(var context = new MyMobileContext())
            {
                var carAd = context.CarAds.FirstOrDefault(c => c.Id == id);

                carAd.IsApproved = true;
                context.SaveChanges();
            }
        }
        public void Promote(int promoId, int listingId)
        {
            using(var context = new MyMobileContext())
            {
                //var promo = context.Promotions.Where( p => p.Id == id).FirstOrDefault();
                //add promoduration values 3, 5, 7;
                var ad = context.CarAds.Where(ca => ca.Id == listingId).FirstOrDefault();
                ad.PromotionId = promoId;
                ad.PromoDuration = 7;
                ad.PromoStart = DateTime.Now;
                ad.PromoEnd = ad.PromoStart.Value.AddDays(ad.PromoDuration.Value);
                ad.IsPromoted = true;

                context.SaveChanges();
            }
        }
        public string SetName(int makeId, int modelId, string modification)
        {
            var makeName = "";
            var modelName = "";

            using (var context = new MyMobileContext())
            {
                makeName = context.Makes.Where(m => m.Id == makeId).FirstOrDefault().Name;
                modelName = context.Models.Where(m => m.Id == modelId).FirstOrDefault().Name;
            }

            var adName = $"{makeName} {modelName} {modification}";

            return adName;
        }
        public double GetTotalPages(Listing carAd, int sortingId, decimal maximalPrice)
        {
            using (var context = new MyMobileContext())
            {
                //var townsServer = new TownService();
                //var towns = townsServer.GetTowns();
                var town = context.Towns.ToList();
                var townById = context.Towns.Where(x => x.Id == 1).FirstOrDefault();
                //repository pattern
                var query = context.CarAds.AsQueryable();
                query = FilterQuery(query, carAd, sortingId, maximalPrice);

                double totalCars = query.Count();
                //85
                //8.5 -> 9
                double pages = totalCars / this.perPage;
                pages = Math.Ceiling(pages);

                return pages;
            }

            return 0;
        }
        public decimal CalculateDefaultPrice(int currencyId, decimal userPrice)
        {
            var currency = new Currency();

            using (var context = new MyMobileContext())
            {
                currency = context.Currencies.Where(c => c.Id == currencyId).FirstOrDefault();

                decimal defaultPriceBgn = userPrice * currency.CourseToDefault;

                return defaultPriceBgn;
            }
        }
        public List<Listing> GetListings(Listing carAd, int sortingId, decimal maximalPrice, int? curPage)
        {
            var carAds = new List<Listing>();
            int page = curPage != null ? curPage.Value : 1;
            using (var context = new MyMobileContext())
            {
                var query = context.CarAds.Where(c => c.IsApproved == true).AsQueryable();
                query = FilterQuery(query, carAd, sortingId, maximalPrice);
                query = query
                    .Include(c => c.Category)
                    .Include(c => c.Condition)
                    .Include(c => c.Currency)
                    .Include(c => c.Region)
                    .Include(c => c.Town)
                    .Include(c => c.Color)
                    .Include(c => c.Engine)
                    .Include(c => c.Gearbox)
                    .Include(c => c.Promotion)
                    .Skip((page - 1) * this.perPage)
                    .Take(this.perPage);

                string str = query

                    .ToQueryString();
                carAds = query.ToList();
            }

            return carAds;
        }
        public List<Listing> GetNewestListings()
        {
            var carAds = new List<Listing>();

            using (var context = new MyMobileContext())
            {
                carAds = context.CarAds
                    .Where(c => c.IsApproved == true)
                    .Include(c => c.Category)
                    .Include(c => c.Condition)
                    .Include(c => c.Currency)
                    .Include(c => c.Region)
                    .Include(c => c.Town)
                    .Include(c => c.Color)
                    .Include(c => c.Engine)
                    .Include(c => c.Eurostandard)
                    .Include(c => c.Gearbox)
                    .Include(c => c.VehicleCategory)
                    .Include(c => c.CarAdComforts)
                    .ThenInclude(e => e.Comfort)
                    .OrderByDescending(c => c.DateAdded)
                    .Take(6)
                    .ToList();
                //include all properties and then fix the view
                //pages and stuff in controller
            }

            return carAds;
        }
        public List<Listing> GetUserListings(int id)
        {
            var carAds = new List<Listing>();

            using (var context = new MyMobileContext())
            {
                carAds = context.CarAds.Where(ca => ca.AppUserId == id)
                    .Include(c => c.Category)
                    .Include(c => c.Condition)
                    .Include(c => c.Currency)
                    .Include(c => c.Region)
                    .Include(c => c.Town)
                    .Include(c => c.Color)
                    .Include(c => c.Engine)
                    .Include(c => c.Eurostandard)
                    .Include(c => c.Gearbox)
                    .Include(c => c.Promotion)
                    .Include(c => c.VehicleCategory)
                    .Include(c => c.CarAdComforts)
                    .ThenInclude(e => e.Comfort)
                    .OrderByDescending(c => c.DateAdded)
                    .ToList();
            }

            return carAds;
        }
        public List<Town> ListTownsById(int regionId)
        {
            using (var context = new MyMobileContext())
            {
                return context.Towns.Where(t => t.RegionId == regionId).ToList();
            }
        }
        public List<Model> ListModelsById(int makeId)
        {
            using (var context = new MyMobileContext())
            {
                return context.Models.Where(m => m.MakeId == makeId).ToList();
            }
        }
        public Listing GetPendingListingById(int id)
        {
            Listing carAd = new Listing();

            using (var context = new MyMobileContext())
            {
                //the listing has to be visible to admin when is still not approved
                carAd = context.CarAds.Where(ca => ca.Id == id)
                                      .Where(x=> x.IsApproved == false)
                                      .Include(c => c.Category)
                                      .Include(c => c.Condition)
                                      .Include(c => c.Currency)
                                      .Include(c => c.Region)
                                      .Include(c => c.Town)
                                      .Include(c => c.Color)
                                      .Include(c => c.Engine)
                                      .Include(c => c.Eurostandard)
                                      .Include(c => c.Gearbox)
                                      .Include(c => c.VehicleCategory)
                                      .Include(c => c.CarAdComforts)
                                      .ThenInclude(e => e.Comfort)
                                      .Include(c => c.CarAdInteriors)
                                      .ThenInclude(e => e.Interior)
                                      .Include(c => c.CarAdSecurities)
                                      .ThenInclude(e => e.Security)
                                      .FirstOrDefault();
            }

            return carAd;
        }
        public Listing GetListingById(int id)
        {
            Listing carAd = new Listing();

            using (var context = new MyMobileContext())
            {
                //the listing has to be visible to admin when is still not approved
                carAd = context.CarAds.Where(ca => ca.Id == id && ca.IsApproved == true)
                                      .Include(c => c.Category)
                                      .Include(c => c.Condition)
                                      .Include(c => c.Currency)
                                      .Include(c => c.Region)
                                      .Include(c => c.Town)
                                      .Include(c => c.Color)
                                      .Include(c => c.Engine)
                                      .Include(c => c.Eurostandard)
                                      .Include(c => c.Gearbox)
                                      .Include(c => c.Promotion)
                                      .Include(c => c.VehicleCategory)
                                      .Include(c => c.CarAdComforts)
                                      .ThenInclude(e => e.Comfort)
                                      .Include(c => c.CarAdInteriors)
                                      .ThenInclude(e => e.Interior)
                                      .Include(c => c.CarAdSecurities)
                                      .ThenInclude(e => e.Security)
                                      .FirstOrDefault();
            }

            return carAd;
        }
        public ListingsViewModel LoadListing(int id)
        {
            var listingViewModel = new ListingsViewModel();
            listingViewModel.Listing = this.GetListingById(id);
            return listingViewModel;
        }
        public ListingsViewModel LoadPendingListing(int id)
        {
            ListingsViewModel listingViewModel = new ListingsViewModel();
            listingViewModel.Listing = this.GetPendingListingById(id);
            return listingViewModel;
        }
        public ListingsViewModel LoadAllListings()
        {
            var listingViewModel = new ListingsViewModel();

            using (var context = new MyMobileContext())
            {

                var carAds = context.CarAds
                    .Include(ca => ca.AppUser)
                    .ToList();

                listingViewModel.CarAds = carAds;
            }


            return listingViewModel;
        }
        public ListingsViewModel LoadPendingListings()
        {
            var listingViewModel = new ListingsViewModel();

            using (var context = new MyMobileContext())
            {
                var pendingCarAds = context.CarAds.Where(ca => ca.IsApproved == false)
                    .Include(ca => ca.AppUser)
                    .ToList();

                listingViewModel.CarAds = pendingCarAds;
            }

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
        public EditListingViewModel LoadEditListingPage(int id)
        {
            var viewModel = new EditListingViewModel();

            viewModel.ListingViewModel = LoadListing(id);
            viewModel.CreateListingViewModel = LoadCreateForm();

            return viewModel;
        }
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

            searchPageViewModel.ListingViewModel = new ListingsViewModel();

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

            searchPageViewModel.ListingViewModel.CarAds = this.GetListings(carAd, sortingId, maximalPrice, page);
            searchPageViewModel.ListingViewModel.TotalPages = this.GetTotalPages(carAd, sortingId, maximalPrice);

            return searchPageViewModel;
        }
        public PromoteViewModel LoadPromoPage(int id)
        {
            var model = new PromoteViewModel();

            model.ListingId = id; 

            using(var context = new MyMobileContext())
            {
                model.Promotions = context.Promotions.ToList();
            }

            return model;
        }
        public IQueryable<Listing> FilterQuery(IQueryable<Listing> query, Listing carAd, int sortingId, decimal maximalPrice)
        {
            if (carAd.CategoryId != 0)
            {
                query = query.Where(ca => ca.CategoryId == carAd.CategoryId);
            }

            if (carAd.MakeId != 0)
            {
                query = query.Where(ca => ca.MakeId == carAd.MakeId);
            }

            if (carAd.ModelId != 0)
            {
                query = query.Where(ca => ca.ModelId == carAd.ModelId);
            }

            if (carAd.UserPrice != 0)
            {
                query = query.Where(ca => ca.DefaultPriceBgn <= maximalPrice);
            }

            if (carAd.ManufactureYear != 0)
            {
                query = query.Where(ca => ca.ManufactureYear >= carAd.ManufactureYear);
            }

            if (carAd.EngineId != 0)
            {
                query = query.Where(ca => ca.EngineId == carAd.EngineId);
            }

            if (carAd.GearboxId != 0)
            {
                query = query.Where(ca => ca.GearboxId == carAd.GearboxId);
            }

            if (carAd.RegionId != 0)
            {
                query = query.Where(ca => ca.RegionId == carAd.RegionId);
            }

            if (carAd.TownId != 0)
            {
                query = query.Where(ca => ca.TownId == carAd.TownId);
            }

            //sorting
            //вип и топ обявите да се показват най-отгоре при всяко търсене
            //<option value="1">Марка/Модел/Цена</option>
            //<option value="2">Цена</option>
            //<option value="3">Дата на производство</option>
            //<option value="4">Пробег</option>
            //<option value="5">Най-новите обяви</option>
            //<option value="6">Най-новите обяви от посл. 2 дни</option>

            if (sortingId == 1)
            {
                query = query
                    .OrderBy(ca => ca.MakeId)
                    .ThenBy(ca => ca.ModelId)
                    .ThenBy(ca => ca.DefaultPriceBgn);
            }
            else if (sortingId == 2)
            {
                query = query
                    .OrderBy(ca => ca.DefaultPriceBgn);
            }
            else if (sortingId == 3)
            {
                query = query
                    .OrderBy(ca => ca.ManufactureYear);
            }
            else if (sortingId == 4)
            {
                query = query
                    .OrderBy(ca => ca.Mileage);
            }
            else if (sortingId == 5)
            {
                query = query
                    .OrderByDescending(ca => ca.DateAdded);
            }


            return query;
        }
    }
}
