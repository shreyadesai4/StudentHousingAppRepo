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
    public class DeleteModel : PageModel
    {
        private readonly StudentHousingApp.Data.PropertyContext _context;

        public DeleteModel(StudentHousingApp.Data.PropertyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Property Property { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return NotFound();
            }

            var property = await _context.Property.FirstOrDefaultAsync(m => m.PropertyID == id);

            if (property == null)
            {
                return NotFound();
            }
            else 
            {
                Property = property;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return NotFound();
            }
            var property = await _context.Property.FindAsync(id);

            if (property != null)
            {
                Property = property;
                _context.Property.Remove(Property);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
