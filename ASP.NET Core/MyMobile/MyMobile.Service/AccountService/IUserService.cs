using MyMobile.DAL.Models.ViewModels.Account;
using MyMobile.DAL.Models.ViewModels.Pages;

namespace MyMobile.Service.AccountService
{
    public interface IUserService
    {
        int GetUserId();

        MyAdsViewModel LoadMyAds();

        void UpdateAccount(int id, SettingsStoreViewModel formData);

        SettingsViewModel LoadSettings();
    }
}