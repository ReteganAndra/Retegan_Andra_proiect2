using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Retegan_Andra_proiect2.Data;
using Retegan_Andra_proiect2.Models;

namespace Retegan_Andra_proiect2.Pages.Cataloage
{
    public class CreateModel : CatalogMateriiPageModel
    {
        private readonly Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context _context;

        public CreateModel(Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProfesorID"] = new SelectList(_context.Set<Profesor>(), "ID", "NumeProfesor");
            var catalog = new Catalog();
            catalog.CatalogMaterii = new List<CatalogMaterie>();
            PopulateDateMaterieAsignata(_context, catalog);
            return Page();
        }

        [BindProperty]
        public Catalog Catalog { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCatalog = new Catalog();
            if (selectedCategories != null)
            {
                newCatalog.CatalogMaterii = new List<CatalogMaterie>();
                foreach (var mat in selectedCategories)
                {
                    var matToAdd = new CatalogMaterie
                    {
                        MaterieID = int.Parse(mat)
                    };
                    newCatalog.CatalogMaterii.Add(matToAdd);
                }
            }
            if (await TryUpdateModelAsync<Catalog>(
                                 newCatalog,
                                 "Catalog",
                                 i => i.NumeStud, i => i.PrenumeStud,
                                 i => i.NotaStud, i => i.DataExam, i => i.ProfesorID))
            {
                _context.Catalog.Add(newCatalog);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateDateMaterieAsignata(_context, newCatalog);
            return Page();
        }
        /*
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Catalog.Add(Catalog);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
        */
    }
}
