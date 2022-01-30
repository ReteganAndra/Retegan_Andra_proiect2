using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Retegan_Andra_proiect2.Data;
using Retegan_Andra_proiect2.Models;

namespace Retegan_Andra_proiect2.Pages.Materii
{
    public class IndexModel : PageModel
    {
        private readonly Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context _context;

        public IndexModel(Retegan_Andra_proiect2.Data.Retegan_Andra_proiect2Context context)
        {
            _context = context;
        }

        public IList<Materie> Materie { get;set; }

        public async Task OnGetAsync()
        {
            Materie = await _context.Materie.ToListAsync();
        }
    }
}
