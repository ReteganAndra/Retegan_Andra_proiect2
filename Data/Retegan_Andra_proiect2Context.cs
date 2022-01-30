using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Retegan_Andra_proiect2.Models;

namespace Retegan_Andra_proiect2.Data
{
    public class Retegan_Andra_proiect2Context : DbContext
    {
        public Retegan_Andra_proiect2Context (DbContextOptions<Retegan_Andra_proiect2Context> options)
            : base(options)
        {
        }

        public DbSet<Retegan_Andra_proiect2.Models.Catalog> Catalog { get; set; }

        public DbSet<Retegan_Andra_proiect2.Models.Profesor> Profesor { get; set; }

        public DbSet<Retegan_Andra_proiect2.Models.Materie> Materie { get; set; }
    }
}
