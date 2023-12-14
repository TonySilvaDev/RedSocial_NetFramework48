using RedSocial.Helper;
using RedSocial.Model;
using RedSocial.Web.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocial.Web.Controllers
{
    public class InicioController : Controller
    {
        private PublicacionModel pm = new PublicacionModel();

        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        [OnlyAjaxRequest]
        public PartialViewResult Publicaciones() // El Partial View ignora el layout
        {
            ViewBag.Usuario_id = SessionHelper.GetUser();
            return PartialView(pm.Listar());
        }
    }
}