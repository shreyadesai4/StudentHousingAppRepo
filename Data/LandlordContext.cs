using Microsoft.EntityFrameworkCore;
using StudentHousingApp.Models;

public class LandlordContext : DbContext
{
    public LandlordContext(DbContextOptions<LandlordContext> options) : base(options) { }

    public DbSet<Landlord> Landlords { get; set; }
}
