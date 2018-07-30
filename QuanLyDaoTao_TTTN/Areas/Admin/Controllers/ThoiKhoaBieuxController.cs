using BLL;
using DAO;
using QuanLyDaoTao_TTTN.Areas.Admin.Fillter;
using QuanLyDaoTao_TTTN.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Controllers
{
    public class ThoiKhoaBieuxController : Controller
    {
        private ThoiKhoaBieuBLL contextTKB = new ThoiKhoaBieuBLL();
        private LopTinChiBLL contextLTC = new LopTinChiBLL();

        // GET: Admin/ThoiKhoaBieux
        [SessionCheck]
        public ActionResult Index()
        {
            var thoiKhoaBieux = contextTKB.GetTKBCurent();
            return View(thoiKhoaBieux.ToList());
        }

        // GET: Admin/ThoiKhoaBieux/Create
        [SessionCheck]
        public ActionResult Create()
        {
            List<LopTinChi> lstLTC = contextLTC.GetAll();
            lstLTC = contextLTC.GetListLTCOpen(lstLTC);
            SelectList selectList = new SelectList(lstLTC, "MaLopTC", "MaLopTC");
            ViewBag.LopTCDuocMo = selectList;
            ViewBag.MaLopTC = new SelectList(lstLTC, "MaLopTC", "MaLopTC");
            return View();
        }

        // POST: Admin/ThoiKhoaBieux/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ngay,Buoi,TietBD,MaLopTC")] ThoiKhoaBieu thoiKhoaBieu)
        {
            if (ModelState.IsValid)
            {                                                      
                contextTKB.Create(thoiKhoaBieu);  
                return RedirectToAction("Index");
            }
            List<LopTinChi> lstLTC = contextLTC.GetAll();
            lstLTC = contextLTC.GetListLTCOpen(lstLTC);
            ViewBag.MaLopTC = new SelectList(lstLTC, "MaLopTC", "NienKhoa", thoiKhoaBieu.MaLopTC);
            return View(thoiKhoaBieu);
        }

        //// GET: Admin/ThoiKhoaBieux/Edit/5
        //public ActionResult Edit(ThoiKhoaBieu tkb)
        //{
        //    LopTinChiBLL contextLTC = new LopTinChiBLL();
        //    if (tkb == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LopTinChi lopTC = contextLTC.GetById(tkb.MaLopTC);
        //    ViewBag.LopTC = lopTC;
        //    return View(tkb);
        //}

        //// POST: Admin/ThoiKhoaBieux/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Ngay,Buoi,TietBD,MaLopTC")] ThoiKhoaBieu thoiKhoaBieu)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        contextTKB.Entry(thoiKhoaBieu).State = EntityState.Modified;
        //        contextTKB.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.MaLopTC = new SelectList(contextTKB.LopTinChis, "MaLopTC", "NienKhoa", thoiKhoaBieu.MaLopTC);
        //    return View(thoiKhoaBieu);
        //}

        // GET: Admin/ThoiKhoaBieux/Delete/5
        public ActionResult Delete(ThoiKhoaBieu tkb)
        {
            if (tkb == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(tkb);
        }

        // POST: Admin/ThoiKhoaBieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ThoiKhoaBieu tkb)
        {
            contextTKB.Delete(tkb);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetLopTC(int maLopTC)
        {
            LopTinChiModel ltcModel;
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            LopTinChi ltc = contextLTC.GetById(maLopTC);

            GiangVienBLL contextGV = new GiangVienBLL();
            MonHocBLL contextMH = new MonHocBLL();
            if (ltc != null)
            {
                ltcModel = new LopTinChiModel
                {
                    MaGV = ltc.MaGV,
                    HocKy = ltc.HocKy,
                    MaLopTC = ltc.MaLopTC,
                    MaMonHoc = ltc.MaMonHoc,
                    Nhom = ltc.Nhom,
                    NienKhoa = ltc.NienKhoa,
                    TrangThai = ltc.TrangThai
                };
                GiangVien gv = contextGV.GetById(ltc.MaGV);
                MonHoc mh = contextMH.GetById(ltc.MaMonHoc);
                ltcModel.MonHoc = new MonHocModel
                {
                    MaMH = mh.MaMH,
                    SoTinChiThucHanh = mh.SoTinChiThucHanh,
                    SoTinChiLyThuyet = mh.SoTinChiLyThuyet,
                    TenMH = mh.TenMH
                };
                ltcModel.GiangVien = new GiangVienModel
                {
                    MaGV = gv.MaGV,
                    Email = gv.Email,
                    GioiTinh = gv.GioiTinh,
                    HoVaTenLot = gv.HoVaTenLot,
                    MaKhoa = gv.MaKhoa,
                    MatKhau = gv.MatKhau,
                    NgaySinh = gv.NgaySinh,
                    SDT = gv.SDT,
                    TenGV = gv.TenGV,
                    TrinhDo = gv.TrinhDo
                };
                return Json(new { LTC = ltcModel });
            }
            return Json(new { LTC = "NULL" });
        }

        [HttpPost]
        public JsonResult GetThoiKhoaBieuGiangVien(string maGiangVien)
        {
            DateTime dtNow = DateTime.UtcNow;         
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            ThoiKhoaBieuBLL contextTKB = new ThoiKhoaBieuBLL();
            List<ThoiKhoaBieuModel> lichGV = new List<ThoiKhoaBieuModel>();
            List<LopTinChi> listGV = contextLTC.GetByMaGV(maGiangVien);
            //duyệt tất cả lớp tín chỉ cua rgiangr viên đang dạy.
            foreach (LopTinChi item in listGV)
            {
                if (item.TrangThai == true)
                {
                    List<ThoiKhoaBieu> listTKB = contextTKB.GetByMaLopTC(item.MaLopTC);
                    if (listTKB != null)
                    {
                        foreach (ThoiKhoaBieu tkb in listTKB)
                        {
                            if (tkb.Ngay.Year == dtNow.Year)
                            {
                                    ThoiKhoaBieuModel tkbModel = new ThoiKhoaBieuModel
                                    {
                                        Buoi = tkb.Buoi,
                                        MaLopTC = tkb.MaLopTC,
                                        Ngay = tkb.Ngay,
                                        TietBD = tkb.TietBD
                                    };
                                    lichGV.Add(tkbModel);
                            }
                            if (tkb.Ngay.Year > dtNow.Year)
                            {
                                ThoiKhoaBieuModel tkbModel = new ThoiKhoaBieuModel
                                {
                                    Buoi = tkb.Buoi,
                                    MaLopTC = tkb.MaLopTC,
                                    Ngay = tkb.Ngay,
                                    TietBD = tkb.TietBD
                                };
                                lichGV.Add(tkbModel);
                            }

                        }

                    }
                }
            }
            if (listGV.Count == 0)
            {
                return Json(new { result = "Giảng viên trống lịch trong thời gian tới !" });
            }
            return Json(new { lich = lichGV });
        }
    }
}