using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult KiemTraDangNhap(string email, string pass)
        {
            Authentication authen = new Authentication();
            string checkLogin = authen.CheckLogin(email, pass);
            if (checkLogin == null)
            {
                ViewBag.Notifi = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                return RedirectToAction("Index");
            }
            if (checkLogin.Split(':')[0].Equals("SINHVIEN"))
            {
                SinhVienBLL contextSV = new SinhVienBLL();
                SinhVien sv = contextSV.GetById(checkLogin.Split(':')[1].ToString().Trim());
                if (sv != null)
                {
                    Session["GiangVien"] = Session["MaGV"] =null;
                    Session["SinhVien"] = sv.HoVaTenLot +" " + sv.TenSV;
                    Session["MaSV"] = sv.MaSV;
                    return RedirectToAction("Index", "SinhVien");
                }
                return RedirectToAction("Index");
            }
            GiangVienBLL contextGV = new GiangVienBLL();
            GiangVien gv = contextGV.GetById(checkLogin.Split(':')[1].ToString().Trim());
            if (gv != null)
            {
                Session["SinhVien"] = Session["MaSV"] = null;
                Session["GiangVien"] = gv.HoVaTenLot + " " + gv.TenGV;
                Session["MaGV"] = gv.MaGV;
                return RedirectToAction("Index", "GiangVien");
            }
            return RedirectToAction("Index");
        }
        public ActionResult DangXuat()
        {
            Session["SinhVien"] = Session["MaSV"] = Session["GiangVien"] = Session["MaGV"] = null;
            return RedirectToAction("Index", "DangNhap");
        }
    }
}