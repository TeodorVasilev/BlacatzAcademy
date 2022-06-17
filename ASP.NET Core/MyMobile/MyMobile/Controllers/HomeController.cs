using Microsoft.AspNetCore.Mvc;
using MyMobile.Models;
using MyMobile.Service.HomePageServices;
using System.Diagnostics;

namespace MyMobile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomePageService service = new HomePageService();
            return View(service.LoadHome());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}