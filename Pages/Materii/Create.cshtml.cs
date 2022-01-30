using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Retegan_Andra_proiect2.Data;
using Retegan_Andra_proiect2.Models;

namespace Retegan_Andra_proiect2.Pages.Materii
{
    public class CreateModel : PageModel
    {
        private readonly Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context _context;

        public CreateModel(Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Materie Materie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Materie.Add(Materie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
