using Microsoft.AspNetCore.Mvc;
using StudentHousingApp.Models;

namespace StudentHousingApp.Controllers
{
    public class PropertyController : Controller
    {

        private static List<Property> properties = new List<Property>
        {
            new Property { PropertyID = 1, LandlordID = 1, Address = "666 Trafalgar Road", RentAmount = 1000, Description = "cozy af", IsAvailable = true },
            new Property { PropertyID = 2, LandlordID = 2, Address = "999 Grover Street", RentAmount = 800, Description = "gang violence", IsAvailable = true },
        };

        public IActionResult Index()
        {
            return View();
        }
    }
}
