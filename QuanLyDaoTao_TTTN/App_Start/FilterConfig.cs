using System.Web;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
