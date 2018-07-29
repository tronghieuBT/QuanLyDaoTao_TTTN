using BLL;
using DAO;
using QuanLyDaoTao_TTTN.Areas.Admin.Fillter;
using System.Net;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class MonHocsController : Controller
    {
        private MonHocBLL contextMH = new MonHocBLL();

        // GET: Admin/MonHocs
        [SessionCheck]
        public ActionResult Index()
        {
            return View(contextMH.GetAll());
        }

        // GET: Admin/MonHocs/Details/5
        [SessionCheck]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = contextMH.GetById(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // GET: Admin/MonHocs/Create
        [SessionCheck]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MonHocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Create([Bind(Include = "MaMH,TenMH,SoTinChiLyThuyet,SoTinChiThucHanh")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                contextMH.Create(monHoc);
                return RedirectToAction("Index");
            }

            return View(monHoc);
        }

        // GET: Admin/MonHocs/Edit/5
        [SessionCheck]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = contextMH.GetById(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: Admin/MonHocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Edit([Bind(Include = "MaMH,TenMH,SoTinChiLyThuyet,SoTinChiThucHanh")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                contextMH.Edit(monHoc);
                return RedirectToAction("Index");
            }
            return View(monHoc);
        }

        // GET: Admin/MonHocs/Delete/5
        [SessionCheck]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = contextMH.GetById(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: Admin/MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult DeleteConfirmed(string id)
        {
            contextMH.Delete(id);
            return RedirectToAction("Index");
        }
    }
}