using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retegan_Andra_proiect2.Models
{
    public class Materie
    {
        public int ID { get; set; }
        [Display(Name = "Materie")]
        public string NumeMaterie { get; set; }
        public ICollection<CatalogMaterie> CatalogMaterii { get; set; }
    }
}
