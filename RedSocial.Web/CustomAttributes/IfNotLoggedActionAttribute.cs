using RedSocial.Helper;
using System.Web.Mvc;
using System.Web.Routing;

namespace RedSocial.Web.CustomAttributes
{
    public class IfNotLoggedActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!SessionHelper.ExistUserInSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index"
                }));
            }
        }
    }
}