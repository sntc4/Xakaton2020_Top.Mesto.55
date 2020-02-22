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
    public class DeleteModel : PageModel
    {
        private readonly XakatonIT.Models.XakatonITContext _context;

        public DeleteModel(XakatonIT.Models.XakatonITContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parks Parks { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parks = await _context.Parks.FirstOrDefaultAsync(m => m.ID == id);

            if (Parks == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parks = await _context.Parks.FindAsync(id);

            if (Parks != null)
            {
                _context.Parks.Remove(Parks);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
