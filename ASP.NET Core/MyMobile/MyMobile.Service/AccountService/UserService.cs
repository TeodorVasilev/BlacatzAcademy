using Microsoft.AspNetCore.Http;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.Identity;
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
        private readonly IHttpContextAccessor httpContext;
        private readonly IListingService listingService;

        public UserService(IHttpContextAccessor httpContext, IListingService listingService)
        {
            this.httpContext = httpContext;
            this.listingService = listingService;
        }

        public int GetUserId()
        {
            return int.Parse(httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public int GetUsersCount()
        {
            int count = 0;

            using (var context = new MyMobileContext())
            {
                count = context.Users.Count();
            }

            return count;
        }

        public AppUser FindByEmail(string email)
        {
            var user = new AppUser();

            using(var context = new MyMobileContext())
            {
                user = context.Users.Where(u => u.Email == email).FirstOrDefault();
            }

            return user;
        }

        public AppUser GetUserById(int id)
        {
            var user = new AppUser();

            using (var context = new MyMobileContext())
            {
                user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            }

            return user;
        }

        public List<AppUser> GetUsers()
        {
            ///////////////////////////////////////////////////////////////////////////////
            List<AppUser> users = new List<AppUser>();

            using(var context = new MyMobileContext())
            {
                users = context.Users.ToList();
            }

            return users;
            //////////////////////////////////////////////////////////////////////////////
        }

        public List<string> GetUserRoles(int userId)
        {
            ////////////////////////////////////////////////////////////////////////////
            List<int> userRolesIds = new List<int>();
            List<string> userRolesNames = new List<string>();
            List<AppRole> roles = new List<AppRole>();
            using (var context = new MyMobileContext())
            {
                userRolesIds = context.UserRoles.Where(ur => ur.UserId == userId).Select(r => r.RoleId).ToList();
                roles = context.Roles.ToList();
            }

            foreach (var userRoleId in userRolesIds)
            {
                userRolesNames.Add(roles.Where(r => r.Id == userRoleId).Select(r => r.Name).FirstOrDefault());
            }

            return userRolesNames;
            ////////////////////////////////////////////////////////////////////////////
        }

        public MyAdsViewModel LoadMyAds()
        {
           
            MyAdsViewModel model = new MyAdsViewModel();

            model.CarAdViewModel.CarAds = this.listingService.GetUserListings(GetUserId());

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
