using Microsoft.AspNetCore.Mvc;
using StudentHousingApp.Models;
using System.Diagnostics;

namespace StudentHousingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Displays the default home page.
        public IActionResult Index()
        {
            return View();
        }

        // Displays an information page.
        public IActionResult Info()
        {
            return View();
        }

        // Handles errors and displays an error page.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
