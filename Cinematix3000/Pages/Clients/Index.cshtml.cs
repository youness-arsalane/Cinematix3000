using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cinematix3000.Data;
using Cinematix3000.Models;

namespace Cinematix3000.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly Cinematix3000.Data.Cinematix3000Context _context;

        public IndexModel(Cinematix3000.Data.Cinematix3000Context context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; }

        public async Task OnGetAsync()
        {
            Client = await _context.Clients
                .Include(v => v.Reservations)
                .ToListAsync();
        }
    }
}
