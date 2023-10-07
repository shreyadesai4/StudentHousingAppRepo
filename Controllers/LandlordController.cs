using Microsoft.AspNetCore.Mvc;
using StudentHousingApp.Models;
using System.Collections.Generic;
using System.Linq;


namespace StudentHousingApp.Controllers
{
    public class LandlordController : Controller
    {
        // public? will change to database
        private static List<Landlord> landlords = new List<Landlord>
    {
        new Landlord { LandlordID = 1, FirstName = "J", LastName = "Nehru", Email = "nehru@india.com" },
        new Landlord { LandlordID = 2, FirstName = "M", LastName = "Gandhi", Email = "gandhi@india.com" },
        new Landlord { LandlordID = 3, FirstName = "B", LastName = "Singh", Email = "singh@india.com" },
    };

        // basic views

        public IActionResult LandlordIndex()
        {
            return View(landlords);
        }
        public IActionResult LandlordDetails(int id)
        {
            var landlord = landlords.FirstOrDefault(l => l.LandlordID == id);

            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

        [HttpGet]
        public IActionResult LandlordCreate()
        {
            var newLandlord = new Landlord();
            return View(newLandlord);
        }

        [HttpPost]
        public IActionResult LandlordCreate(Landlord landlord)
        {
            if (true) // ModelState.IsValid)
            {
                landlord.LandlordID = landlords.Max(l => l.LandlordID) + 1;
                landlords.Add(landlord);
                return RedirectToAction("LandlordIndex");
            }
            return View(landlord);
        }

        [HttpGet]
        public IActionResult LandlordEdit(int id)
        {
            var landlord = landlords.FirstOrDefault(l => l.LandlordID == id);

            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

        [HttpPost]
        public IActionResult LandlordEdit(int id, Landlord landlord)
        {
            var existingLandlord = landlords.FirstOrDefault(l => l.LandlordID == id);

            if (existingLandlord == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingLandlord.FirstName = landlord.FirstName;
                existingLandlord.LastName = landlord.LastName;
                existingLandlord.Email = landlord.Email;
                return RedirectToAction("LandlordIndex");
            }
            return View(landlord);
        }


        // registration
        // login
        // list properties owned by landlord
        // create property listing

        [HttpGet]
        public IActionResult LandlordDelete(int id)
        {
            var landlord = landlords.FirstOrDefault(l => l.LandlordID == id);

            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult LandlordDeleteConfirmed(int id)
        {
            var landlord = landlords.FirstOrDefault(l => l.LandlordID == id);

            if (landlord != null)
            {
                landlords.Remove(landlord);
            }

            return RedirectToAction("LandlordIndex");
        }

        // registration
        // login
        // list properties owned by landlord
        // create property listing

        [HttpGet]
        public IActionResult LandlordRegistration()
        {
            var newLandlord = new Landlord();
            return View(newLandlord);
        }

        [HttpPost]
        public IActionResult LandlordRegistration(Landlord landlord)
        {
            if (true) // ModelState.IsValid)
            {
                int newLandlordID = landlords.Max(l => l.LandlordID) + 1;
                landlord.LandlordID = newLandlordID;
                landlords.Add(landlord);
                return RedirectToAction("LandlordDetails", new { id = newLandlordID });
            }

            return View(landlord);
        }

        [HttpGet]
        public IActionResult LandlordLogin()
        {
            var newLandlord = new Landlord();
            return View(newLandlord);
        }

        [HttpPost]
        public IActionResult LandlordLogin(Landlord landlord)
        {
            if (ModelState.IsValid)
            {
                var authenticatedLandlord = landlords.FirstOrDefault(l =>
                    l.Email == landlord.Email && l.Password == landlord.Password);

                if (authenticatedLandlord != null)
                {
                    return RedirectToAction("LandlordDetails", new { id = authenticatedLandlord.LandlordID });
                }

                ModelState.AddModelError(string.Empty, "Invalid email or password");
            }

            return View(landlord);
        }

        public IActionResult LandlordProperties(int id)
        {
            int landlordID = id; // GetCurrentLandlordID();

            var landlordProperties = new List<StudentHousingApp.Models.Property> { }; // GetLandlordProperties(landlordID);

            return View(landlordProperties);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LandlordCreateProperty(Property property)
        {
            if (ModelState.IsValid)
            {
                int landlordID = 1; // GetCurrentLandlordID();

                var newProperty = new Property
                {
                    PropertyID = 3, // GenerateUniquePropertyID(),
                    LandlordID = landlordID,
                    Address = property.Address,
                    RentAmount = property.RentAmount,
                    Description = property.Description,
                    IsAvailable = true
                };

                // add to landlord's list of properties
                var landlord = landlords.FirstOrDefault(l => l.LandlordID == landlordID);
                if (landlord != null)
                {
                    landlord.Properties.Add(newProperty);
                }

                return RedirectToAction("PropertyCreate", "Property"); //, new { id = newProperty.PropertyID });
            }

            return View(property);
        }

    }

}
