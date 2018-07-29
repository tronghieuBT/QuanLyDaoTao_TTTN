using BLL;
using BLL.Common;
using DAO;
using QuanLyDaoTao_TTTN.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        public ActionResult Index()
        {
            if (Session["MaSV"] != null)
            {
                MonHocBLL contextMH = new MonHocBLL();
                ThoiKhoaBieuBLL contextTKB = new ThoiKhoaBieuBLL();
                SinhVienBLL contextSV = new SinhVienBLL();
                SinhVien sv = contextSV.GetById(Session["MaSV"].ToString().Trim());
                SupportThoiKhoaBieu spTKB = new SupportThoiKhoaBieu();
                List<SinhVien> lstSV = contextSV.GetAll();
                foreach (SinhVien sv1 in lstSV)
                {
                    if (sv1.MaSV == sv.MaSV)
                    {
                        sv = sv1;
                    }
                }
                ViewData["MaLop"] = sv.MaLop;
                ViewData["HDT"] = sv.HeDaoTao1.TenHDT;
                ViewData["Khoa"] = sv.Lop.NienKhoa;
                //sv.LopTinChis
                // lấy số tuần của năm và list ngày BD , KT của từng tuần lưu vào selectList
                Date dt = new Date();
                DateTime dtNow = DateTime.UtcNow;
                List<string> lstTuan = dt.GetListDate(dtNow.Year);
                //gán list các tuần vào selectList
                List<SelectListItem> weeks = lstTuan.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
                //Xem ngày hiện tại thuộc tuần nào trong năm
                int tuan = 0;
                for (int i = 0; i < lstTuan.Count; i++)
                {
                    DateTime tempDTStart = new DateTime();
                    DateTime tempDTEnd = new DateTime();
                    // Lấy datetime từ list Tuần và format về "dd/mm/yy"
                    tempDTStart = DateTime.Parse(lstTuan[i].Split('-')[1], new CultureInfo("en-US"));
                    tempDTEnd = DateTime.Parse(lstTuan[i].Split('-')[3], new CultureInfo("en-US"));
                    if (dtNow.DayOfYear >= tempDTStart.DayOfYear && dtNow.DayOfYear <= tempDTEnd.DayOfYear)
                    {
                        tuan = i;
                        break;
                    }
                }
                //Gán list tuần vào viewbag
                ViewBag.Weeks = new SelectList(weeks, "Text", "Value", tuan);
                ViewBag.WeekCurrent = lstTuan[tuan];
                //lọc các lớp tín chỉ mở mới xem thời khóa biểu;
                LopTinChiBLL contextLTC = new LopTinChiBLL();
                sv.LopTinChis = contextLTC.GetListLTCOpen(sv.LopTinChis);
                //// lấy thời khóa biểu của tất cả các lớp mà sinh viên đã đăng ký cùng với môn học của lớp tín chỉ
                List<SupportThoiKhoaBieu> lstSPTKB = spTKB.GetListSPTKB(lstTuan[tuan], sv.LopTinChis);
                return View(lstSPTKB);
            }
            return RedirectToAction("Index", "DangNhap");
        }

        public JsonResult LocTKBTHeoTuan(string tuan)
        {
            if (Session["MaSV"] != null)
            {
                MonHocBLL contextMH = new MonHocBLL();
                SupportThoiKhoaBieu spTKB = new SupportThoiKhoaBieu();
                SinhVienBLL contextSV = new SinhVienBLL();
                SinhVien sv = contextSV.GetById(Session["MaSV"].ToString().Trim());

                List<SinhVien> lstSV = contextSV.GetAll();
                foreach (SinhVien sv1 in lstSV)
                {
                    if (sv1.MaSV == sv.MaSV)
                    {
                        sv = sv1;
                    }
                }
                ViewData["MaLop"] = sv.MaLop;
                ViewData["HDT"] = sv.HeDaoTao1.TenHDT;
                ViewData["Khoa"] = sv.Lop.NienKhoa;

                List<SupportThoiKhoaBieu> lstSPTKB = spTKB.GetListSPTKB(tuan, sv.LopTinChis);
                return Json(new { ListData = lstSPTKB },JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "Lỗi" });
        }

        public ActionResult DangKyMonHoc()
        {
            if (Session["MaSV"] != null)
            {
                LopTinChiBLL contextLTC = new LopTinChiBLL();
                List<LopTinChi> lstLTC = contextLTC.GetAll();
                //  chỉ cho sinh viên đăng ký lớp đang mở
                lstLTC = contextLTC.GetListLTCOpen(lstLTC);
                ViewBag.ListLTC = lstLTC;
                return View(lstLTC);
            } 
            return RedirectToAction("Index", "DangNhap");
        }
    }
}