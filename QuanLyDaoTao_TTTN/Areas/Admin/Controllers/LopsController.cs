using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAO;
using BLL;
using QuanLyDaoTao_TTTN.Areas.Admin.Fillter;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class LopsController : Controller
    {
        private LopBLL contextLop = new LopBLL();
        private KhoaBLL contextKhoa = new KhoaBLL();
        // GET: Admin/Lops
        [SessionCheck]
        public ActionResult Index()
        {
          
            var lops = contextLop.GetAll();
            return View(lops);
        }

        // GET: Admin/Lops/Details/5
        [SessionCheck]
        public ActionResult Details(string id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = contextLop.GetById(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // GET: Admin/Lops/Create
        [SessionCheck]
        public ActionResult Create()
        {   
            ViewBag.MaKhoa = new SelectList(contextKhoa.GetAll(), "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: Admin/Lops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Create([Bind(Include = "MaLop,TenLop,NienKhoa,MaKhoa")] Lop lop)
        {   
            if (ModelState.IsValid)
            {
                contextLop.Create(lop);   
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoa = new SelectList(contextKhoa.GetAll(), "MaKhoa", "TenKhoa", lop.MaKhoa);
            return View(lop);
        }

        // GET: Admin/Lops/Edit/5
        [SessionCheck]
        public ActionResult Edit(string id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = contextLop.GetById(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoa = new SelectList(contextKhoa.GetAll(), "MaKhoa", "TenKhoa", lop.MaKhoa);
            return View(lop);
        }

        // POST: Admin/Lops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Edit([Bind(Include = "MaLop,TenLop,NienKhoa,MaKhoa")] Lop lop)
        {   
            if (ModelState.IsValid)
            {
                contextLop.Edit(lop);
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoa = new SelectList(contextKhoa.GetAll(), "MaKhoa", "TenKhoa", lop.MaKhoa);
            return View(lop);
        }

        // GET: Admin/Lops/Delete/5
        [SessionCheck]
        public ActionResult Delete(string id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = contextLop.GetById(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // POST: Admin/Lops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult DeleteConfirmed(string id)
        {  
            contextLop.Delete(id);  
            return RedirectToAction("Index");
        }     
    }
}
