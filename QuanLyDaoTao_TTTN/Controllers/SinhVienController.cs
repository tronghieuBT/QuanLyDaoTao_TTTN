using BLL;
using BLL.Common;
using DAO;
using QuanLyDaoTao_TTTN.Fillter;
using QuanLyDaoTao_TTTN.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Net;

namespace QuanLyDaoTao_TTTN.Controllers
{
    public class SinhVienController : Controller
    {
        private List<DangKyModel> DangKy = new List<DangKyModel>();
        private List<MonHoc> listMonHoc = new List<MonHoc>();

        #region     Index
        // GET: SinhVien
        [CheckLogin]
        public ActionResult Index()
        {
            HeDaoTaoBLL contextHDT = new HeDaoTaoBLL();
            MonHocBLL contextMH = new MonHocBLL();
            ThoiKhoaBieuBLL contextTKB = new ThoiKhoaBieuBLL();
            SinhVienBLL contextSV = new SinhVienBLL();
            SinhVien sv = contextSV.GetById(Session["MaSV"].ToString().Trim());
            SupportThoiKhoaBieu spTKB = new SupportThoiKhoaBieu();
            List<SinhVien> lstSV = contextSV.GetAll();
            foreach (SinhVien sv1 in lstSV)
            {
                if (sv1.MaSV == sv.MaSV)
                {
                    sv = sv1;
                }
            }
            ViewData["MaLop"] = sv.MaLop;
            ViewData["HDT"] = contextHDT.GetById(sv.Lop.MaHDT).TenHDT;
            ViewData["Khoa"] = sv.Lop.NienKhoa;
            //sv.LopTinChis
            // lấy số tuần của năm và list ngày BD , KT của từng tuần lưu vào selectList
            Date dt = new Date();
            DateTime dtNow = DateTime.UtcNow;
            List<string> lstTuan = dt.GetListDate(dtNow.Year);
            List<string> lstTuanNew = dt.GetListDate(dtNow.Year + 1);
            lstTuan.AddRange(lstTuanNew);
            //gán list các tuần vào selectList
            List<SelectListItem> weeks = lstTuan.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
            //Xem ngày hiện tại thuộc tuần nào trong năm
            int tuan = 0;
            for (int i = 0; i < lstTuan.Count; i++)
            {
                DateTime tempDTStart = new DateTime();
                DateTime tempDTEnd = new DateTime();
                // Lấy datetime từ list Tuần và format về "dd/mm/yy"
                tempDTStart = DateTime.Parse(lstTuan[i].Split('-')[1], new CultureInfo("en-US"));
                tempDTEnd = DateTime.Parse(lstTuan[i].Split('-')[3], new CultureInfo("en-US"));
                if (dtNow.DayOfYear >= tempDTStart.DayOfYear && dtNow.DayOfYear <= tempDTEnd.DayOfYear)
                {
                    tuan = i;
                    break;
                }
            }
            //Gán list tuần vào viewbag
            ViewBag.Weeks = new SelectList(weeks, "Text", "Value", tuan);
            ViewBag.WeekCurrent = lstTuan[tuan];
            //lọc các lớp tín chỉ mở mới xem thời khóa biểu;
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            sv.LopTinChis = contextLTC.GetListLTCOpen(sv.LopTinChis);
            //// lấy thời khóa biểu của tất cả các lớp mà sinh viên đã đăng ký cùng với môn học của lớp tín chỉ
            List<SupportThoiKhoaBieu> lstSPTKB = spTKB.GetListSPTKB(lstTuan[tuan], sv.LopTinChis);
            return View(lstSPTKB);
        }
        #endregion

