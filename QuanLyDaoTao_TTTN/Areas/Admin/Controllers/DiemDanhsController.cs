using BLL;
using DAO;
using QuanLyDaoTao_TTTN.Areas.Admin.Fillter;
using System.Net;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class DiemDanhsController : Controller
    {
        private DiemDanhBLL contextDiemDanh = new DiemDanhBLL();
        private LopTinChiBLL contextLopTC = new LopTinChiBLL();
        private SinhVienBLL contextSinhVien = new SinhVienBLL();

        // GET: Admin/DiemDanhs
        [SessionCheck]
        public ActionResult Index()
        {   
            var diemDanhs = contextDiemDanh.GetAll();
            return View(diemDanhs);
        }

        // GET: Admin/DiemDanhs/Details/5
        [SessionCheck]
        public ActionResult Details(string id)
        {   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemDanh diemDanh = contextDiemDanh.GetById(id);
            if (diemDanh == null)
            {
                return HttpNotFound();
            }
            return View(diemDanh);
        }

        // GET: Admin/DiemDanhs/Create
        [SessionCheck]
        public ActionResult Create()
        {   
            ViewBag.MaLopTC = new SelectList(contextLopTC.GetAll(), "MaLopTC", "NienKhoa");
            ViewBag.MaSV = new SelectList(contextSinhVien.GetAll(), "MaSV", "HoVaTenLot");
            return View();
        }

        // POST: Admin/DiemDanhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Create([Bind(Include = "MaPhieuDD,Ngay,Buoi,MaSV,MaLopTC")] DiemDanh diemDanh)
        {    
            if (ModelState.IsValid)
            {
                contextDiemDanh.Create(diemDanh);
                return RedirectToAction("Index");
            }

            ViewBag.MaLopTC = new SelectList(contextLopTC.GetAll(), "MaLopTC", "NienKhoa", diemDanh.MaLopTC);
            ViewBag.MaSV = new SelectList(contextSinhVien.GetAll(), "MaSV", "HoVaTenLot", diemDanh.MaSV);
            return View(diemDanh);
        }

        // GET: Admin/DiemDanhs/Edit/5
        [SessionCheck]
        public ActionResult Edit(string id)
        {   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemDanh diemDanh = contextDiemDanh.GetById(id);
            if (diemDanh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLopTC = new SelectList(contextLopTC.GetAll(), "MaLopTC", "NienKhoa", diemDanh.MaLopTC);
            ViewBag.MaSV = new SelectList(contextSinhVien.GetAll(), "MaSV", "HoVaTenLot", diemDanh.MaSV);
            return View(diemDanh);
        }

        // POST: Admin/DiemDanhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Edit([Bind(Include = "MaPhieuDD,Ngay,Buoi,MaSV,MaLopTC")] DiemDanh diemDanh)
        {      
            if (ModelState.IsValid)
            {
                contextDiemDanh.Edit(diemDanh);
                return RedirectToAction("Index");
            }
            ViewBag.MaLopTC = new SelectList(contextLopTC.GetAll(), "MaLopTC", "NienKhoa", diemDanh.MaLopTC);
            ViewBag.MaSV = new SelectList(contextSinhVien.GetAll(), "MaSV", "HoVaTenLot", diemDanh.MaSV);
            return View(diemDanh);
        }

        // GET: Admin/DiemDanhs/Delete/5
        [SessionCheck]
        public ActionResult Delete(string id)
        {  
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemDanh diemDanh = contextDiemDanh.GetById(id);
            if (diemDanh == null)
            {
                return HttpNotFound();
            }
            return View(diemDanh);
        }

        // POST: Admin/DiemDanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult DeleteConfirmed(string id)
        { 
            contextDiemDanh.Delete(id);
            return RedirectToAction("Index");
        }
    }
}