using System.Web;
using System.Web.Mvc;
using System.Web.Routing; 

namespace QuanLyDaoTao_TTTN.Areas.Admin.Fillter
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session != null && session["Admin"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "Admin" },
                                { "Action", "Index" }
                                });
            }
        }
    }
}