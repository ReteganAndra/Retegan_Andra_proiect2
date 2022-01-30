using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retegan_Andra_proiect2.Models
{
    public class Materie
    {
        public int ID { get; set; }
        public string NumeMaterie { get; set; }
        public ICollection<CatalogMaterie> CatalogMaterii { get; set; }
    }
}
