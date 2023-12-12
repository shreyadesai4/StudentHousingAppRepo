using Microsoft.AspNetCore.Mvc;
using System;

namespace StudentHousingApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Password { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
    }
}
