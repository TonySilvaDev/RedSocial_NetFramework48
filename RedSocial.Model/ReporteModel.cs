using RedSocial.Entity;
using RedSocial.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocial.Model
{
    public class ReporteModel
    {
        public List<Reporte> ReportePublicacionesPorUsuario()
        {
            var reporte = new List<Reporte>();

            using (var context = new RedSocialContext())
            {
                try
                {
                    reporte = context.Database
                        .SqlQuery<Reporte>("[USP_ReportePublicacionesPorUsuario]")
                        .ToList();
                }
                catch (Exception e)
                {
                    ELog.Save(this, e);
                }
            }

            return reporte;
        }
    }
}
