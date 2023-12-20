using RedSocial.Entity;
using RedSocial.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedSocial.Model
{
    public class ConocimientoModel
    {
        public List<Conocimiento> Listar()
        {
            List<Conocimiento> conocimientos = new List<Conocimiento>();

            try
            {
                using (var context = new RedSocialContext())
                {
                    // Otra forma de hacer query, usando Linq
                    conocimientos = (from c in context.Conocimiento
                                     orderby c.Nombre
                                     select c).ToList();
                }
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return conocimientos;
        }
    }
}
