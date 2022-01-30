using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Retegan_Andra_proiect2.Data;
using Retegan_Andra_proiect2.Models;

namespace Retegan_Andra_proiect2.Pages.Materii
{
    public class EditModel : PageModel
    {
        private readonly Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context _context;

        public EditModel(Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Materie Materie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Materie = await _context.Materie.FirstOrDefaultAsync(m => m.ID == id);

            if (Materie == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Materie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterieExists(Materie.ID))
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

        private bool MaterieExists(int id)
        {
            return _context.Materie.Any(e => e.ID == id);
        }
    }
}
