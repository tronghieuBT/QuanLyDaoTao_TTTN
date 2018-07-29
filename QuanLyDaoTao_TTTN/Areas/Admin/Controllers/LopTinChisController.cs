using BLL;
using DAO;
using QuanLyDaoTao_TTTN.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class LopTinChisController : Controller
    {
        private LopTinChiBLL contextLopTC = new LopTinChiBLL();
        private GiangVienModel contextGV = new GiangVienModel();
        private MonHocBLL contextMH = new MonHocBLL();

        // GET: Admin/LopTinChis
        public ActionResult Index()
        {
            var lopTinChis = contextLopTC.GetAll();
            return View(lopTinChis);
        }

        // GET: Admin/LopTinChis/Details/5
        public ActionResult Details(int id)
        {
            LopTinChi lopTinChi = contextLopTC.GetById(id);
            if (lopTinChi == null)
            {
                return HttpNotFound();
            }
            return View(lopTinChi);
        }

        // GET: Admin/LopTinChis/Create
        public ActionResult Create()
        {
            ViewBag.MaGV = new SelectList(contextGV.GetALL(), "MaGV", "TenDayDu");
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH");

            var nienKhoa = from EnumNienKhoa e in Enum.GetValues(typeof(EnumNienKhoa))
                           select new
                           {
                               ID = (int)Enum.Parse(typeof(EnumNienKhoa), e.ToString())
                                     ,
                               Name = e.ToString()
                           };
            List<SelectListItem> listNienKhoa = new List<SelectListItem>();
            foreach( var item in nienKhoa)
            {
                if (item.ID >= DateTime.UtcNow.Year)
                {
                    SelectListItem slectListItem = new SelectListItem()
                    {
                        Text = item.ID.ToString(),
                        Value = item.ID.ToString()
                    };
                    listNienKhoa.Add(slectListItem);
                }
            }
            SelectList selectList = new SelectList(listNienKhoa, "Text", "Value");
            ViewBag.NienKhoa = selectList;
            return View();
        }

        // POST: Admin/LopTinChis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLopTC,HocKy,Nhom,NienKhoa,MaMonHoc,MaGV,TrangThai")] LopTinChi lopTinChi)
        {
            var nienKhoa = from EnumNienKhoa e in Enum.GetValues(typeof(EnumNienKhoa))
                           select new
                           {
                               ID = (int)Enum.Parse(typeof(EnumNienKhoa), e.ToString())
                                     ,
                               Name = e.ToString()
                           };
            SelectList selectList = new SelectList(nienKhoa, "ID", "ID");
            ViewBag.NienKhoa = selectList;
            if (ModelState.IsValid)
            {
                contextLopTC.Create(lopTinChi);
                return RedirectToAction("Index");
            }

            ViewBag.MaGV = new SelectList(contextGV.GetALL(), "MaGV", "TenDayDu", lopTinChi.MaGV);
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH", lopTinChi.MaMonHoc);
            return View(lopTinChi);
        }

        // GET: Admin/LopTinChis/Edit/5
        public ActionResult Edit(int id)
        {
            var nienKhoa = from EnumNienKhoa e in Enum.GetValues(typeof(EnumNienKhoa))
                           select new
                           {
                               ID = (int)Enum.Parse(typeof(EnumNienKhoa), e.ToString())
                                     ,
                               Name = e.ToString()
                           };
            SelectList selectList = new SelectList(nienKhoa, "ID", "ID");
            ViewBag.NienKhoa = selectList;
            LopTinChi lopTinChi = contextLopTC.GetById(id);
            if (lopTinChi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGV = new SelectList(contextGV.GetALL(), "MaGV", "TenDayDu", lopTinChi.MaGV);
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH", lopTinChi.MaMonHoc);
            return View(lopTinChi);
        }

        // POST: Admin/LopTinChis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLopTC,HocKy,Nhom,NienKhoa,MaMonHoc,MaGV,TrangThai")] LopTinChi lopTinChi)
        {
            if (ModelState.IsValid)
            {
                contextLopTC.Edit(lopTinChi);
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(contextGV.GetALL(), "MaGV", "TenDayDu", lopTinChi.MaGV);
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH", lopTinChi.MaMonHoc);
            return View(lopTinChi);
        }

        // GET: Admin/LopTinChis/Delete/5
        public ActionResult Delete(int id)
        {
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            LopTinChi lopTinChi = new LopTinChi();
            List<LopTinChi> lstLTC = contextLTC.GetAll();
            foreach(LopTinChi ltc in lstLTC)
            {
                if(ltc.MaLopTC == id)
                {
                    lopTinChi = ltc;
                }
            }
            if (lopTinChi == null)
            {
                return HttpNotFound();
            }
            return View(lopTinChi);
        }

        // POST: Admin/LopTinChis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contextLopTC.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetMaNhom(string maMonHoc, string nienKhoa, string maGiangVien, int hocKy)
        {
            if (string.IsNullOrEmpty(maMonHoc) || string.IsNullOrEmpty(nienKhoa) || string.IsNullOrEmpty(maGiangVien))
            {
                return Json(new { maNhom = "NULL" });
            }
            LopTinChiModel ltcModel = new LopTinChiModel();
            return Json(new { maNhom = ltcModel.GetMaNhom(maMonHoc, nienKhoa, maGiangVien, hocKy) });
        }
    }
}