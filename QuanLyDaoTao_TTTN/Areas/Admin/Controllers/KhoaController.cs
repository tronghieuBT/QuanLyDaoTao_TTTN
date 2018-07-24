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
        #region   Index
        /// <summary>
        /// Get list khoa
        /// </summary>
        /// <returns>View </returns>
        public ActionResult Index()
        {                                  
            List<Khoa> lstKhoa = khoa.GetAll();
            //xét lst khoa bị null
            return View(lstKhoa);
        }
        #endregion

        #region  Edit
        /// <summary>
        /// View edit
        /// </summary>
        /// <param name="maKhoa"></param>
        /// <returns></returns>
        public ActionResult Edit(string maKhoa)
        {
            Khoa kh = khoa.GetById(maKhoa);
            if(kh == null)
            {
                return Content("<script>alret('Có lỗi trong quá trình kết nối SQL server')</script>");
            }
            return View(kh);
        }
        #endregion

        #region Save edit 
        /// <summary>
        ///  edit action
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        [HttpPost]  
        public JsonResult Edit(Khoa kh)
        {
            if (ModelState.IsValid)
            {
                if(kh == null)
                {
                    // lỗi phát sinh trong khi truyền dữ liệu
                    return Json(new {msg= "Dữ liệu rỗng"});
                }
                bool flag = khoa.Edit(kh);
                if (flag)
                {
                    return Json(new { msg = "Chỉnh sửa khoa thành công!" });
                }     
            }
            return Json(new { msg = "Lỗi" });
        }
        #endregion

        #region Form create
        /// <summary>
        /// Form create khoa
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region Save new Create
        /// <summary>
        /// Save new create
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create(Khoa kh)
        {
            if (ModelState.IsValid)
            {
                if (kh == null)
                {
                    // lỗi phát sinh trong khi truyền dữ liệu
                    return Json(new { msg = "Dữ liệu rỗng" });
                }
                bool flag = khoa.Create(kh);
                if (flag)
                {
                    return Json(new { msg = "Thêm khoa thành công!" });
                }
            }
            return Json(new { msg = "Lỗi" });
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="makhoa"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(string makhoa)
        {
            if (ModelState.IsValid)
            {
                if (makhoa == null)
                {
                    // lỗi phát sinh trong khi truyền dữ liệu
                    return Json(new { msg = "Dữ liệu rỗng" });
                }
                bool flag = khoa.Delete(makhoa);
                if (flag)
                {
                    return Json(new { msg = "Xóa khoa thành công!" });
                }
            }
            return Json(new { msg = "Lỗi ! Có thể khoa đã có lớp được mở." });
        }
        #endregion
    }
}