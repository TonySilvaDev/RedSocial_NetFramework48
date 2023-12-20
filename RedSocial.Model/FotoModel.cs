using RedSocial.Entity;
using RedSocial.Helper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace RedSocial.Model
{
    public class FotoModel
    {
        public static void Registrar(RedSocialContext context, HttpPostedFileBase file, int[] medidas, string FotoRelacion)
        {
            // Aplicamos la lógica para crear los thumbnails
            ImageHelper imgHelper = new ImageHelper();
            string nombre = ViewHelper.getNameForFiles() + Path.GetExtension(file.FileName);
            string ruta = HttpContext.Current.Server.MapPath("~/Uploads/" + nombre);

            file.SaveAs(ruta);

            imgHelper.Path = HttpContext.Current.Server.MapPath("~/Uploads/");
            imgHelper.Img = nombre;
            imgHelper.Scales = medidas;
            imgHelper.resizes();

            List<string> imagenes = imgHelper.getNewImages();

            Foto Foto = new Foto
            {
                Foto1 = imagenes[0],
                Foto2 = imagenes[1],
                Foto3 = imagenes[2],
                Relacion = FotoRelacion,
                FechaRegistro = ViewHelper.getDate(true)
            };

            context.Database.ExecuteSqlCommand("DELETE FROM Foto WHERE relacion = @r", new SqlParameter("r", FotoRelacion));
            context.Entry(Foto).State = EntityState.Added;
        }
    }
}
