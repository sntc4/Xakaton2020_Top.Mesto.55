using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using XakatonIT.Models;

namespace XakatonIT.Pages.Park
{
    public class IndexModel : PageModel
    {
        private readonly XakatonIT.Models.XakatonITContext _context;

        public IndexModel(XakatonIT.Models.XakatonITContext context)
        {
            _context = context;
        }

        public IList<Parks> Parks { get;set; }

        public async Task OnGetAsync()
        {
            Parks = await _context.Parks.ToListAsync();
        }
    }
}
