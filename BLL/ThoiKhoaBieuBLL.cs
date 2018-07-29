using BLL.Common;
using DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThoiKhoaBieuBLL
    {
        private ThoiKhoaBieuDAO context = new ThoiKhoaBieuDAO();

        #region GetAll
        /// <summary>
        /// Lay tat ca record
        /// </summary>
        /// <returns>List</returns>
        public List<ThoiKhoaBieu> GetAll()
        {
            ThoiKhoaBieuDAO context = new ThoiKhoaBieuDAO();
            try
            {
                List<ThoiKhoaBieu> lstTKB = context.GetAll();
                return lstTKB;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region GetByMaLopTC
        /// <summary>
        /// Lấy record theo maLopTC 
        /// </summary>
        /// <returns>List</returns>
        public List<ThoiKhoaBieu> GetByMaLopTC(int maLopTC)
        {
            ThoiKhoaBieuDAO context = new ThoiKhoaBieuDAO();
            try
            {
                List<ThoiKhoaBieu> lstTKB = context.GetByMaLopTC(maLopTC);
                return lstTKB;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region Create
        public void Create(ThoiKhoaBieu tkb)
        {
            try
            {
                context.Create(tkb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        #endregion

        #region Edit
        public void Edit(ThoiKhoaBieu tkb)
        {
            try
            {
                context.Edit(tkb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region Delete
        public void Delete(DateTime ngay, string buoi, int maLopTC)
        {
            try
            {
                context.Delete(ngay, buoi, maLopTC);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion


        /// <summary>
        /// Lấy số tiết trong khaongr ngày
        /// </summary>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        /// <param name="soBuoiHocTrongTuan"></param>
        /// <returns></returns>
        public int SoTietHocCoTheMo(DateTime dtStart, DateTime dtEnd, int soBuoiHocTrongTuan)
        {
            LopTinChiBLL contextLTC = new LopTinChiBLL();
            List<LopTinChi> lstLTC = contextLTC.GetAll();
            Date supportDateTime = new Date();
            int dem = 0;
            if (dtStart.DayOfYear > dtEnd.DayOfYear) return 0;
            if (soBuoiHocTrongTuan < 0 && soBuoiHocTrongTuan > 48) return 0;
            //lấy tuần bắt đầu và tuần kết thúc
            int tuanBD = 0, tuanKT = 0, tongSoTuan = 0;

            if (dtStart.Year == dtEnd.Year)
            {
                List<string> lstTuan = supportDateTime.GetListDate(dtStart.Year);
                for (int i = 0; i < lstTuan.Count; i++)
                {
                    DateTime tempDTStart = new DateTime();
                    DateTime tempDTEnd = new DateTime();
                    // Lấy datetime từ list Tuần và format về "dd/mm/yy"
                    tempDTStart = DateTime.Parse(lstTuan[i].Split('-')[1], new CultureInfo("en-US"));
                    tempDTEnd = DateTime.Parse(lstTuan[i].Split('-')[3], new CultureInfo("en-US"));
                    // Nếu ngày bắt đầu không phải là thứ 2 thì lấy thứ 2 của tuần kế tiếp
                    if (dtStart.DayOfWeek != DayOfWeek.Monday)
                    {
                        while (dtStart.DayOfWeek != DayOfWeek.Monday)
                        {
                            dtStart = dtStart.AddDays(1);
                        }
                    }
                    if (dtStart.DayOfYear >= tempDTStart.DayOfYear && dtStart.DayOfYear <= tempDTEnd.DayOfYear)
                    {
                        tuanBD = i;
                    }
                    if (dtEnd.DayOfYear >= tempDTStart.DayOfYear && dtEnd.DayOfYear <= tempDTEnd.DayOfYear)
                    {
                        tuanKT = i;
                    }
                    if (tuanBD != 0 && tuanKT != 0)
                    {
                        break;
                    }
                }
            }
            // nếu 2 năm khác nhau vì 1 học kỳ chỉ ở trong 1 năm
            else
            {
                return 0;
            }
            tongSoTuan = tuanKT - tuanBD + 1;
            dem = tongSoTuan * soBuoiHocTrongTuan * 4;
            return dem;
        }


        //public bool TaoTKBTuDong(int maLopTC)
        //{

        //    ThoiKhoaBieu thoiKhoaBieuNew = new ThoiKhoaBieu();
        //    List<ThoiKhoaBieu> lstTKBLuuTaoMoi = new List<ThoiKhoaBieu>();

        //    List<SupportTKB> lstSupportTKB = new List<SupportTKB>();
        //    LopTinChiBLL contextLTC = new LopTinChiBLL();
        //    ThoiKhoaBieuBLL contextTKB = new ThoiKhoaBieuBLL();
        //    GiangVienBLL contextGV = new GiangVienBLL();
        //    MonHocBLL contextMH = new MonHocBLL();
        //    GiangVien giangVien = new GiangVien();

        //    List<ThoiKhoaBieu> lstTKB = contextTKB.GetAll();
        //    LopTinChi ltc = contextLTC.GetById(maLopTC);
        //    if (ltc == null)
        //    {
        //        return false;
        //    }
        //    giangVien = contextGV.GetById(ltc.MaGV);
        //    giangVien.LopTinChis = contextLTC.GetByMaGV(giangVien.MaGV);


        //    // nếu lớp tín chỉ đang mở
        //    if (ltc.TrangThai == true)
        //    {
        //        foreach (ThoiKhoaBieu tkb in lstTKB)
        //        {
        //            //nếu trong tkb đã có mã lớp tc
        //            if (tkb.MaLopTC == ltc.MaLopTC)
        //            {
        //                return false;
        //            }
        //        }
        //        // lớp tc không có trong tkb
        //        //duyet cac lop tin chi cua giang vien có trạng thái true
        //        for (int i = 0; i < giangVien.LopTinChis.Count; i++)
        //        {
        //            if (giangVien.LopTinChis.ElementAt(i).TrangThai == true)
        //            {
        //                // lấy list thời khóa biểu của lớp tín chỉ giảng viên đang dạy
        //                List<ThoiKhoaBieu> lstTKBCuaGiangVien = contextTKB.GetByMaLopTC(giangVien.LopTinChis.ElementAt(i).MaLopTC);
        //                if (lstTKBCuaGiangVien != null)
        //                {
        //                    giangVien.LopTinChis.ElementAt(i).ThoiKhoaBieux = lstTKBCuaGiangVien;
        //                    //duyệt thời khóa biểu của giảng viên , nếu ngày nào có lịch thì lưu lại
        //                    foreach (ThoiKhoaBieu thoiKhoaBieu in giangVien.LopTinChis.ElementAt(i).ThoiKhoaBieux)
        //                    {
        //                        SupportTKB spTKB = new SupportTKB();
        //                        spTKB.Ngay = thoiKhoaBieu.Ngay;
        //                        spTKB.MaLopTC = thoiKhoaBieu.MaLopTC;
        //                        spTKB.TietBD = thoiKhoaBieu.TietBD;
        //                        spTKB.TrangThai = false;
        //                    }
        //                }
        //            }
        //        }
        //        if(Int32.Parse(ltc.NienKhoa.Split('-')[0]) < DateTime.UtcNow.Year)
        //        {
        //            ltc.TrangThai = false;
        //            contextLTC.Edit(ltc);
        //        }
        //        DateTime dtNow = DateTime.UtcNow;
        //        MonHoc monHocCuaLopTC = contextMH.GetById(ltc.MaMonHoc);
        //        int tongSoTinChi = monHocCuaLopTC.SoTinChiLyThuyet + monHocCuaLopTC.SoTinChiThucHanh;
        //        int soTietCuaLopTC = tongSoTinChi*15;
        //        int soBuoiHocCuaLopTC = 0;
        //        // nếu tổng số tiết chia cho 4 tiết 1 buổi có dư thì thêm 1 buổi 
        //        if(soTietCuaLopTC % 4 == 0)
        //        {
        //            soBuoiHocCuaLopTC = soTietCuaLopTC / 4;
        //        }
        //        else
        //        {
        //            soBuoiHocCuaLopTC = (int) soTietCuaLopTC / 4 + 1;
        //        }
        //        switch (ltc.HocKy)
        //        {
        //            case 1:
        //                {
        //                    DateTime dayStart = new DateTime(DateTime.UtcNow.Year, 1, 9);
        //                    DateTime dayEnd = new DateTime(DateTime.UtcNow.Year, 12, 31);
        //                    if(dtNow.Year == dayStart.Year)
        //                    {
        //                        if(dtNow.Month > 9 && dtNow.Month < 12)
        //                        {      
        //                            Date supportDateTime = new Date();
        //                            List<string> lstTuan = supportDateTime.GetListDate(dtNow.Year);
        //                            int tuanHienTai = 0;
        //                            for (int i = 0; i < lstTuan.Count; i++)
        //                            {
        //                                DateTime tempDTStart = new DateTime();
        //                                DateTime tempDTEnd = new DateTime();
        //                                // Lấy datetime từ list Tuần và format về "dd/mm/yy"
        //                                tempDTStart = DateTime.Parse(lstTuan[i].Split('-')[1], new CultureInfo("en-US"));
        //                                tempDTEnd = DateTime.Parse(lstTuan[i].Split('-')[3], new CultureInfo("en-US"));
        //                                if (dtNow.DayOfYear >= tempDTStart.DayOfYear && dtNow.DayOfYear <= tempDTEnd.DayOfYear)
        //                                {
        //                                    tuanHienTai = i;
        //                                    break;
        //                                }
        //                            }
        //                            // xem số tuần còn lại của học kỳ 1 năm hiện tại bỏ tuần hiện tại và tuần sau
        //                            int soTuanConLaiCuaHocKy = lstTuan.Count - tuanHienTai-2;
        //                            // nếu tổng số buổi học của lớp tín chỉ > 5  thì tuần học 2 buổi.
        //                            // Ngược   lại tuần học 1 buổi
        //                            int soTietHocCoTheMo = 0;
        //                            int soBuoiMotTuan = 0;
        //                            if (tongSoTinChi > 5)
        //                            {
        //                                soBuoiMotTuan = 2;
        //                                soTietHocCoTheMo = SoTietHocCoTheMo(dtNow, dayEnd, soBuoiMotTuan);
        //                            }
        //                            else
        //                            {
        //                                soBuoiMotTuan = 1;
        //                                soTietHocCoTheMo = SoTietHocCoTheMo(dtNow, dayEnd, soBuoiMotTuan);
        //                            }
        //                            // nếu số tiết đủ để mở lớp thì đóng lớp
        //                            if(soTietHocCoTheMo < soTietCuaLopTC)
        //                            {
        //                                ltc.TrangThai = false;
        //                                contextLTC.Edit(ltc);
        //                                return false;
        //                            }

        //                            for(int i = 0; i< soTuanConLaiCuaHocKy; i++)
        //                            {
        //                                DateTime tempDTStart = new DateTime();
        //                                DateTime tempDTEnd = new DateTime();
        //                                // Lấy datetime từ list Tuần và format về "dd/mm/yy"
        //                                tempDTStart = DateTime.Parse(lstTuan[tuanHienTai+2 +i].Split('-')[1], new CultureInfo("en-US"));
        //                                tempDTEnd = DateTime.Parse(lstTuan[tuanHienTai + 2 + i].Split('-')[3], new CultureInfo("en-US"));
                                        
        //                                while(tempDTStart.DayOfWeek!= DayOfWeek.Sunday)
        //                                {
        //                                    if (lstSupportTKB.Count == 0)
        //                                    {
        //                                        if(soBuoiMotTuan == 1)
        //                                        {
        //                                            if(tempDTStart.DayOfWeek == DayOfWeek.Monday)
        //                                            {
        //                                                thoiKhoaBieuNew.Ngay = tempDTStart;
        //                                                thoiKhoaBieuNew.MaLopTC = maLopTC;
        //                                                thoiKhoaBieuNew.TietBD = 1;
                                                        
        //                                            }
        //                                        }
        //                                    }
        //                                }

        //                            }
        //                        }
        //                        return false;
        //                    }
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    DateTime dayStart = new DateTime(DateTime.UtcNow.Year, 1, 1);
        //                    DateTime dayEnd = new DateTime(DateTime.UtcNow.Year, 5, 15);
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    DateTime dayStart = new DateTime(DateTime.UtcNow.Year, 5, 16);
        //                    DateTime dayEnd = new DateTime(DateTime.UtcNow.Year, 8, 30);
        //                    break;
        //                }
        //        }
        //    }
        //    //trạng thái false thì lớp đó đã đóng nên không tạo tkb
        //    return false;  
        //}
    }
}
