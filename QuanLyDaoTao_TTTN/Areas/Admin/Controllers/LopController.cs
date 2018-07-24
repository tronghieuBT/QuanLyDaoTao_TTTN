using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class LopController : Controller
    {
        private LopBLL context = new LopBLL();

        #region Index
        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<Lop> lstLop = context.GetAll();
            return View(lstLop);
        }
        #endregion

        #region  Edit
        /// <summary>
        /// View edit
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns></returns>
        public ActionResult Edit(string maLop)
        {
            KhoaBLL kh = new KhoaBLL();
            ViewBag.MaKhoa = new SelectList(kh.GetAll(), "MaKhoa", "TenKhoa");
            Lop lp = context.GetById(maLop);
            if (lp == null)
            {
                return Content("<script>alret('Có lỗi trong quá trình kết nối SQL server')</script>");
            }
            return View(lp);
        }
        #endregion

        #region Save edit 
        /// <summary>
        ///  edit action
        /// </summary>
        /// <param name="lp"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Edit(Lop lp)
        {
            if (ModelState.IsValid)
            {
                if (lp == null)
                {
                    // lỗi phát sinh trong khi truyền dữ liệu
                    return Json(new { msg = "Dữ liệu rỗng" });
                }
                bool flag = context.Edit(lp);
                if (flag)
                {
                    return Json(new { msg = "Chỉnh sửa khoa thành công!" });
                }
            }
            return Json(new { msg = "Lỗi" });
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(string maLop)
        {
            if (ModelState.IsValid)
            {
                if (maLop == null)
                {
                    // lỗi phát sinh trong khi truyền dữ liệu
                    return Json(new { msg = "Dữ liệu rỗng" });
                }
                bool flag = context.Delete(maLop);
                if (flag)
                {
                    return Json(new { msg = "Xóa lớp thành công!" });
                }
            }
            return Json(new { msg = "Lỗi ! Có thể lớp đã chứa sinh viên." });
        }
        #endregion

        #region Form create
        /// <summary>
        /// Form create lop
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            if(ViewBag.Khoa == null)
            {
                KhoaBLL kh = new KhoaBLL();
                HeDaoTaoBLL hdt = new HeDaoTaoBLL();
                ViewBag.MaKhoa = new SelectList(kh.GetAll(), "MaKhoa", "TenKhoa",1);
                var directions = Enum.GetValues(typeof(EnumNienKhoa));
                ViewBag.NienKhoa = new SelectList(directions, "K", "NK");
                ViewBag.HDT = new SelectList(hdt.GetAll(), "MaHDT", "TenHDT",1);
            }
            return View();
        }
        #endregion

        #region Save new Create
        /// <summary>
        /// Save new create
        /// </summary>
        /// <param name="lp"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create(Lop lp)
        {
            if (ModelState.IsValid)
            {
                if (lp == null)
                {
                    // lỗi phát sinh trong khi truyền dữ liệu
                    return Json(new { msg = "Dữ liệu rỗng" });
                }
                int flag = context.Create(lp);
                if (flag == -1 || flag == 2)
                {
                    return Json(new { msg = "Thêm lớp lỗi!" });
                }
                if(flag == 0)
                {
                    return Json(new { msg = "Mã lớp đã tồn tại!" });
                }
                return Json(new { msg = "Thêm lớp thành công!" });
            }
            return Json(new { msg = "Lỗi" });
        }
        #endregion

        #region AutoCreateMaLop
        /// <summary>
        /// Auto create maLop
        /// </summary>
        /// <param name="maKhoa"></param>
        /// <param name="nienKhoa"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AutoCreateMaLop(string maKhoa, string nienKhoa, string maHDT)
        {
            if(string.IsNullOrEmpty(maKhoa)|| string.IsNullOrEmpty(nienKhoa))
            {
                return Json(new { msg = "" });
            }
            return Json(new { msg= context.CreateMaLop(maKhoa,nienKhoa,maHDT)});
        }
        #endregion
    }
}