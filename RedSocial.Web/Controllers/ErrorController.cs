using RedSocial.Helper;
using System;
using System.Web.Mvc;

namespace RedSocial.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int statusCode, Exception exception)
        {
            ELog.Save(this, exception);

            switch (statusCode)
            {
                case 500:
                    ViewBag.Tipo = "Error 500 Acción Inesperada";
                    ViewBag.Detalle = "<b>Ooops !!</b>, no se que decirte .. solucionaremos este problema lo más pronto posible :(.";
                    break;
                case 404:
                    ViewBag.Tipo = "Error 404 Página no encontrada";
                    ViewBag.Detalle = "Lo sentimos esta página no se encuentra en nuestro servidor.";
                    break;
                default:
                    ViewBag.Tipo = "Error inesperado";
                    ViewBag.Detalle = exception.Message;
                    break;
            }

            return View();
        }
    }
}