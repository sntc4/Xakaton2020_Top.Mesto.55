using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using XakatonIT.Models;

namespace XakatonIT.Pages.Park
{
    public class CreateModel : PageModel
    {
        private readonly XakatonIT.Models.XakatonITContext _context;

        public CreateModel(XakatonIT.Models.XakatonITContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Parks Parks { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Parks.Add(Parks);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
