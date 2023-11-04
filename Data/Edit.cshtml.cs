using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentHousingApp.Models;

namespace StudentHousingApp.Data
{
    public class EditModel : PageModel
    {
        private readonly StudentHousingApp.Data.PropertyContext _context;

        public EditModel(StudentHousingApp.Data.PropertyContext context)
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

            var property =  await _context.Property.FirstOrDefaultAsync(m => m.PropertyID == id);
            if (property == null)
            {
                return NotFound();
            }
            Property = property;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(Property.PropertyID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PropertyExists(int id)
        {
          return (_context.Property?.Any(e => e.PropertyID == id)).GetValueOrDefault();
        }
    }
}
