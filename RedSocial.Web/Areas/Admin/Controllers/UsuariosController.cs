using RedSocial.Entity;
using RedSocial.Helper;
using RedSocial.Model;
using RedSocial.Web.Areas.Admin.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocial.Web.Areas.Admin.Controllers
{
    [IsAdmin]
    public class UsuariosController : Controller
    {
        private readonly UsuarioModel um = new UsuarioModel();
        private readonly ConocimientoModel cm = new ConocimientoModel();

        // GET: Admin/Usuarios
        public ActionResult Index(int page = 1)
        {
            //int take = 10; // Cantidad de registros a traer por página, yo pongo esta cantidad opr el ejemplo
            int take = Convert.ToInt32(ConfigurationManager.AppSettings["NumRegistros"]);

            // Paginación
            Pagination pagination = new Pagination();

            pagination.BaseUrl = ViewHelper.BaseUrl("Admin/Usuarios?"); // La dirección actual
            pagination.TotalRows = um.Total();
            pagination.CurPage = page;
            pagination.PerPage = take;

            ViewBag.Paginacion = pagination.GetPageLinks();

            // Restamos -1 ya que linq requiere comenzar en 0
            return View(um.Listar(take, page - 1));
        }

        public ActionResult Ver(int id)
        {
            ViewBag.Conocimientos = cm.Listar();
            return View(um.Obtener(id));
        }

        public JsonResult Actualizar(Usuario usuario, List<int> Conocimiento_id = null, HttpPostedFileBase file = null)
        {
            if (usuario.Contrasena == null)
            {
                ModelState.Remove("Contrasena");
            }

            if (ModelState.IsValid)
            {

                if (Conocimiento_id != null)
                {
                    // Agregamos todo los valores seleccionados a una lista de UsuarioConocimiento
                    List<UsuarioConocimiento> conocimientos = new List<UsuarioConocimiento>();
                    foreach (var c in Conocimiento_id) conocimientos.Add(new UsuarioConocimiento { Conocimiento_id = c, Usuario_id = usuario.id });

                    usuario.UsuarioConocimientos = conocimientos;
                }
                var rm = um.Actualizar(usuario, file);
                if (rm.response) rm.href = "admin/usuarios";

                return Json(rm);
            }
            else
            {
                return Json(new { response = false, message = "Ocurrio un error con la validación del Formulario." });
            }
        }
    }
}