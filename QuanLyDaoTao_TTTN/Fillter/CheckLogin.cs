using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyDaoTao_TTTN.Fillter
{
    public class CheckLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session != null && session["SinhVien"] == null && session["GiangVien"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                                { "Controller", "DangNhap" },
                                { "Action", "Index" }
                                });
            }
        }
    }
}