        #region    LocTKBTHeoTuan
        public JsonResult LocTKBTHeoTuan(string tuan)
        {
            if (Session["MaSV"] != null)
            {
                MonHocBLL contextMH = new MonHocBLL();
                SupportThoiKhoaBieu spTKB = new SupportThoiKhoaBieu();
                SinhVienBLL contextSV = new SinhVienBLL();
                SinhVien sv = contextSV.GetById(Session["MaSV"].ToString().Trim());
                HeDaoTaoBLL contextHDT = new HeDaoTaoBLL();
                List<SinhVien> lstSV = contextSV.GetAll();
                foreach (SinhVien sv1 in lstSV)
                {
                    if (sv1.MaSV == sv.MaSV)
                    {
                        sv = sv1;
                    }
                }
                ViewData["MaLop"] = sv.MaLop;
                ViewData["HDT"] = contextHDT.GetById(sv.Lop.MaHDT).TenHDT;
                ViewData["Khoa"] = sv.Lop.NienKhoa;

                List<SupportThoiKhoaBieu> lstSPTKB = spTKB.GetListSPTKB(tuan, sv.LopTinChis);
                return Json(new { ListData = lstSPTKB }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { msg = "Bạn không có quyền xem thời khóa biểu!" });
        }
        #endregion

        #region    DangKyMonHoc
        [CheckLogin]
        public ActionResult DangKyMonHoc()
        {
            string maSV = Session["MaSV"].ToString().Trim();
            KhoaBLL contextK = new KhoaBLL();
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            List<LopTinChi> lstLTC = contextLTC.GetAll();

            MonHocBLL contextMH = new MonHocBLL();
            GiangVienBLL contextGV = new GiangVienBLL();
            //  chỉ cho sinh viên đăng ký lớp đang mở    
            List<LopTinChiModel> listLTCModel = new List<LopTinChiModel>();
            foreach (LopTinChi ltc in lstLTC)
            {
                var query = ltc.SinhViens.Where(x => x.MaSV == maSV).FirstOrDefault();
                if (query == null)
                {
                    if (ltc.TrangThai == true && ltc.SinhViens.Count < 50)
                    {
                        GiangVien giangVien = contextGV.GetById(ltc.MaGV);
                        MonHoc monHoc = contextMH.GetById(ltc.MaMonHoc);
                        LopTinChiModel ltcModel = new LopTinChiModel()
                        {
                            MaLopTC = ltc.MaLopTC,
                            TrangThai = ltc.TrangThai, 
                            MaGV = ltc.MaGV,
                            MaMonHoc = ltc.MaMonHoc,
                            Nhom = ltc.Nhom,
                            NienKhoa = ltc.NienKhoa,
                            GiangVienModel = new GiangVienModel()
                            {
                                MaGV = giangVien.MaGV,
                                Email = giangVien.Email,
                                GioiTinh = giangVien.GioiTinh,
                                HoVaTenLot = giangVien.HoVaTenLot,
                                MaKhoa = giangVien.MaKhoa,
                                MatKhau = giangVien.MatKhau,
                                NgaySinh = giangVien.NgaySinh,
                                SDT = giangVien.SDT,
                                TenGV = giangVien.TenGV,
                                TrinhDo = giangVien.TrinhDo
                            },
                            MonHoc = new MonHocModel
                            {
                                MaMH = monHoc.MaMH,
                                SoTinChiLyThuyet = monHoc.SoTinChiLyThuyet,
                                SoTinChiThucHanh = monHoc.SoTinChiThucHanh,
                                TenMH = monHoc.TenMH
                            }
                        };
                        listLTCModel.Add(ltcModel);
                    }
                }
            }
            ViewBag.Khoa = new SelectList(contextK.GetAll(), "MaKhoa", "TenKhoa");
            return View(listLTCModel);

        }
        #endregion

        #region    AddMonHocDK
        [HttpPost]
        public JsonResult AddMonHocDK(int maLopTC)
        {
            string maSV = Session["MaSV"].ToString().Trim();
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            List<LopTinChi> lstLTC = contextLTC.GetAll();

            MonHocBLL contextMH = new MonHocBLL();
            GiangVienBLL contextGV = new GiangVienBLL();
            List<LopTinChiModel> listLTCModel = new List<LopTinChiModel>();
            foreach (LopTinChi ltc in lstLTC)
            {
                var query = ltc.SinhViens.Where(x => x.MaSV == maSV).FirstOrDefault();
                if (query == null)
                {
                    if (ltc.TrangThai == true && ltc.SinhViens.Count < 50)
                    {
                        GiangVien giangVien = contextGV.GetById(ltc.MaGV);
                        MonHoc monHoc = contextMH.GetById(ltc.MaMonHoc);
                        LopTinChiModel ltcModel = new LopTinChiModel()
                        {
                            MaLopTC = ltc.MaLopTC,
                            TrangThai = ltc.TrangThai, 
                            MaGV = ltc.MaMonHoc,
                            MaMonHoc = ltc.MaMonHoc,
                            Nhom = ltc.Nhom,
                            NienKhoa = ltc.NienKhoa,
                            GiangVienModel = new GiangVienModel()
                            {
                                MaGV = giangVien.MaGV,
                                Email = giangVien.Email,
                                GioiTinh = giangVien.GioiTinh,
                                HoVaTenLot = giangVien.HoVaTenLot,
                                MaKhoa = giangVien.MaKhoa,
                                MatKhau = giangVien.MatKhau,
                                NgaySinh = giangVien.NgaySinh,
                                SDT = giangVien.SDT,
                                TenGV = giangVien.TenGV,
                                TrinhDo = giangVien.TrinhDo
                            },
                            MonHoc = new MonHocModel
                            {
                                MaMH = monHoc.MaMH,
                                SoTinChiLyThuyet = monHoc.SoTinChiLyThuyet,
                                SoTinChiThucHanh = monHoc.SoTinChiThucHanh,
                                TenMH = monHoc.TenMH
                            }
                        };
                        listLTCModel.Add(ltcModel);
                    }
                }

            }

            if (listLTCModel.Count > 0)
            {
                LopTinChiModel ltc = listLTCModel.Where(x => x.MaLopTC == maLopTC).FirstOrDefault();
                if (ltc != null)
                {
                    List<int> listMaLopDK = new List<int>();
                    if (TempData["SoTinChiDK"] == null)
                    {
                        listMaLopDK.Add(maLopTC);
                        TempData["ListLopTCDK"] = listMaLopDK;
                        TempData["SoTinChiDK"] = ltc.TongSoTinChi;
                        return Json(new { msg = "OK" });
                    }
                    else
                    {
                        int tong = Int32.Parse(TempData["SoTinChiDK"].ToString()) + ltc.TongSoTinChi;
                        if (tong < 21)
                        {
                            if (TempData["ListLopTCDK"] != null)
                            {
                                listMaLopDK = (List<int>)TempData["ListLopTCDK"];
                                listMaLopDK.Add(maLopTC);
                            }
                            else
                            {
                                listMaLopDK.Add(maLopTC);
                            }
                            TempData["ListLopTCDK"] = listMaLopDK;
                            TempData["SoTinChiDK"] = tong;
                            return Json(new { msg = "OK" });
                        }
                        return Json(new { msg = "Số tín chỉ đã vượt quá 21 tín chỉ!" });
                    }
                }
            }
            return Json(new { msg = "FALSE" });
        }
        #endregion

        #region     DeleteSelectMonHoc
        [HttpPost]
        public JsonResult DeleteSelectMonHoc(int maLopTC)
        {
            string maSV = Session["MaSV"].ToString().Trim();
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            List<LopTinChi> lstLTC = contextLTC.GetAll();

            MonHocBLL contextMH = new MonHocBLL();
            GiangVienBLL contextGV = new GiangVienBLL();
            List<LopTinChiModel> listLTCModel = new List<LopTinChiModel>();
            foreach (LopTinChi ltc in lstLTC)
            {
                var query = ltc.SinhViens.Where(x => x.MaSV == maSV).FirstOrDefault();
                if (query == null)
                {
                    if (ltc.TrangThai == true && ltc.SinhViens.Count < 50)
                    {
                        GiangVien giangVien = contextGV.GetById(ltc.MaGV);
                        MonHoc monHoc = contextMH.GetById(ltc.MaMonHoc);
                        LopTinChiModel ltcModel = new LopTinChiModel()
                        {
                            MaLopTC = ltc.MaLopTC,
                            TrangThai = ltc.TrangThai,   
                            MaGV = ltc.MaMonHoc,
                            MaMonHoc = ltc.MaMonHoc,
                            Nhom = ltc.Nhom,
                            NienKhoa = ltc.NienKhoa,
                            GiangVienModel = new GiangVienModel()
                            {
                                MaGV = giangVien.MaGV,
                                Email = giangVien.Email,
                                GioiTinh = giangVien.GioiTinh,
                                HoVaTenLot = giangVien.HoVaTenLot,
                                MaKhoa = giangVien.MaKhoa,
                                MatKhau = giangVien.MatKhau,
                                NgaySinh = giangVien.NgaySinh,
                                SDT = giangVien.SDT,
                                TenGV = giangVien.TenGV,
                                TrinhDo = giangVien.TrinhDo
                            },
                            MonHoc = new MonHocModel
                            {
                                MaMH = monHoc.MaMH,
                                SoTinChiLyThuyet = monHoc.SoTinChiLyThuyet,
                                SoTinChiThucHanh = monHoc.SoTinChiThucHanh,
                                TenMH = monHoc.TenMH
                            }
                        };
                        listLTCModel.Add(ltcModel);
                    }
                }
            }


            if (listLTCModel.Count > 0)
            {
                LopTinChiModel ltc = listLTCModel.Where(x => x.MaLopTC == maLopTC).FirstOrDefault();
                if (ltc != null)
                {
                    if (TempData["SoTinChiDK"] != null)
                    {
                        List<int> listMaLopDK = (List<int>)TempData["ListLopTCDK"];
                        var itemToRemove = listMaLopDK.Single(r => r == maLopTC);
                        listMaLopDK.Remove(itemToRemove);
                        TempData["ListLopTCDK"] = listMaLopDK;
                        int tong = Int32.Parse(TempData["SoTinChiDK"].ToString()) - ltc.TongSoTinChi;
                        TempData["SoTinChiDK"] = tong;
                        return Json(new { msg = "OK" });
                    }
                }
            }
            return Json(new { msg = "FALSE" });
        }
        #endregion

        #region  LuuDangKy
        [HttpPost]
        public JsonResult LuuDangKy()
        {
            string maSV = Session["MaSV"].ToString().Trim();
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            List<LopTinChi> lstLTC = contextLTC.GetAll();

            MonHocBLL contextMH = new MonHocBLL();
            GiangVienBLL contextGV = new GiangVienBLL();
            List<LopTinChiModel> listLTCModel = new List<LopTinChiModel>();
            foreach (LopTinChi ltc in lstLTC)
            {
                var query = ltc.SinhViens.Where(x => x.MaSV == maSV).FirstOrDefault();
                if (query == null)
                {
                    if (ltc.TrangThai == true && ltc.SinhViens.Count < 50)
                    {
                        GiangVien giangVien = contextGV.GetById(ltc.MaGV);
                        MonHoc monHoc = contextMH.GetById(ltc.MaMonHoc);
                        LopTinChiModel ltcModel = new LopTinChiModel()
                        {
                            MaLopTC = ltc.MaLopTC,
                            TrangThai = ltc.TrangThai, 
                            MaGV = ltc.MaMonHoc,
                            MaMonHoc = ltc.MaMonHoc,
                            Nhom = ltc.Nhom,
                            NienKhoa = ltc.NienKhoa,
                            GiangVienModel = new GiangVienModel()
                            {
                                MaGV = giangVien.MaGV,
                                Email = giangVien.Email,
                                GioiTinh = giangVien.GioiTinh,
                                HoVaTenLot = giangVien.HoVaTenLot,
                                MaKhoa = giangVien.MaKhoa,
                                MatKhau = giangVien.MatKhau,
                                NgaySinh = giangVien.NgaySinh,
                                SDT = giangVien.SDT,
                                TenGV = giangVien.TenGV,
                                TrinhDo = giangVien.TrinhDo
                            },
                            MonHoc = new MonHocModel
                            {
                                MaMH = monHoc.MaMH,
                                SoTinChiLyThuyet = monHoc.SoTinChiLyThuyet,
                                SoTinChiThucHanh = monHoc.SoTinChiThucHanh,
                                TenMH = monHoc.TenMH
                            }
                        };
                        listLTCModel.Add(ltcModel);
                    }
                }
            }


            DangKyModel dk = new DangKyModel();

            List<int> listMaLopDK = (List<int>)TempData["ListLopTCDK"];
            if (listMaLopDK.Count > 0)
            {
                foreach (int a in listMaLopDK)
                {
                    LopTinChiModel ltcModel = listLTCModel.Where(x => x.MaLopTC == a).FirstOrDefault();
                    if (ltcModel != null)
                    {
                        if (Session["MaSV"] != null)
                        {
                            contextLTC.DangKy(ltcModel.MaLopTC, maSV);
                        }
                    }
                }
                TempData.Clear();
                return Json(new { msg = "Lưu đăng ký thành công!" });
            }
            return Json(new { msg = "Lỗi!" });
        }
        #endregion

        #region LocMonTheoNienKhoa
        [HttpPost]
        public ActionResult LocMonTheoNienKhoa(string nienKhoa)
        {
            string maSV = Session["MaSV"].ToString().Trim();
            if (string.IsNullOrEmpty(nienKhoa))
            {
                return Json(new { msg = "FALSE" });
            }
            KhoaBLL contextK = new KhoaBLL();
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            List<LopTinChi> lstLTC = contextLTC.GetAll();

            MonHocBLL contextMH = new MonHocBLL();
            GiangVienBLL contextGV = new GiangVienBLL();
            List<LopTinChiModel> listLTCModel = new List<LopTinChiModel>();
            foreach (LopTinChi ltc in lstLTC)
            {
                var query = ltc.SinhViens.Where(x => x.MaSV == maSV).FirstOrDefault();
                if (query == null)
                {
                    if (ltc.TrangThai == true && ltc.NienKhoa == nienKhoa && ltc.SinhViens.Count < 50)
                    {
                        GiangVien giangVien = contextGV.GetById(ltc.MaGV);
                        MonHoc monHoc = contextMH.GetById(ltc.MaMonHoc);
                        LopTinChiModel ltcModel = new LopTinChiModel()
                        {
                            MaLopTC = ltc.MaLopTC,
                            TrangThai = ltc.TrangThai,  
                            MaGV = ltc.MaGV,
                            MaMonHoc = ltc.MaMonHoc,
                            Nhom = ltc.Nhom,
                            NienKhoa = ltc.NienKhoa,
                            GiangVienModel = new GiangVienModel()
                            {
                                MaGV = giangVien.MaGV,
                                Email = giangVien.Email,
                                GioiTinh = giangVien.GioiTinh,
                                HoVaTenLot = giangVien.HoVaTenLot,
                                MaKhoa = giangVien.MaKhoa,
                                MatKhau = giangVien.MatKhau,
                                NgaySinh = giangVien.NgaySinh,
                                SDT = giangVien.SDT,
                                TenGV = giangVien.TenGV,
                                TrinhDo = giangVien.TrinhDo
                            },
                            MonHoc = new MonHocModel
                            {
                                MaMH = monHoc.MaMH,
                                SoTinChiLyThuyet = monHoc.SoTinChiLyThuyet,
                                SoTinChiThucHanh = monHoc.SoTinChiThucHanh,
                                TenMH = monHoc.TenMH
                            }
                        };
                        listLTCModel.Add(ltcModel);
                    }
                }
            }

            ViewBag.Khoa = new SelectList(contextK.GetAll(), "MaKhoa", "TenKhoa");
            if (listLTCModel.Count > 0)
            {
                return Json(new { msg = listLTCModel });
            }
            return Json(new { msg = "FALSE" });
        }
        #endregion

        #region LocTheoNieKhoaHocKy
        [HttpPost]
        public JsonResult LocTheoNieKhoaHocKy(string nienKhoa, int hocky)
        {
            string maSV = Session["MaSV"].ToString().Trim();
            if (string.IsNullOrEmpty(nienKhoa) || hocky < 0 || hocky > 3)
            {
                return Json(new { msg = "FALSE" });
            }
            KhoaBLL contextK = new KhoaBLL();
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            List<LopTinChi> lstLTC = contextLTC.GetAll();

            NienKhoaHocKyBLL contextNKHK = new NienKhoaHocKyBLL();
            MonHocBLL contextMH = new MonHocBLL();
            GiangVienBLL contextGV = new GiangVienBLL();
            List<LopTinChiModel> listLTCModel = new List<LopTinChiModel>();
            foreach (LopTinChi ltc in lstLTC)
            {
                NienKhoaHocKy nkhk = contextNKHK.GetById(ltc.NienKhoa);
                var query = ltc.SinhViens.Where(x => x.MaSV == maSV).FirstOrDefault();
                if (query == null)
                {
                    if (ltc.TrangThai == true && ltc.NienKhoa == nienKhoa && nkhk.HocKy == hocky && ltc.SinhViens.Count < 50)
                    {
                        GiangVien giangVien = contextGV.GetById(ltc.MaGV);
                        MonHoc monHoc = contextMH.GetById(ltc.MaMonHoc);
                        LopTinChiModel ltcModel = new LopTinChiModel()
                        {
                            MaLopTC = ltc.MaLopTC,
                            TrangThai = ltc.TrangThai,   
                            MaGV = ltc.MaGV,
                            MaMonHoc = ltc.MaMonHoc,
                            Nhom = ltc.Nhom,
                            NienKhoa = ltc.NienKhoa,
                            GiangVienModel = new GiangVienModel()
                            {
                                MaGV = giangVien.MaGV,
                                Email = giangVien.Email,
                                GioiTinh = giangVien.GioiTinh,
                                HoVaTenLot = giangVien.HoVaTenLot,
                                MaKhoa = giangVien.MaKhoa,
                                MatKhau = giangVien.MatKhau,
                                NgaySinh = giangVien.NgaySinh,
                                SDT = giangVien.SDT,
                                TenGV = giangVien.TenGV,
                                TrinhDo = giangVien.TrinhDo
                            },
                            MonHoc = new MonHocModel
                            {
                                MaMH = monHoc.MaMH,
                                SoTinChiLyThuyet = monHoc.SoTinChiLyThuyet,
                                SoTinChiThucHanh = monHoc.SoTinChiThucHanh,
                                TenMH = monHoc.TenMH
                            }
                        };
                        listLTCModel.Add(ltcModel);
                    }
                }
            }

            ViewBag.Khoa = new SelectList(contextK.GetAll(), "MaKhoa", "TenKhoa");
            if (listLTCModel.Count > 0)
            {
                return Json(new { msg = listLTCModel });
            }
            return Json(new { msg = "FALSE" });

        }
        #endregion

        public JsonResult LocTheoKhoa(string maKhoa)
        {
            string maSV = Session["MaSV"].ToString().Trim();
            if (string.IsNullOrEmpty(maKhoa))
            {
                return Json(new { msg = "FALSE" });
            }
            KhoaBLL contextK = new KhoaBLL();
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            List<LopTinChi> lstLTC = contextLTC.GetAll();

            MonHocBLL contextMH = new MonHocBLL();
            GiangVienBLL contextGV = new GiangVienBLL();
            List<LopTinChiModel> listLTCModel = new List<LopTinChiModel>();
            foreach (LopTinChi ltc in lstLTC)
            {
                var query = ltc.SinhViens.Where(x => x.MaSV == maSV).FirstOrDefault();
                if (query == null)
                {
                    if (ltc.TrangThai == true && ltc.SinhViens.Count < 50)
                    {
                        GiangVien giangVien = contextGV.GetById(ltc.MaGV);
                        if (giangVien.MaKhoa == maKhoa)
                        {
                            MonHoc monHoc = contextMH.GetById(ltc.MaMonHoc);
                            LopTinChiModel ltcModel = new LopTinChiModel()
                            {
                                MaLopTC = ltc.MaLopTC,
                                TrangThai = ltc.TrangThai,    
                                MaGV = ltc.MaGV,
                                MaMonHoc = ltc.MaMonHoc,
                                Nhom = ltc.Nhom,
                                NienKhoa = ltc.NienKhoa,
                                GiangVienModel = new GiangVienModel()
                                {
                                    MaGV = giangVien.MaGV,
                                    Email = giangVien.Email,
                                    GioiTinh = giangVien.GioiTinh,
                                    HoVaTenLot = giangVien.HoVaTenLot,
                                    MaKhoa = giangVien.MaKhoa,
                                    MatKhau = giangVien.MatKhau,
                                    NgaySinh = giangVien.NgaySinh,
                                    SDT = giangVien.SDT,
                                    TenGV = giangVien.TenGV,
                                    TrinhDo = giangVien.TrinhDo
                                },
                                MonHoc = new MonHocModel
                                {
                                    MaMH = monHoc.MaMH,
                                    SoTinChiLyThuyet = monHoc.SoTinChiLyThuyet,
                                    SoTinChiThucHanh = monHoc.SoTinChiThucHanh,
                                    TenMH = monHoc.TenMH
                                }
                            };
                            listLTCModel.Add(ltcModel);
                        }
                    }
                }
            }

            ViewBag.Khoa = new SelectList(contextK.GetAll(), "MaKhoa", "TenKhoa");
            if (listLTCModel.Count > 0)
            {
                return Json(new { msg = listLTCModel });
            }
            return Json(new { msg = "FALSE" });
        }
    }
}