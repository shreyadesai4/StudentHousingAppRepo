using Microsoft.EntityFrameworkCore;
using StudentHousingApp.Models;

namespace StudentHousingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Represents the collection of entities in the database
        public DbSet<Student> Students { get; set; }
        public DbSet<Landlord> Landlords { get; set; }
		public DbSet<Property> Properties { get; set; }

        // Constructor that takes DbContextOptions as a parameter
        // Automatically applies any pending migrations and creates the database if needed
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
