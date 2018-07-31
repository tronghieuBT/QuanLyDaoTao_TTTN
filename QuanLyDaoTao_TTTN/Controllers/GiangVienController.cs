using BLL;
using BLL.Common;
using DAO;
using QuanLyDaoTao_TTTN.Fillter;
using QuanLyDaoTao_TTTN.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Controllers
{
    public class GiangVienController : Controller
    {
        // GET: GiangVien
        [CheckLogin]
        public ActionResult Index()
        {
            Date dt = new Date();
            DateTime dtNow = DateTime.UtcNow;
            ThoiKhoaBieuBLL contextTKB = new ThoiKhoaBieuBLL();
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            GiangVienBLL contextGV = new GiangVienBLL();
            KhoaBLL contextK = new KhoaBLL();
            GiangVien giangVien = contextGV.GetById(Session["MaGV"].ToString().Trim());
            giangVien.Khoa = contextK.GetById(giangVien.MaKhoa);

            ViewData["TrinhDo"] = giangVien.TrinhDo;
            ViewData["Khoa"] = giangVien.Khoa.TenKhoa;
            ViewData["GioiTinh"] = giangVien.GioiTinh;
            ViewData["Email"] = giangVien.Email;

            // lấy danh sách tuần của năm hiện tại
            List<string> lstTuan = dt.GetListDate(dtNow.Year);
            List<string> lstTuanNew = dt.GetListDate(dtNow.Year+1);
    
            //gán list các tuần vào selectList
            List<SelectListItem> weeks = lstTuan.Concat(lstTuanNew).Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            int tuan = 0;
            for (int i = 0; i < lstTuan.Count; i++)
            {
                // Lấy datetime từ list Tuần và format về "dd/mm/yy"
                DateTime tempDTStart = DateTime.Parse(lstTuan[i].Split('-')[1], new CultureInfo("en-US"));
                DateTime tempDTEnd = DateTime.Parse(lstTuan[i].Split('-')[3], new CultureInfo("en-US"));
                // kiểm tra ngày hiện tại có thuộc tuần i không, nếu có lưu lại và thoát vòng lặp
                if (dtNow.DayOfYear >= tempDTStart.DayOfYear && dtNow.DayOfYear <= tempDTEnd.DayOfYear)
                {
                    tuan = i;
                    break;
                }
            }
            //Gán list tuần vào viewbag
            ViewBag.Weeks = new SelectList(weeks, "Text", "Value", tuan);
            ViewBag.WeekCurrent = lstTuan[tuan];

            SupportThoiKhoaBieu spTKB = new SupportThoiKhoaBieu();
            GiangVienModel giangVienModel = new GiangVienModel();
            giangVienModel.LopTinChis = contextLTC.GetByMaGV(giangVien.MaGV);
            //lọc các lớp tín chỉ đang mở và có thời khóa biểu trong tuần hiện tại.
            List<SupportThoiKhoaBieu> lstSPTKB = spTKB.GetListSPTKB(lstTuan[tuan], giangVienModel.LopTinChis);
            return View(lstSPTKB);
        }

        [HttpPost]
        public JsonResult LocTKBTHeoTuan(string tuan)
        {
            if (Session["MaGV"] != null)
            {
                MonHocBLL contextMH = new MonHocBLL();
                SupportThoiKhoaBieu spTKB = new SupportThoiKhoaBieu();
                GiangVienBLL contextSV = new GiangVienBLL();
                KhoaBLL contextK = new KhoaBLL();
                GiangVien giangVien = contextSV.GetById(Session["MaGV"].ToString().Trim());
                giangVien.Khoa = contextK.GetById(giangVien.MaKhoa);

                ViewData["TrinhDo"] = giangVien.TrinhDo;
                ViewData["Khoa"] = giangVien.Khoa.TenKhoa;
                ViewData["GioiTinh"] = giangVien.GioiTinh;
                ViewData["Email"] = giangVien.Email;

                GiangVienModel gvModel = new GiangVienModel();
                LopTinChiBLL contextLTC = new LopTinChiBLL();
                gvModel.LopTinChis = contextLTC.GetByMaGV(giangVien.MaGV);

                List<SupportThoiKhoaBieu> lstSPTKB = spTKB.GetListSPTKB(tuan, gvModel.LopTinChis);
                return Json(new { ListData = lstSPTKB }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "Bạn không có quyền xem lịch giảng!" });
        }

    }
}