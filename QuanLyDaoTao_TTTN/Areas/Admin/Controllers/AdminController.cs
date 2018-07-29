using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CheckLogin(string email, string pass)
        {
            GiangVienBLL contextGV = new GiangVienBLL();
            GiangVien gv = contextGV.GetByEmailAndPass(email, pass);
            if(gv == null)
            {
                return Json(new { msg = "FALSE" });
            }
            Session["Admin"] = gv.HoVaTenLot + " " + gv.TenGV;
            return Json(new { msg = "OK" });
        }
    }
}