using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retegan_Andra_proiect2.Models
{
    public class DateCatalog
    {
        public IEnumerable<Catalog> Cataloage { get; set; }
        public IEnumerable<Materie> Materii { get; set; }
        public IEnumerable<CatalogMaterie> CatalogMaterii { get; set; }
    }
}
