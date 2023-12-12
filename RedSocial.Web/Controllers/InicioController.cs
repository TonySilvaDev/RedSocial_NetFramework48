using RedSocial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocial.Web.Controllers
{
    public class InicioController : Controller
    {
        private UsuarioModel um = new UsuarioModel();
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }
    }
}