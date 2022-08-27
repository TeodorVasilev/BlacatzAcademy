using MyMobile.DAL.Models.CarAd.CarAdArgs;
using MyMobile.DAL.Models.CarAd.CarArgs;
using MyMobile.DAL.Models.ViewModels.Create;
using MyMobile.DAL.Models.ViewModels.Listings;
using MyMobile.DAL.Models.ViewModels.Pages;

namespace MyMobile.Service.CarAdService
{
    public interface IListingService
    {
        void Create(StoreListingViewModel formData);
        void Update(int id, StoreListingViewModel formData);
        void Delete(int id);
        void Approve(int id);
        public void Promote(int promoId, int listingId);
        public PromoteViewModel LoadPromoPage(int id);
        decimal CalculateDefaultPrice(int currencyId, decimal userPrice);
        string SetName(int makeId, int modelId, string modification);
        Listing GetListingById(int id);
        Listing GetPendingListingById(int id);
        List<Listing> GetListings(Listing carAd, int sortingId, decimal maximalPrice, int? curPage);
        List<Listing> GetNewestListings();
        List<Listing> GetUserListings(int id);
        IQueryable<Listing> FilterQuery(IQueryable<Listing> query, Listing carAd, int sortingId, decimal maximalPrice);
        double GetTotalPages(Listing carAd, int sortingId, decimal maximalPrice);
        CreateListingViewModel LoadCreateForm();
        List<Model> ListModelsById(int makeId);
        List<Town> ListTownsById(int regionId);
        SearchPageViewModel LoadListings(QuickSearchStoreViewModel formData, int? page);
        ListingsViewModel LoadListing(int id);
        ListingsViewModel LoadAllListings();
        ListingsViewModel LoadPendingListings();
        ListingsViewModel LoadPendingListing(int id);
        EditListingViewModel LoadEditListingPage(int id);
    }
}