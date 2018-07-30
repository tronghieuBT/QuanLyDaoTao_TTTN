using BLL;
using DAO;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            Session["Admin"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult CheckLogin(string email, string pass)
        {   
            GiangVienBLL contextGV = new GiangVienBLL();
            GiangVien gv = contextGV.GetByEmailAndPass(email, pass);
            if (gv == null)
            {
                ViewBag.Msg = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                return RedirectToAction("Index");
            }
            Session["Admin"] = gv.HoVaTenLot + " " + gv.TenGV;
            return RedirectToAction("Index", "Khoas");
        }
    }
}