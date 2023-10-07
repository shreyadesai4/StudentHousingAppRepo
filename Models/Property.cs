using System;

namespace StudentHousingApp.Models
{
    public class Property
    {
        public int PropertyID { get; set; }
        public int LandlordID { get; set; }
        public string Address { get; set; }
        public decimal RentAmount { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
