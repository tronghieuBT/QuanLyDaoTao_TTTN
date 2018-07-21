using BLL;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KiemTraDangNhap(string email, string pass)
        {
            Authentication authen = new Authentication();
            string checkLogin = authen.CheckLogin(email, pass);
            if (checkLogin == null)
            {
                return Content("False");
            }
            if (checkLogin.Split(':')[0].Equals("SINHVIEN"))
            {
                return RedirectToAction("", "");
            }
            return RedirectToAction("", "");
        }
    }
}