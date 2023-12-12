using Microsoft.AspNetCore.Mvc;
using StudentHousingApp.Models;
using StudentHousingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StudentHousingApp.Controllers
{
    public class LandlordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LandlordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Displays the list of all landlords.
        public IActionResult LandlordIndex()
        {
            var landlords = _context.Landlords.ToList();
            return View(landlords);
        }

        // Displays details of a specific landlord including their properties.
        public IActionResult LandlordDetails(int id)
        {
            var landlord = _context.Landlords.Include(l => l.Properties).FirstOrDefault(l => l.LandlordID == id);

            if (landlord == null)
            {
                return NotFound();
            }

            return View(landlord);
        }

        // Gets details of a landlord for deletion confirmation.
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

        // Deletes a landlord after confirmation.
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

        // Displays the registration form for a new landlord.
        [HttpGet]
        public IActionResult LandlordRegistration()
        {
            var newLandlord = new Landlord();
            return View(newLandlord);
        }

        // Handles the registration of a new landlord.
        [HttpPost]
        public IActionResult LandlordRegistration(Landlord landlord)
        {
            if (ModelState.IsValid)
            {
                _context.Landlords.Add(landlord);
                _context.SaveChanges();

                return RedirectToAction("LandlordDetails", new { id = landlord.LandlordID });
            }

            return View(landlord);
        }

        // Displays the login form for a landlord.
        [HttpGet]
        public IActionResult LandlordLogin()
        {
            var newLandlord = new Landlord();
            return View(newLandlord);
        }

        // Handles the login process for a landlord.
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

        // Displays the properties owned by a specific landlord.
        public IActionResult LandlordProperties(int id)
        {
            var landlordProperties = _context.Properties.Where(p => p.TempLandlordID == id).ToList();
            return View(landlordProperties);
        }

        // Handles the creation of a new property owned by a landlord.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LandlordCreateProperty(Property property)
        {
            if (ModelState.IsValid)
            {
                _context.Properties.Add(property);
                _context.SaveChanges();

                return RedirectToAction("PropertyCreate", "Property");
            }

            return View(property);
        }
    }
}
