using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant_Project.Data;
using Restaurant_Project.Models;

namespace Restaurant_Project.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly Restaurant_Project.Data.Restaurant_ProjectContext _context;

        public DeleteModel(Restaurant_Project.Data.Restaurant_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Restaurant == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant.FirstOrDefaultAsync(m => m.ID == id);

            if (restaurant == null)
            {
                return NotFound();
            }
            else 
            {
                Restaurant = restaurant;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Restaurant == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurant.FindAsync(id);

            if (restaurant != null)
            {
                Restaurant = restaurant;
                _context.Restaurant.Remove(Restaurant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
