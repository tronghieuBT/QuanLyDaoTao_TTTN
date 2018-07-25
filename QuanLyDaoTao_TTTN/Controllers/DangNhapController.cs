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
        public ActionResult KiemTraDangNhap(string userName, string password)
        {
            Authentication authen = new Authentication();
            string checkLogin = authen.CheckLogin(userName, password);
            if (checkLogin == null)
            {
                ModelState.AddModelError("", "Tai khoan sai");
                return RedirectToAction("Index");
            }
            if (checkLogin.Split(':')[0].Equals("SINHVIEN"))
            {
                return RedirectToAction("Index","SinhVien");
            }
            return RedirectToAction("Index", "GiaoVien");
        }
    }
}