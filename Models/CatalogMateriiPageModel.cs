using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Retegan_Andra_proiect2.Data;

namespace Retegan_Andra_proiect2.Models
{
    public class CatalogMateriiPageModel : PageModel
    {
        public List<DateMaterieAsignata> AssignedCategoryDataList;
        public void PopulateDateMaterieAsignata(Retegan_Andra_proiect2Context context,
        Catalog catalog)
        {
            var materieAll = context.Materie;
            var catalogMaterii = new HashSet<int>(
            catalog.CatalogMaterii.Select(c => c.MaterieID)); //
            AssignedCategoryDataList = new List<DateMaterieAsignata>();
            foreach (var mat in materieAll)
            {
                AssignedCategoryDataList.Add(new DateMaterieAsignata
                {
                    MaterieID = mat.ID,
                    Nume = mat.NumeMaterie,
                    Asignat = catalogMaterii.Contains(mat.ID)
                });
            }
        }
        public void UpdateCatalogMaterii(Retegan_Andra_proiect2Context context,
        string[] selectedMaterii, Catalog catalogToUpdate)
        {
            if (selectedMaterii == null)
            {
                catalogToUpdate.CatalogMaterii = new List<CatalogMaterie>();
                return;
            }
            var selectedMateriiHS = new HashSet<string>(selectedMaterii);
            var catalogMaterii = new HashSet<int>
            (catalogToUpdate.CatalogMaterii.Select(c => c.Materie.ID));
            foreach (var mat in context.Materie)
            {
                if (selectedMateriiHS.Contains(mat.ID.ToString()))
                {
                    if (!catalogMaterii.Contains(mat.ID))
                    {
                        catalogToUpdate.CatalogMaterii.Add(
                        new CatalogMaterie
                        {
                            CatalogID = catalogToUpdate.ID,
                            MaterieID = mat.ID
                        });
                    }
                }
                else
                {
                    if (catalogMaterii.Contains(mat.ID))
                    {
                        CatalogMaterie courseToRemove
                        = catalogToUpdate
                        .CatalogMaterii
                        .SingleOrDefault(i => i.MaterieID == mat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
