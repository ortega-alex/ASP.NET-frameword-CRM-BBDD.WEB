using Proyecto.Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.Logica.BL
{
    public class RelacionadoBl
    {
        public List<Models.Relacionado> GetRelacionados()
        {
            try
            {
                using (dbGeneralEntities db = new dbGeneralEntities())
                {
                    List<Models.Relacionado> relacionados = (from q in db.Relacionado
                                                             select new Models.Relacionado
                                                             {
                                                                 Id = q.Id,
                                                                 Descripcion = q.Descripcion
                                                             }).ToList();
                    return relacionados;
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
