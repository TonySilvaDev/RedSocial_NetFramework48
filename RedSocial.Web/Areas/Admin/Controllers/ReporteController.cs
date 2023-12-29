using RedSocial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocial.Web.Areas.Admin.Controllers
{
    public class ReporteController : Controller
    {
        private ReporteModel rm = new ReporteModel();

        // GET: Admin/Reporte
        public ActionResult Index()
        {
            return View();
        }

        // Es dinamico es porque puede retornar PdfResult o Partial View
        public dynamic PublicacionesPorUsuario(string format)
        {
            if (format == "excel")
            {
                Response.AddHeader("content-disposition", "attachment; filename=Archivo.xls");
                Response.ContentType = "application/ms-excel";
            }

            return PartialView("~/Areas/Admin/Views/Reporte/_PublicacionesPorUsuario.cshtml", rm.ReportePublicacionesPorUsuario());
        }
    }
}