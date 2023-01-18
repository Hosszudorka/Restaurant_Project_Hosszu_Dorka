using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant_Project.Data;
using Restaurant_Project.Models;

namespace Restaurant_Project.Pages.Chefs
{
    public class DetailsModel : PageModel
    {
        private readonly Restaurant_Project.Data.Restaurant_ProjectContext _context;

        public DetailsModel(Restaurant_Project.Data.Restaurant_ProjectContext context)
        {
            _context = context;
        }

      public Chef Chef { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Chef == null)
            {
                return NotFound();
            }

            var chef = await _context.Chef.FirstOrDefaultAsync(m => m.ID == id);
            if (chef == null)
            {
                return NotFound();
            }
            else 
            {
                Chef = chef;
            }
            return Page();
        }
    }
}
