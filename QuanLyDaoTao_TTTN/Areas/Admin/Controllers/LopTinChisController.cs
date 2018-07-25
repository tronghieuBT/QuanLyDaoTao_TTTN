using BLL;
using DAO;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class LopTinChisController : Controller
    {
        private LopTinChiBLL contextLopTC = new LopTinChiBLL();
        private GiangVienBLL contextGV = new GiangVienBLL();
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
            ViewBag.MaGV = new SelectList(contextGV.GetAll(), "MaGV", "HoVaTenLot");
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH");
            return View();
        }

        // POST: Admin/LopTinChis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLopTC,HocKy,Nhom,NienKhoa,MaMonHoc,MaGV")] LopTinChi lopTinChi)
        {
            if (ModelState.IsValid)
            {
                contextLopTC.Create(lopTinChi);
                return RedirectToAction("Index");
            }

            ViewBag.MaGV = new SelectList(contextGV.GetAll(), "MaGV", "HoVaTenLot", lopTinChi.MaGV);
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH", lopTinChi.MaMonHoc);
            return View(lopTinChi);
        }

        // GET: Admin/LopTinChis/Edit/5
        public ActionResult Edit(int id)
        {
            LopTinChi lopTinChi = contextLopTC.GetById(id);
            if (lopTinChi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGV = new SelectList(contextGV.GetAll(), "MaGV", "HoVaTenLot", lopTinChi.MaGV);
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH", lopTinChi.MaMonHoc);
            return View(lopTinChi);
        }

        // POST: Admin/LopTinChis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLopTC,HocKy,Nhom,NienKhoa,MaMonHoc,MaGV")] LopTinChi lopTinChi)
        {
            if (ModelState.IsValid)
            {
                contextLopTC.Edit(lopTinChi);
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(contextGV.GetAll(), "MaGV", "HoVaTenLot", lopTinChi.MaGV);
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH", lopTinChi.MaMonHoc);
            return View(lopTinChi);
        }

        // GET: Admin/LopTinChis/Delete/5
        public ActionResult Delete(int id)
        {
            LopTinChi lopTinChi = contextLopTC.GetById(id);
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
    }
}