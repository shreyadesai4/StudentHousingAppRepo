using Microsoft.AspNetCore.Mvc;
using StudentHousingApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace StudentHousingApp.Controllers
{

    public class LandlordController : Controller
    {

        private readonly LandlordContext _context;

        // list all landlords
        // view landlord details
        // delete landlords

        public LandlordController(LandlordContext context)
        {
            _context = context;
        }

        public IActionResult LandlordIndex()
        {
            var landlords = _context.Landlords.ToList();
            return View(landlords);
        }

        public IActionResult LandlordDetails(int id)
        {

            var landlord = _context.Landlords.FirstOrDefault(l => l.LandlordID == id);

            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

        /*

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
                _context.Landlords.Add(landlord);
                _context.SaveChanges();

                return RedirectToAction("LandlordIndex");
            }
            return View(landlord);
        }

        [HttpGet]
        public IActionResult LandlordEdit(int id)
        {
            var landlord = _context.Landlords.FirstOrDefault(l => l.LandlordID == id);

            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

        */

        [HttpGet]
        public IActionResult LandlordDelete(int id)
        {
            var landlord = _context.Landlords.FirstOrDefault(l => l.LandlordID == id);

            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

        [HttpPost, ActionName("LandlordDeleteConfirmed")]
        public IActionResult LandlordDeleteConfirmed(int id)
        {
            var landlord = _context.Landlords.FirstOrDefault(l => l.LandlordID == id);

            if (landlord == null)
            {
                return NotFound();
            }

            try
            {
                _context.Landlords.Remove(landlord);
                _context.SaveChanges();

                return RedirectToAction("LandlordIndex");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the landlord: " + ex.Message);
                return View("LandlordDelete", landlord);
            }
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
                _context.Landlords.Add(landlord);
                _context.SaveChanges();

                return RedirectToAction("LandlordDetails", new { id = landlord.LandlordID });
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
                var authenticatedLandlord = _context.Landlords.FirstOrDefault(l =>
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

                var landlord = _context.Landlords.FirstOrDefault(l => l.LandlordID == landlordID);
                if (landlord != null)
                {
                    landlord.Properties.Add(newProperty);
                    _context.SaveChanges();
                }

                return RedirectToAction("PropertyCreate", "Property"); //, new { id = newProperty.PropertyID });
      
            }
            return View(property);
        }
    }
}
