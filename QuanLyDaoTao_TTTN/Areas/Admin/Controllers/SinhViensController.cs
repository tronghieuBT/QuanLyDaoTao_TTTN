using BLL;
using DAO;
using QuanLyDaoTao_TTTN.Areas.Admin.Fillter;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class SinhViensController : Controller
    {
        private SinhVienBLL contextSV = new SinhVienBLL();
        private HeDaoTaoBLL contextHDT = new HeDaoTaoBLL();
        private LopBLL contextLop = new LopBLL();

        // GET: Admin/SinhViens
        [SessionCheck]
        public ActionResult Index()
        {
            var sinhViens = contextSV.GetAll();
            return View(sinhViens.ToList());
        }

        // GET: Admin/SinhViens/Details/5
        [SessionCheck]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = contextSV.GetById(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: Admin/SinhViens/Create
        [SessionCheck]
        public ActionResult Create()
        {
            ViewBag.HeDaoTao = new SelectList(contextHDT.GetAll(), "MaHDT", "TenHDT");
            ViewBag.MaLop = new SelectList(contextLop.GetAll(), "MaLop", "TenLop");
            return View();
        }

        // POST: Admin/SinhViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Create([Bind(Include = "MaSV,HoVaTenLot,TenSV,GioiTinh,NgaySinh,HeDaoTao,Email,MaLop,MatKhau")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                contextSV.Create(sinhVien);
                return RedirectToAction("Index");
            }

            ViewBag.HeDaoTao = new SelectList(contextHDT.GetAll(), "MaHDT", "TenHDT", sinhVien.HeDaoTao);
            ViewBag.MaLop = new SelectList(contextLop.GetAll(), "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: Admin/SinhViens/Edit/5
        [SessionCheck]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = contextSV.GetById(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.HeDaoTao = new SelectList(contextHDT.GetAll(), "MaHDT", "TenHDT", sinhVien.HeDaoTao);
            ViewBag.MaLop = new SelectList(contextLop.GetAll(), "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // POST: Admin/SinhViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Edit([Bind(Include = "MaSV,HoVaTenLot,TenSV,GioiTinh,NgaySinh,HeDaoTao,Email,MaLop,MatKhau")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                contextSV.Edit(sinhVien);
                return RedirectToAction("Index");
            }
            ViewBag.HeDaoTao = new SelectList(contextHDT.GetAll(), "MaHDT", "TenHDT", sinhVien.HeDaoTao);
            ViewBag.MaLop = new SelectList(contextLop.GetAll(), "MaLop", "TenLop", sinhVien.MaLop);
            return View(sinhVien);
        }

        // GET: Admin/SinhViens/Delete/5
        [SessionCheck]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = contextSV.GetById(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: Admin/SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult DeleteConfirmed(string id)
        {
            contextSV.Delete(id);
            return RedirectToAction("Index");
        }
    }
}