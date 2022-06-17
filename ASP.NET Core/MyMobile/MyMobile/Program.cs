using Microsoft.AspNetCore.Authentication.Cookies;
using MyMobile.DAL.Data;
using MyMobile.DAL.Models.Identity;
using MyMobile.Service.AccountService;
using MyMobile.Service.AdministrationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyMobileContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddIdentity<AppUser, AppRole>(options =>
    options.User.RequireUniqueEmail = true)
    .AddEntityFrameworkStores<MyMobileContext>();

//builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LoginPage");

builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IRoleService, RoleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
