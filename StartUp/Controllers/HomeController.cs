using Microsoft.AspNetCore.Mvc;
using StartUp.Models;
using System.Diagnostics;

namespace StartUp.Controllers
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
            return View();
        }

        public IActionResult Command()
        {
            return View("~/Views/Command/Command.cshtml");
        }

        public IActionResult Login()
        {
            return View("~/Views/Login/Login.cshtml");
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult PrimaryMaterial()
        {
            return View("~/Views/PrimaryMaterial/PrimaryMaterial.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}