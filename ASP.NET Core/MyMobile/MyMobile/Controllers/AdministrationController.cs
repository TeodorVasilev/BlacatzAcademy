using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.Identity;
using MyMobile.DAL.Models.ViewModels.Administration;
using MyMobile.DAL.Models.ViewModels.Pages;
using MyMobile.Service.AccountService;
using MyMobile.Service.AdministrationService;
using MyMobile.Service.CarAdService;

namespace MyMobile.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdministrationController : Controller
    {
        private RoleManager<AppRole> RoleManager { get; }// create custom user and role manager classes
        private UserManager<AppUser> UserManager { get; }//
        private readonly IListingService listingService;
        private readonly IUserService userService;

        public AdministrationController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IListingService listingService, IUserService userService)
        {
            this.RoleManager = roleManager;
            this.UserManager = userManager;
            this.listingService = listingService;
            this.userService = userService;
        }

        public IActionResult AdminPanel()
        {
            AdminPanelViewModel model = new AdminPanelViewModel();
            model.UsersCount = userService.GetUsersCount();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleStore(CreateRoleViewModel formData)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole()
                {
                    Name = formData.RoleName
                };

                IdentityResult result = await RoleManager.CreateAsync(role);
            }

            return RedirectToAction("ListRoles", "Administration");
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            ListRolesViewModel model = new ListRolesViewModel();
            model.Roles = RoleManager.Roles.ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(int id)
        {
            EditRoleViewModel model = new EditRoleViewModel();

            var role = RoleManager.Roles.Where(r => r.Id == id).FirstOrDefault();

            model.RoleId = role.Id;
            model.RoleName = role.Name;

            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRoleStore(EditRoleViewModel formData)
        {
            if (ModelState.IsValid)
            {
                AppRole role = RoleManager.Roles.Where(x => x.Id == formData.RoleId).FirstOrDefault();
                role.Name = formData.RoleName;
                IdentityResult result = await RoleManager.UpdateAsync(role);
            }

            return RedirectToAction("ListRoles", "Administration");
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(int roleId)
        {
            ViewBag.RoleId = roleId;

            var role = await RoleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                return Content("Role cannot be found");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in UserManager.Users.ToList())
            {
                UserRoleViewModel userRoleViewModel = new UserRoleViewModel();

                userRoleViewModel.UserId = user.Id;
                userRoleViewModel.Username = user.UserName;

                bool isInRole = await UserManager.IsInRoleAsync(user, role.Name);

                if (isInRole)
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> formDataCollection, int roleId)
        {
            var role = RoleManager.Roles.Where(r => r.Id == roleId).FirstOrDefault();

            for (int i = 0; i < formDataCollection.Count; i++)
            {
                var user = UserManager.Users.Where(u => u.Id == formDataCollection[i].UserId).FirstOrDefault();

                IdentityResult result = null;

                if (formDataCollection[i].IsSelected && !await UserManager.IsInRoleAsync(user, role.Name))
                {
                    result = await UserManager.AddToRoleAsync(user, role.Name);
                }
                else if (!formDataCollection[i].IsSelected && await UserManager.IsInRoleAsync(user, role.Name))
                {
                    result = await UserManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < formDataCollection.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { Id = roleId });
                    }
                }
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        public async Task<IActionResult> ListUsers()
        {   ///////////////////////////////////////////////////////////////////
            ListUsersViewModel model = new ListUsersViewModel();
            List<AppUser> users = this.userService.GetUsers();
            var userViewModel = users.Select(u => new UserViewModel()
            {
                Id = u.Id,
                Username = u.UserName,
                RoleName = string.Join(", ", userService.GetUserRoles(u.Id))//UserManager.GetRolesAsync(u).Result.ToArray())
            }).ToList();

            foreach (var user in userViewModel)
            {
                user.AdsCount = this.listingService.GetUserListings(user.Id).Count();//
            }

            model.Users = userViewModel;
            return View(model);
            ///////////////////////////////////////////////////////////////////
        }

        public IActionResult ListAds()
        {
            var model = this.listingService.LoadAllListings();
            return View(model);
        }

        public IActionResult ListPendingAds()
        { 
            var model = this.listingService.LoadPendingListings();
            return View(model);
        }
    }
}
