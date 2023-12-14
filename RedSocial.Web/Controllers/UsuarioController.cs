using RedSocial.Helper;
using RedSocial.Model;
using System.Web.Mvc;

namespace RedSocial.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioModel um = new UsuarioModel();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ver(string name)
        {
            int id = ViewHelper.GetIdFromUrl(name);
            return View(um.Obtener(id));
        }
    }
}