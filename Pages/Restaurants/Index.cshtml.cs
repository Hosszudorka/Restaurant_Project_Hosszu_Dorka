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
    public class IndexModel : PageModel
    {
        private readonly Restaurant_Project.Data.Restaurant_ProjectContext _context;

        public IndexModel(Restaurant_Project.Data.Restaurant_ProjectContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Restaurant != null)
            {
                Restaurant = await _context.Restaurant
                .Include(r => r.Chef)
                .Include(r => r.Menu).ToListAsync();
            }
        }
    }
}
