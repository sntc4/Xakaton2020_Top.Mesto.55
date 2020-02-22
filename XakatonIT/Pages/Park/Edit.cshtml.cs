using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XakatonIT.Models;

namespace XakatonIT.Pages.Park
{
    public class EditModel : PageModel
    {
        private readonly XakatonIT.Models.XakatonITContext _context;

        public EditModel(XakatonIT.Models.XakatonITContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Parks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParksExists(Parks.ID))
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

        private bool ParksExists(int id)
        {
            return _context.Parks.Any(e => e.ID == id);
        }
    }
}
