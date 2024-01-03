using RedSocial.Helper;
using RedSocial.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocial.Web.Areas.Admin.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioModel um = new UsuarioModel();

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
    }
}