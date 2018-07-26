using BLL;
using BLL.Common;
using DAO;
using QuanLyDaoTao_TTTN.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
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
                MonHocBLL contecxMH = new MonHocBLL();
                ThoiKhoaBieuBLL contextTKB = new ThoiKhoaBieuBLL();
                SinhVienBLL contextSV = new SinhVienBLL();
                SinhVien sv = contextSV.GetById(Session["MaSV"].ToString().Trim());    
                sv.LopTinChis
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
                    tempDTEnd = DateTime.Parse(lstTuan[i].Split('-')[1], new CultureInfo("en-US"));
                    tempDTEnd = DateTime.Parse(lstTuan[i].Split('-')[3], new CultureInfo("en-US"));
                    if (dtNow.DayOfYear >= tempDTStart.DayOfYear && dtNow.DayOfYear <= tempDTEnd.DayOfYear)
                    {
                        tuan = i+1;
                        break;
                    }
                }
                //Gán vào viewbag và chọn item default là tuần hiện tại  
                ViewBag.Selected = weeks[tuan];
                ViewBag.Weeks = new SelectList(weeks, "Text", "Value");

                // lấy thời khóa biểu của tất cả các lớp mà sinh viên đã đăng ký cùng với môn học của lớp tín chỉ
                List<SupportThoiKhoaBieu> lstSPTKB = new List<SupportThoiKhoaBieu>();
                foreach(var item in sv.LopTinChis)
                {
                    SupportThoiKhoaBieu spTKB = new SupportThoiKhoaBieu(); 
                    spTKB.listTKB = contextTKB.GetByMaLopTC(item.MaLopTC);
                    //duyệt danh sách thời khóa biểu của lớp tín chỉ đăng ký xem đã hoàn thành chưa
                    foreach(var tkb in spTKB.listTKB)
                    {
                        if(tkb.Ngay.Year >= dtNow.Year)
                        {
                            spTKB.MonHoc = contecxMH.GetById(item.MaMonHoc);     
                            lstSPTKB.Add(spTKB);
                        }
                    }   
                }  
                return View(lstSPTKB);
            }
            return RedirectToAction("Index","DangNhap");
        }
    }
}