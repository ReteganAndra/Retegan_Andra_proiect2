using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retegan_Andra_proiect2.Models
{
    public class CatalogMaterie
    {
        public int ID { get; set; }
        public int CatalogID { get; set; }
        public Catalog Catalog { get; set; }
        public int MaterieID { get; set; }
        public Materie Materie { get; set; }
    }
}
