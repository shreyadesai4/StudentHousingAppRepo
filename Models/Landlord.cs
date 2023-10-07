using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace StudentHousingApp.Models
{
    public class Landlord
    {
        public int LandlordID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // properties owned by landlord
        // public List<Property> Properties { get; set; }
    }
}
