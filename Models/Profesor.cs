using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retegan_Andra_proiect2.Models
{
    public class Profesor
    {
        public int ID { get; set; }
        public string NumeProfesor { get; set; }
        public ICollection<Catalog> Cataloage { get; set; }
    }
}
