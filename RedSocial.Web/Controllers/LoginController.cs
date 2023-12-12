using RedSocial.Entity;
using RedSocial.Model;
using RedSocial.Web.CustomAttributes;
using System.Web.Mvc;

namespace RedSocial.Web.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioModel um = new UsuarioModel();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OnlyAjaxRequest]
        public JsonResult Registrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                return Json(um.RegistroDeLogin(usuario));
            }
            else
            {
                return Json(new { response = false, message = "Ocurrió un error con la validación del formulario" });
            }
        }
    }
}