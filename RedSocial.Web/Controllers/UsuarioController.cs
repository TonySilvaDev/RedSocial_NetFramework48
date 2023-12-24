using RedSocial.Entity;
using RedSocial.Helper;
using RedSocial.Model;
using RedSocial.Web.CustomAttributes;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace RedSocial.Web.Controllers
{
    [IfNotLoggedAction]
    public class UsuarioController : Controller
    {
        private readonly UsuarioModel um = new UsuarioModel();
        private readonly ConocimientoModel cm = new ConocimientoModel();
        private readonly PublicacionModel pm = new PublicacionModel();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Perfil()
        {
            ViewBag.Conocimientos = cm.Listar();
            return View(um.Obtener(SessionHelper.GetUser()));
        }

        public ActionResult Ver(string name)
        {
            int id = ViewHelper.GetIdFromUrl(name);
            return View(um.Obtener(id));
        }

        [HttpPost]
        public JsonResult Actualizar(Usuario usuario, List<int> Conocimiento_id = null, HttpPostedFileBase file = null)
        {
            if (usuario.Contrasena == null)
            {
                ModelState.Remove("Contrasena");
            }

            if (ModelState.IsValid)
            {
                // Agregamos el usuario que queremos actualizar
                usuario.id = SessionHelper.GetUser();

                if (Conocimiento_id != null)
                {
                    // Agregamos todos los valores seleccionadosa una lista de UsuarioConocimiento
                    List<UsuarioConocimiento> conocimientos = new List<UsuarioConocimiento>();
                    foreach (var c in Conocimiento_id)
                    {
                        conocimientos.Add(new UsuarioConocimiento
                        {
                            Conocimiento_id = c,
                            Usuario_id = usuario.id
                        });
                    }

                    usuario.UsuarioConocimientos = conocimientos;
                }
                return Json(um.Actualizar(usuario, file));
            }
            else
            {
                return Json(new { response = false, message = "Ocurrió un error con la validación del formulario." });
            }
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

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~");
        }

        [OnlyAjaxRequest]
        public PartialViewResult Publicaciones(int usuario_id) // El Partial View ignora el layout
        {
            ViewBag.Usuario_id = usuario_id;
            /* Como en este caso la vista no se encuentra en view/usuario/publicaciones.cshtml
             * le indicamos que la busque en otro lado pasandole el primero parametro */
            return PartialView("~/Views/Inicio/Publicaciones.cshtml", pm.Listar(usuario_id));
        }
    }
}