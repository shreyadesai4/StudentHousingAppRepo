using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentHousingApp.Models;

namespace StudentHousingApp.Data
{
    public class PropertyContext : DbContext
    {
        public PropertyContext (DbContextOptions<PropertyContext> options)
            : base(options)
        {
        }

        public DbSet<StudentHousingApp.Models.Property> Property { get; set; } = default!;
    }
}
