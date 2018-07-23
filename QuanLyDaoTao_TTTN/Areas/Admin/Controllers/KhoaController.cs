using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class KhoaController : Controller
    {
        private KhoaBLL khoa = new KhoaBLL();
        // GET: Admin/Khoa
        public ActionResult Index()
        {                                  
            List<Khoa> lstKhoa = khoa.GetAll();
            //xét lst khoa bị null
            return View(lstKhoa);
        }

        public ActionResult Edit(string maKhoa)
        {
            Khoa kh = khoa.GetById(maKhoa);
            if(kh == null)
            {
                return Content("<script>alret('Có lỗi trong quá trình kết nối SQL server')</script>");
            }
            return View(kh);
        }
        [HttpPost]  
        public JsonResult Edit(Khoa kh)
        {
            if (ModelState.IsValid)
            {
                if(khoa == null)
                {
                    // lỗi phát sinh trong khi truyền dữ liệu
                    return Json(new {msg= "Dữ liệu rỗng"});
                }
                bool flag = khoa.Edit(kh);
                if (flag)
                {
                    return Json(new { msg = "Cập nhật khoa thành công!" });
                }     
            }
            return Json(new { msg = "Lỗi" });
        }
    }
}