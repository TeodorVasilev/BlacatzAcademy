using MyMobile.DAL.Models.Identity;
using MyMobile.DAL.Models.ViewModels.Account;
using MyMobile.DAL.Models.ViewModels.Pages;

namespace MyMobile.Service.AccountService
{
    public interface IUserService
    {
        int GetUserId();
        int GetUsersCount();
        MyAdsViewModel LoadMyAds();
        void UpdateAccount(int id, SettingsStoreViewModel formData);
        SettingsViewModel LoadSettings();
        AppUser FindByEmail(string email);
        AppUser GetUserById(int id);
        List<AppUser> GetUsers();
        List<string> GetUserRoles(int id);
    }
}