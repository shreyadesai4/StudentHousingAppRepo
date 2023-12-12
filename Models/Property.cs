using System.ComponentModel.DataAnnotations;

namespace StudentHousingApp.Models
{
	public class Property
	{
		public int PropertyID { get; set; }
		[Required]
		public int TempLandlordID { get; set; }
		[Required]
		public string Address { get; set; } = "";
		[Required]
		public decimal RentAmount { get; set; }
		public string Description { get; set; } = "";
        public bool IsAvailable { get; set; }
	}
}
