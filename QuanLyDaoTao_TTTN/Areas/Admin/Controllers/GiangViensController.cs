using BLL;
using DAO;
using QuanLyDaoTao_TTTN.Areas.Admin.Fillter;
using System.Net;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class GiangViensController : Controller
    {
        private GiangVienBLL contextGV = new GiangVienBLL();
        private KhoaBLL contextKhoa = new KhoaBLL();

        // GET: Admin/GiangViens
        [SessionCheck]
        public ActionResult Index()
        {  
            var giangViens = contextGV.GetAll();
            return View(giangViens);
        }

        // GET: Admin/GiangViens/Details/5
        [SessionCheck]
        public ActionResult Details(string id)
        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiangVien giangVien = contextGV.GetById(id);
            if (giangVien == null)
            {
                return HttpNotFound();
            }
            return View(giangVien);
        }

        // GET: Admin/GiangViens/Create
        [SessionCheck]
        public ActionResult Create()
        { 
            ViewBag.MaKhoa = new SelectList(contextKhoa.GetAll(), "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: Admin/GiangViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Create([Bind(Include = "MaGV,HoVaTenLot,TenGV,NgaySinh,GioiTinh,TrinhDo,SDT,Email,MaKhoa,MatKhau")] GiangVien giangVien)
        {
          
            if (ModelState.IsValid)
            {
                contextGV.Create(giangVien);
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoa = new SelectList(contextKhoa.GetAll(), "MaKhoa", "TenKhoa", giangVien.MaKhoa);
            return View(giangVien);
        }

        // GET: Admin/GiangViens/Edit/5
        [SessionCheck]
        public ActionResult Edit(string id)
        {  
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiangVien giangVien = contextGV.GetById(id);
            if (giangVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoa = new SelectList(contextKhoa.GetAll(), "MaKhoa", "TenKhoa", giangVien.MaKhoa);
            return View(giangVien);
        }

        // POST: Admin/GiangViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Edit([Bind(Include = "MaGV,HoVaTenLot,TenGV,NgaySinh,GioiTinh,TrinhDo,SDT,Email,MaKhoa,MatKhau")] GiangVien giangVien)
        {   
            if (ModelState.IsValid)
            {
                contextGV.Edit(giangVien);
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoa = new SelectList(contextKhoa.GetAll(), "MaKhoa", "TenKhoa", giangVien.MaKhoa);
            return View(giangVien);
        }

        // GET: Admin/GiangViens/Delete/5
        [SessionCheck]
        public ActionResult Delete(string id)
        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiangVien giangVien = contextGV.GetById(id);
            if (giangVien == null)
            {
                return HttpNotFound();
            }
            return View(giangVien);
        }

        // POST: Admin/GiangViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult DeleteConfirmed(string id)
        {   
            contextGV.Delete(id);
            return RedirectToAction("Index");
        }
    }
}