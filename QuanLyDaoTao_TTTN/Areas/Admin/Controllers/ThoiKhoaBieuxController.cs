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
            ThoiKhoaBieuBLL contextTKB = new ThoiKhoaBieuBLL();
            List<ThoiKhoaBieu> lstTKB = contextTKB.GetAll();
            GiangVienBLL contextGV = new GiangVienBLL();
            MonHocBLL contextMH = new MonHocBLL();

            List<GiangVienModel> listGVModel = contextGV.GetAll().Select(x => new GiangVienModel
            {
                Email = x.Email,
                GioiTinh = x.GioiTinh,
                HoVaTenLot = x.HoVaTenLot,
                MaGV = x.MaGV,
                MaKhoa = x.MaKhoa,
                MatKhau = x.MatKhau,
                NgaySinh = x.NgaySinh,
                SDT = x.SDT,
                TenGV = x.TenGV,
                TrinhDo = x.TrinhDo
            }).ToList();
            List<MonHocModel> listMH = contextMH.GetAll().Select(x => new MonHocModel
            {
                MaMH = x.MaMH,
                SoTinChiLyThuyet = x.SoTinChiLyThuyet,
                SoTinChiThucHanh = x.SoTinChiThucHanh,
                TenMH = x.TenMH
            }).ToList();
            List<LopTinChi> lstLTC = contextLTC.GetAll();
            lstLTC = contextLTC.GetListLTCOpen(lstLTC);

            List<LopTinChi> lstLTCNew = new List<LopTinChi>();
            foreach(LopTinChi item in lstLTC)
            {
                var query = lstTKB.Where(x => x.MaLopTC == item.MaLopTC).FirstOrDefault();
                if(query== null)
                {
                    lstLTCNew.Add(item);
                }
            }

            SelectList selectList = new SelectList(lstLTCNew, "MaLopTC", "MaLopTC");

            ViewBag.GiangVienModel = new SelectList(listGVModel, "MaGV", "TenDayDu");
            ViewBag.MonHocModels = new SelectList(listMH, "MaMH", "TenMH");
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
        public JsonResult GetListLopTheoGiangVienMonHoc(string maGiangVien, string maMonHoc, string nienKhoa, int hocKy)
        {
            if (string.IsNullOrEmpty(maGiangVien) || string.IsNullOrEmpty(maMonHoc))
            {
                return Json(new { msg = "Lỗi !"});
            }

            ThoiKhoaBieuBLL contextTKB = new ThoiKhoaBieuBLL();
            List<ThoiKhoaBieu> lstTKB = contextTKB.GetAll();
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            List<LopTinChi> lstLTCResult = new List<LopTinChi>();
            var listLopTC = contextLTC.GetByMaGVVaMaMH(maGiangVien, maMonHoc);
            List<LopTinChi> lstLTCNew = new List<LopTinChi>();
            foreach (LopTinChi item in listLopTC)
            {
                var query = lstTKB.Where(x => x.MaLopTC == item.MaLopTC).FirstOrDefault();
                if (query == null)
                {
                    lstLTCNew.Add(item);
                }
            }
            if (lstLTCNew.Count > 0)
            {
                foreach(var item in lstLTCNew)
                {
                    if(item.NienKhoa == nienKhoa && item.HocKy == hocKy)
                    {
                        lstLTCResult.Add(item);
                    }
                }
                List<int> listMaLopTC = lstLTCResult.Select(x => x.MaLopTC).ToList();
                return Json(new { msg = listMaLopTC });
            }
            return Json(new { msg = "Không có lớp tín chỉ nào!" });
        }

    }
}