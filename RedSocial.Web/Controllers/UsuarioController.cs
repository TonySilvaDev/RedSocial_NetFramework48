using RedSocial.Entity;
using RedSocial.Helper;
using RedSocial.Model;
using RedSocial.Web.CustomAttributes;
using System.Web.Mvc;

namespace RedSocial.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioModel um = new UsuarioModel();
        private PublicacionModel pm = new PublicacionModel();

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

        [HttpPost]
        [OnlyAjaxRequest]
        public JsonResult Publicar(Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                return Json(pm.Registrar(publicacion));
            }
            else
            {
                return Json(new { response = false, message = "Ocurrió un error con la validación del formulario." });
            }
        }
    }
}