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

namespace Retegan_Andra_proiect2.Pages.Cataloage
{
    public class EditModel : CatalogMateriiPageModel
    {
        private readonly Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context _context;

        public EditModel(Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Catalog Catalog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Catalog = await _context.Catalog.Include(b => b.Profesor)
                                    .Include(b => b.CatalogMaterii).ThenInclude(b => b.Materie)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(m => m.ID == id);

            if (Catalog == null)
            {
                return NotFound();
            }
            PopulateDateMaterieAsignata(_context, Catalog);
            ViewData["ProfesorID"] = new SelectList(_context.Set<Profesor>(), "ID", "NumeProfesor");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var catalogToUpdate = await _context.Catalog
                                             .Include(i => i.Profesor)
                                             .Include(i => i.CatalogMaterii)
                                             .ThenInclude(i => i.Materie)
                                             .FirstOrDefaultAsync(s => s.ID == id);
            if (catalogToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Catalog>(
                            catalogToUpdate,
                            "Catalog",
                            i => i.NumeStud, i => i.PrenumeStud,
                            i => i.NotaStud, i => i.DataExam, i => i.Profesor))
            {
                UpdateCatalogMaterii(_context, selectedCategories, catalogToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Catalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogExists(Catalog.ID))
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
        */
            /*
                private bool CatalogExists(int id)
            {
                return _context.Catalog.Any(e => e.ID == id);
            }
            */
            UpdateCatalogMaterii(_context, selectedCategories, catalogToUpdate);
            PopulateDateMaterieAsignata(_context, catalogToUpdate);
            return Page();
        }
    }
}
