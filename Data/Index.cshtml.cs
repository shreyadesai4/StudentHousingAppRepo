using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentHousingApp.Models;

namespace StudentHousingApp.Data
{
    public class IndexModel : PageModel
    {
        private readonly StudentHousingApp.Data.PropertyContext _context;

        public IndexModel(StudentHousingApp.Data.PropertyContext context)
        {
            _context = context;
        }

        public IList<Property> Property { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Property != null)
            {
                Property = await _context.Property.ToListAsync();
            }
        }
    }
}
