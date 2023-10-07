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

        public IActionResult PropertyIndex()
        {
            return View(properties);
        }

        public IActionResult PropertyDetails(int id)
        {
            var property = properties.FirstOrDefault(p => p.PropertyID == id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpGet]
        public IActionResult PropertyCreate()
        {
            var newProperty = new Property();
            return View(newProperty);
        }

        [HttpPost]
        public IActionResult PropertyCreate(Property property)
        {
            if (ModelState.IsValid)
            {
                int newPropertyID = properties.Max(p => p.PropertyID) + 1;

                property.PropertyID = newPropertyID;

                // property.LandlordID = GetCurrentLandlordID();

                properties.Add(property);

                return RedirectToAction("PropertyIndex");
            }

            return View(property);
        }
    }
}
