using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retegan_Andra_proiect2.Models
{
    public class Profesor
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele profesorului trebuie sa fie de forma 'Nume Prenume'"), Required,StringLength(50, MinimumLength = 3)]
        [Display(Name = "Profesor (Nume Prenume)")]
        public string NumeProfesor { get; set; }
        public ICollection<Catalog> Cataloage { get; set; }
    }
}
