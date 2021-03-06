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
    public class DetailsModel : PageModel
    {
        private readonly Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context _context;

        public DetailsModel(Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context context)
        {
            _context = context;
        }

        public Catalog Catalog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Catalog = await _context.Catalog.FirstOrDefaultAsync(m => m.ID == id);

            if (Catalog == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
