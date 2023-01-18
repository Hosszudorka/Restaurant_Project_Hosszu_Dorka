using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant_Project.Data;
using Restaurant_Project.Models;

namespace Restaurant_Project.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly Restaurant_Project.Data.Restaurant_ProjectContext _context;

        public EditModel(Restaurant_Project.Data.Restaurant_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Restaurant == null)
            {
                return NotFound();
            }

            var restaurant =  await _context.Restaurant.FirstOrDefaultAsync(m => m.ID == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            Restaurant = restaurant;
           ViewData["ChefID"] = new SelectList(_context.Chef, "ID", "Name");
           ViewData["MenuID"] = new SelectList(_context.Menu, "ID", "Appetizer");
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

            _context.Attach(Restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(Restaurant.ID))
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

        private bool RestaurantExists(int id)
        {
          return _context.Restaurant.Any(e => e.ID == id);
        }
    }
}
