using BLL;
using DAO;
using System.Net;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class GiaTinChisController : Controller
    {
        private GiaTinChiBLL contextGiaTC = new GiaTinChiBLL();
        private HeDaoTaoBLL contextHDT = new HeDaoTaoBLL();

        // GET: Admin/GiaTinChis
        public ActionResult Index()
        {
            var giaTinChis = contextGiaTC.GetAll();
            return View(giaTinChis);
        }

        // GET: Admin/GiaTinChis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaTinChi giaTinChi = contextGiaTC.GetById(id);
            if (giaTinChi == null)
            {
                return HttpNotFound();
            }
            return View(giaTinChi);
        }

        // GET: Admin/GiaTinChis/Create
        public ActionResult Create()
        {
            ViewBag.MaHDT = new SelectList(contextHDT.GetAll(), "MaHDT", "TenHDT");
            return View();
        }

        // POST: Admin/GiaTinChis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGiaTC,MaHDT,Gia,NgayThayDoi")] GiaTinChi giaTinChi)
        {
            if (ModelState.IsValid)
            {
                contextGiaTC.Create(giaTinChi);
                return RedirectToAction("Index");
            }

            ViewBag.MaHDT = new SelectList(contextHDT.GetAll(), "MaHDT", "TenHDT", giaTinChi.MaHDT);
            return View(giaTinChi);
        }

        // GET: Admin/GiaTinChis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaTinChi giaTinChi = contextGiaTC.GetById(id);
            if (giaTinChi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHDT = new SelectList(contextHDT.GetAll(), "MaHDT", "TenHDT", giaTinChi.MaHDT);
            return View(giaTinChi);
        }

        // POST: Admin/GiaTinChis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGiaTC,MaHDT,Gia,NgayThayDoi")] GiaTinChi giaTinChi)
        {
            if (ModelState.IsValid)
            {
                contextGiaTC.Edit(giaTinChi);
                return RedirectToAction("Index");
            }
            ViewBag.MaHDT = new SelectList(contextHDT.GetAll(), "MaHDT", "TenHDT", giaTinChi.MaHDT);
            return View(giaTinChi);
        }

        // GET: Admin/GiaTinChis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaTinChi giaTinChi = contextGiaTC.GetById(id);
            if (giaTinChi == null)
            {
                return HttpNotFound();
            }
            return View(giaTinChi);
        }

        // POST: Admin/GiaTinChis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            contextGiaTC.Delete(id);
            return RedirectToAction("Index");
        }
    }
}