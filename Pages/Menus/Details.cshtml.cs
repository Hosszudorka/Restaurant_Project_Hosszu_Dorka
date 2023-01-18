using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant_Project.Data;
using Restaurant_Project.Models;

namespace Restaurant_Project.Pages.Menus
{
    public class DetailsModel : PageModel
    {
        private readonly Restaurant_Project.Data.Restaurant_ProjectContext _context;

        public DetailsModel(Restaurant_Project.Data.Restaurant_ProjectContext context)
        {
            _context = context;
        }

      public Menu Menu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.FirstOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }
            else 
            {
                Menu = menu;
            }
            return Page();
        }
    }
}
