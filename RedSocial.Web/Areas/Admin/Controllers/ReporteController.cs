﻿using RazorPDF;
using RedSocial.Model;
using RedSocial.Web.Areas.Admin.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocial.Web.Areas.Admin.Controllers
{
    [IsAdmin]
    public class ReporteController : Controller
    {
        private readonly ReporteModel rm = new ReporteModel();

        // GET: Admin/Reporte
        public ActionResult Index()
        {
            return View();
        }

        // Es dinamico es porque puede retornar PdfResult o Partial View
        public dynamic PublicacionesPorUsuario(string format)
        {
            if (format == "pdf")
            {
                return new PdfResult(rm.ReportePublicacionesPorUsuario(), "~/Areas/Admin/Views/Reporte/_PublicacionesPorUsuario.cshtml");
            }

            if (format == "excel")
            {
                Response.AddHeader("content-disposition", "attachment; filename=Archivo.xls");
                Response.ContentType = "application/ms-excel";
            }

            return PartialView("~/Areas/Admin/Views/Reporte/_PublicacionesPorUsuario.cshtml", rm.ReportePublicacionesPorUsuario());
        }
    }
}