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

        // registration
        // login
        // list properties owned by landlord
        // create property listing

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

    }

}
