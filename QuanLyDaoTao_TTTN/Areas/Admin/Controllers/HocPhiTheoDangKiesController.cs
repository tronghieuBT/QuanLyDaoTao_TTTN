using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAO;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class HocPhiTheoDangKiesController : Controller
    {
        private QuanLyDaoTaoEntities db = new QuanLyDaoTaoEntities();

        // GET: Admin/HocPhiTheoDangKies
        public ActionResult Index()
        {
            var hocPhiTheoDangKies = db.HocPhiTheoDangKies.Include(h => h.GiaTinChi);
            return View(hocPhiTheoDangKies.ToList());
        }

        // GET: Admin/HocPhiTheoDangKies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhiTheoDangKy hocPhiTheoDangKy = db.HocPhiTheoDangKies.Find(id);
            if (hocPhiTheoDangKy == null)
            {
                return HttpNotFound();
            }
            return View(hocPhiTheoDangKy);
        }

        // GET: Admin/HocPhiTheoDangKies/Create
        public ActionResult Create()
        {
            ViewBag.MaGiaTC = new SelectList(db.GiaTinChis, "MaGiaTC", "MaHDT");
            return View();
        }

        // POST: Admin/HocPhiTheoDangKies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SoTienDong,SoTinChi,NienKhoa,GhiChu,MaGiaTC")] HocPhiTheoDangKy hocPhiTheoDangKy)
        {
            if (ModelState.IsValid)
            {
                db.HocPhiTheoDangKies.Add(hocPhiTheoDangKy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGiaTC = new SelectList(db.GiaTinChis, "MaGiaTC", "MaHDT", hocPhiTheoDangKy.MaGiaTC);
            return View(hocPhiTheoDangKy);
        }

        // GET: Admin/HocPhiTheoDangKies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhiTheoDangKy hocPhiTheoDangKy = db.HocPhiTheoDangKies.Find(id);
            if (hocPhiTheoDangKy == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGiaTC = new SelectList(db.GiaTinChis, "MaGiaTC", "MaHDT", hocPhiTheoDangKy.MaGiaTC);
            return View(hocPhiTheoDangKy);
        }

        // POST: Admin/HocPhiTheoDangKies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SoTienDong,SoTinChi,NienKhoa,GhiChu,MaGiaTC")] HocPhiTheoDangKy hocPhiTheoDangKy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocPhiTheoDangKy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGiaTC = new SelectList(db.GiaTinChis, "MaGiaTC", "MaHDT", hocPhiTheoDangKy.MaGiaTC);
            return View(hocPhiTheoDangKy);
        }

        // GET: Admin/HocPhiTheoDangKies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocPhiTheoDangKy hocPhiTheoDangKy = db.HocPhiTheoDangKies.Find(id);
            if (hocPhiTheoDangKy == null)
            {
                return HttpNotFound();
            }
            return View(hocPhiTheoDangKy);
        }

        // POST: Admin/HocPhiTheoDangKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HocPhiTheoDangKy hocPhiTheoDangKy = db.HocPhiTheoDangKies.Find(id);
            db.HocPhiTheoDangKies.Remove(hocPhiTheoDangKy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
