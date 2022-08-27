using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMobile.DAL.Models.Identity;
using MyMobile.DAL.Models.ViewModels.Account;
using MyMobile.DAL.Models.ViewModels.Create;
using MyMobile.Service.AccountService;

namespace MyMobile.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> UserManager { get; }
        private SignInManager<AppUser> SignInManager { get; }

        private readonly IUserService userService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<AppRole> roleManager, IUserService userPageService)//
        {
            UserManager = userManager;
            SignInManager = signInManager;
            userService = userPageService;
        }

        [Authorize]
        public async Task<IActionResult> MyAds()
        {
            return View(this.userService.LoadMyAds());
        }

        [Authorize]
        public async Task<IActionResult> Settings()
        {
            return View(this.userService.LoadSettings());
        }

        [Authorize]
        public async Task<IActionResult> SettingsStore(SettingsStoreViewModel formData)
        {
            this.userService.UpdateAccount(this.userService.GetUserId(), formData);
            return RedirectToAction("MyAds", "Account");
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return RedirectToAction("Register", "Account");
        }

        public async Task<IActionResult> LoginStore(LoginStoreViewModel formData)
        {
            var result = await SignInManager.PasswordSignInAsync(formData.Username, formData.Password, false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("MyAds", "Account");
            }
            else
            {
                return Content("Грешно потребителско име или парола.");
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterStoreVIewModel formData)
        {
            //return redirect to login form with user created msg
                AppUser user = userService.FindByEmail(formData.Email);
                if(user == null && ModelState.IsValid)
                {
                    user = new AppUser();
                    user.Email = formData.Email;
                    user.UserName = formData.Email;
                    
                    IdentityResult result = await UserManager.CreateAsync(user, formData.Password);

                    return Content("User was created.");
                }
            
                return Content("There is already a registered user with this email.");
        }
    }
}
