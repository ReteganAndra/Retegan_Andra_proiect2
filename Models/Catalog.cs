using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Retegan_Andra_proiect2.Models
{
    public class Catalog
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele studentului trebuie sa fie de forma 'Nume'"), Required,StringLength(50, MinimumLength = 2)]
        [Display(Name = "Nume Student")]
        public string NumeStud { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prenumele studentului trebuie sa fie de forma 'Nume'"), Required, StringLength(50, MinimumLength = 2)]
        [Display(Name = "Prenume Student")]
        public string PrenumeStud { get; set; }
        [Range(1,10)]
        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "Nota")]
        public decimal NotaStud { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data examenului")]
        public DateTime DataExam { get; set; }
        public int ProfesorID { get; set; }
        public Profesor Profesor { get; set; }
        public ICollection<CatalogMaterie> CatalogMaterii { get; set; }
    }
}
