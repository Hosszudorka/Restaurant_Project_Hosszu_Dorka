using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant_Project.Data;
using Restaurant_Project.Models;

namespace Restaurant_Project.Pages.Chefs
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
            return Page();
        }

        [BindProperty]
        public Chef Chef { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Chef.Add(Chef);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
