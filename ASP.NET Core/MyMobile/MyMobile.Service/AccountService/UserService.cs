using Microsoft.AspNetCore.Http;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.ViewModels.Account;
using MyMobile.DAL.Models.ViewModels.Pages;
using MyMobile.Service.CarAdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyMobile.Service.AccountService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public int GetUserId()
        {
            return int.Parse(_httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        //loading user page
        //fix looks of the userpage
        public MyAdsViewModel LoadMyAds()
        {
            MyAdsViewModel model = new MyAdsViewModel();
            var listingService = new ListingService();

            model.CarAdViewModel.CarAds = listingService.GetUserListings(GetUserId());

            return model;
        }

        public void UpdateAccount(int id, SettingsStoreViewModel formData)
        {
            using (var context = new MyMobileContext())
            {
                var user = context.Users.Where(u => u.Id == id).FirstOrDefault();

                if(formData.FirstName != null)
                {
                    user.FirstName = formData.FirstName;
                }

                if(formData.LastName != null)
                {
                    user.LastName = formData.LastName;
                }

                if(formData.Address != null)
                {
                    user.Adress = formData.Address;
                }

                context.SaveChanges();
            }
        }

        public SettingsViewModel LoadSettings()
        {
            SettingsViewModel model = new SettingsViewModel();

            using(var context = new MyMobileContext())
            {
                var user = context.AppUsers.Where(u => u.Id == GetUserId()).FirstOrDefault();

                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Address = user.Adress;
            }

            return model;
        }
    }
}
