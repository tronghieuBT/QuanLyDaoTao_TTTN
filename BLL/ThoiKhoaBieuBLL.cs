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
        public void Delete(ThoiKhoaBieu tkb)
        {
            try
            {
                context.Delete(tkb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region  SoTietHocCoTheMo
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
        #endregion

        #region GetCurent
        /// <summary>
        /// Lấy tất cả record trong  hiện tại, trước  và sau 1 năm
        /// </summary>
        /// <returns>List</returns>
        public List<ThoiKhoaBieu> GetTKBCurent()
        {
            LopTinChiBLL contextLopTC = new LopTinChiBLL();
            GiangVienBLL contextGV = new GiangVienBLL();
            int yearNow = DateTime.UtcNow.Year;
            int yearLast = yearNow - 1;
            int yearFt = yearNow + 1;

            List<ThoiKhoaBieu> listThoiKhoaBieu = context.GetAll();
            foreach (ThoiKhoaBieu tkb in listThoiKhoaBieu)
            {
                
                 if(tkb.Ngay.Year < yearNow && tkb.Ngay.Year > yearLast)
                {
                    listThoiKhoaBieu.Remove(tkb);
                }
                else
                {
                    tkb.LopTinChi = contextLopTC.GetById(tkb.MaLopTC);
                    tkb.LopTinChi.GiangVien = contextGV.GetById(tkb.LopTinChi.MaGV);
                }
            }
            return listThoiKhoaBieu;
        }
        #endregion
    }
}
