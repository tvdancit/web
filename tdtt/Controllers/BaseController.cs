using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using tdtt.Models.Login;

namespace tdtt.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ses = (LoginSession)Session[StaticSession.USER];
            if (ses == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}