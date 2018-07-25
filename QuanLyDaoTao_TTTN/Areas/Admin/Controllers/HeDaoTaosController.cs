using BLL;
using DAO;
using System.Net;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class HeDaoTaosController : Controller
    {
        private HeDaoTaoBLL contextHDT = new HeDaoTaoBLL();

        // GET: Admin/HeDaoTaos
        public ActionResult Index()
        {
            return View(contextHDT.GetAll());
        }

        // GET: Admin/HeDaoTaos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaoTao heDaoTao = contextHDT.GetById(id);
            if (heDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(heDaoTao);
        }

        // GET: Admin/HeDaoTaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HeDaoTaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHDT,TenHDT,GhiChu")] HeDaoTao heDaoTao)
        {
            if (ModelState.IsValid)
            {
                contextHDT.Create(heDaoTao);
                return RedirectToAction("Index");
            }

            return View(heDaoTao);
        }

        // GET: Admin/HeDaoTaos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaoTao heDaoTao = contextHDT.GetById(id);
            if (heDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(heDaoTao);
        }

        // POST: Admin/HeDaoTaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHDT,TenHDT,GhiChu")] HeDaoTao heDaoTao)
        {
            if (ModelState.IsValid)
            {
                contextHDT.Edit(heDaoTao);
                return RedirectToAction("Index");
            }
            return View(heDaoTao);
        }

        // GET: Admin/HeDaoTaos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaoTao heDaoTao = contextHDT.GetById(id);
            if (heDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(heDaoTao);
        }

        // POST: Admin/HeDaoTaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HeDaoTao heDaoTao = contextHDT.GetById(id);
            contextHDT.Delete(id);
            return RedirectToAction("Index");
        }
    }
}