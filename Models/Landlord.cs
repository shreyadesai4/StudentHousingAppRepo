using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentHousingApp.Models
{
    public class Landlord
    {
        public int LandlordID { get; set; }
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
