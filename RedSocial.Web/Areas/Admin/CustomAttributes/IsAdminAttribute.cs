using RedSocial.Helper;
using RedSocial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedSocial.Web.Areas.Admin.CustomAttributes
{
    public class IsAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!SessionHelper.ExistUserInSession())
            {
                filterContext.Result = new RedirectResult("~/");
            }

            if (!new UsuarioModel().EsAdmin(SessionHelper.GetUser()))
            {
                filterContext.Result = new RedirectResult("~/");
            }
        }
    }
}