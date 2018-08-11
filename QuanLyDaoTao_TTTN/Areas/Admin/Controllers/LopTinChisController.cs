using BLL;
using DAO;
using QuanLyDaoTao_TTTN.Areas.Admin.Fillter;
using QuanLyDaoTao_TTTN.Areas.Admin.Models;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class LopTinChisController : Controller
    {
        #region context

        private NienKhoaHocKyBLL contextNKHK = new NienKhoaHocKyBLL();
        private LopTinChiBLL contextLopTC = new LopTinChiBLL();
        private GiangVienModel contextGV = new GiangVienModel();
        private MonHocBLL contextMH = new MonHocBLL();

        #endregion context

        #region index

        // GET: Admin/LopTinChis
        [SessionCheck]
        public ActionResult Index()
        {
            var lopTinChis = contextLopTC.GetAll();
            foreach (LopTinChi item in lopTinChis)
            {
                item.NienKhoaHocKy = contextNKHK.GetById(item.NienKhoa);
            }
            return View(lopTinChis);
        }

        #endregion index

        #region Detail

        // GET: Admin/LopTinChis/Details/5
        [SessionCheck]
        public ActionResult Details(int id)
        {
            LopTinChi lopTinChi = contextLopTC.GetById(id);
            if (lopTinChi == null)
            {
                return HttpNotFound();
            }
            GiangVienBLL ctGV = new GiangVienBLL();
            MonHocBLL ctMH = new MonHocBLL();
            lopTinChi.GiangVien = ctGV.GetById(lopTinChi.MaGV);
            lopTinChi.MonHoc = ctMH.GetById(lopTinChi.MaMonHoc);
            lopTinChi.NienKhoaHocKy = contextNKHK.GetById(lopTinChi.NienKhoa);
            return View(lopTinChi);
        }

        #endregion Detail

        #region Create

        // GET: Admin/LopTinChis/Create
        [SessionCheck]
        public ActionResult Create()
        {
            ViewBag.NienKhoa = new SelectList(contextNKHK.GetNienKhoa(), "NienKhoa", "NienKhoa");
            ViewBag.MaGV = new SelectList(contextGV.GetALL(), "MaGV", "TenDayDu");
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH");
            return View();
        }

        // POST: Admin/LopTinChis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Create([Bind(Include = "MaLopTC,HocKy,Nhom,NienKhoa,MaMonHoc,MaGV,TrangThai")] LopTinChi lopTinChi, int HocKy)
        {
            ViewBag.NienKhoa = new SelectList(contextNKHK.GetNienKhoa(), "NienKhoa", "NienKhoa");
            if (ModelState.IsValid)
            {
                string idNienKhoa = "K" + lopTinChi.NienKhoa.Substring(2, 2) + "-" + HocKy.ToString();
                lopTinChi.NienKhoa = idNienKhoa.Trim();
                contextLopTC.Create(lopTinChi);
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(contextGV.GetALL(), "MaGV", "TenDayDu", lopTinChi.MaGV);
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH", lopTinChi.MaMonHoc);
            return View(lopTinChi);
        }

        #endregion Create

        #region Edit

        // GET: Admin/LopTinChis/Edit/5
        [SessionCheck]
        public ActionResult Edit(int id)
        {
            LopTinChi lopTinChi = contextLopTC.GetById(id);
            if (lopTinChi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGV = new SelectList(contextGV.GetALL(), "MaGV", "TenDayDu", lopTinChi.MaGV);
            return View(lopTinChi);
        }

        // POST: Admin/LopTinChis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Edit([Bind(Include = "MaLopTC,HocKy,Nhom,NienKhoa,MaMonHoc,MaGV,TrangThai")] LopTinChi lopTinChi)
        {
            if (ModelState.IsValid)
            {
                contextLopTC.Edit(lopTinChi);
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(contextGV.GetALL(), "MaGV", "TenDayDu", lopTinChi.MaGV);
            ViewBag.MaMonHoc = new SelectList(contextMH.GetAll(), "MaMH", "TenMH", lopTinChi.MaMonHoc);
            return View(lopTinChi);
        }

        #endregion Edit

        #region Delete

        // GET: Admin/LopTinChis/Delete/5
        [SessionCheck]
        public ActionResult Delete(int id)
        {
            GiangVienBLL ctGV = new GiangVienBLL();
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            LopTinChi lopTinChi = contextLTC.GetById(id);
            if (lopTinChi == null)
            {
                return HttpNotFound();
            }

            return View(lopTinChi);
        }

        // POST: Admin/LopTinChis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult DeleteConfirmed(int id)
        {
            contextLopTC.Delete(id);
            return RedirectToAction("Index");
        }

        #endregion Delete

        #region GetMaNhom

        public JsonResult GetMaNhom(string maMonHoc, string nienKhoa, string maGiangVien, int hocKy)
        {
            string idNK = "K" + nienKhoa.Substring(2, 2) + "-" + hocKy.ToString();
            if (string.IsNullOrEmpty(maMonHoc) || string.IsNullOrEmpty(nienKhoa) || string.IsNullOrEmpty(maGiangVien))
            {
                return Json(new { maNhom = "NULL" });
            }
            LopTinChiModel ltcModel = new LopTinChiModel();
            return Json(new { maNhom = ltcModel.GetMaNhom(maMonHoc, idNK.Trim(), maGiangVien, hocKy) });
        }

        #endregion GetMaNhom
    }
}