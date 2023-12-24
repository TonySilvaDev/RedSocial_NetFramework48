using RedSocial.Helper;
using RedSocial.Model;
using RedSocial.Web.CustomAttributes;
using System.Web.Mvc;

namespace RedSocial.Web.Controllers
{
    [IfNotLoggedAction]
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