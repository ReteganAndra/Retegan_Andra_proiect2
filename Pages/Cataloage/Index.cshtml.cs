using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Retegan_Andra_proiect2.Data;
using Retegan_Andra_proiect2.Models;

namespace Retegan_Andra_proiect2.Pages.Cataloage
{
    public class IndexModel : PageModel
    {
        private readonly Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context _context;

        public IndexModel(Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context context)
        {
            _context = context;
        }

        public IList<Catalog> Catalog { get;set; }
        public DateCatalog CatalogD { get; set; }
        public int CatalogID { get; set; }
        public int MaterieID { get; set; }

        public async Task OnGetAsync(int? id, int? materieID)
        {
            //Catalog = await _context.Catalog.Include(b=>b.Profesor).ToListAsync();
            CatalogD = new DateCatalog();
            CatalogD.Cataloage = await _context.Catalog
                                        .Include(b => b.Profesor)
                                        .Include(b => b.CatalogMaterii)
                                        .ThenInclude(b => b.Materie)
                                        .AsNoTracking()
                                        .OrderBy(b => b.NumeStud)
                                        .ToListAsync();
            if (id != null)
            {
                CatalogID = id.Value;
                Catalog catalog = CatalogD.Cataloage
                                .Where(i => i.ID == id.Value).Single();
                CatalogD.Materii = catalog.CatalogMaterii.Select(s => s.Materie);
            }
        }
    }
}
