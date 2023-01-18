using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant_Project.Data;
using Restaurant_Project.Models;

namespace Restaurant_Project.Pages.Restaurants
{
    public class CreateModel : PageModel
    {
        private readonly Restaurant_Project.Data.Restaurant_ProjectContext _context;

        public CreateModel(Restaurant_Project.Data.Restaurant_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ChefID"] = new SelectList(_context.Chef, "ID", "Name");
        ViewData["MenuID"] = new SelectList(_context.Menu, "ID", "Appetizer");
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaurant.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
