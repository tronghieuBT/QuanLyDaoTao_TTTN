using BLL;
using DAO;
using QuanLyDaoTao_TTTN.Areas.Admin.Fillter;
using System.Net;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class KhoasController : Controller
    {
        private KhoaBLL context = new KhoaBLL();

        // GET: Admin/Khoas
        [SessionCheck]
        public ActionResult Index()
        {   
            return View(context.GetAll());
        }

        // GET: Admin/Khoas/Details/5
        [SessionCheck]
        public ActionResult Details(string id)
        {   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = context.GetById(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // GET: Admin/Khoas/Create
        [SessionCheck]
        public ActionResult Create()
        {  
            return View();
        }

        // POST: Admin/Khoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Create([Bind(Include = "MaKhoa,TenKhoa")] Khoa khoa)
        {
           
            if (ModelState.IsValid)
            {
                context.Create(khoa);
                return RedirectToAction("Index");
            }

            return View(khoa);
        }

        // GET: Admin/Khoas/Edit/5
        [SessionCheck]
        public ActionResult Edit(string id)
        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = context.GetById(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: Admin/Khoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Edit([Bind(Include = "MaKhoa,TenKhoa")] Khoa khoa)
        {
           
            if (ModelState.IsValid)
            {
                context.Edit(khoa);
                return RedirectToAction("Index");
            }
            return View(khoa);
        }

        // GET: Admin/Khoas/Delete/5
        [SessionCheck]
        public ActionResult Delete(string id)
        {  
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khoa khoa = context.GetById(id);
            if (khoa == null)
            {
                return HttpNotFound();
            }
            return View(khoa);
        }

        // POST: Admin/Khoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult DeleteConfirmed(string id)
        {
          
            context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}