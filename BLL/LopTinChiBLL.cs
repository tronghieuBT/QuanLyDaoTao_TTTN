using DAO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class LopTinChiBLL
    {
        private LopTinChiDAO context = new LopTinChiDAO();

        #region GetByMaGV

        /// <summary>
        /// Lấy danh sach lop theo giảng viên
        /// </summary>
        /// <param name="maGV"></param>
        /// <returns>List<Lop></LOP></returns>
        public List<LopTinChi> GetByMaGV(string maGV)
        {
            List<LopTinChi> lstLop = new List<LopTinChi>();
            try
            {
                lstLop = context.GetByMaGV(maGV);
                return lstLop;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        #endregion GetByMaGV

        #region GetAll

        /// <summary>
        /// Lay tat ca record
        /// </summary>
        /// <returns>List lop</returns>
        public List<LopTinChi> GetAll()
        {
            try
            {
                List<LopTinChi> lstLop = context.GetAll();
                return lstLop;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        #endregion GetAll

        #region GetById

        /// <summary>
        /// Lay 1 record dua vao ma lop
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>Lop</returns>
        public LopTinChi GetById(int maLop)
        {
            try
            {
                LopTinChi lp = context.GetById(maLop);
                return lp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        #endregion GetById

        #region Create

        /// <summary>
        /// Tao moi 1 record
        /// </summary>
        /// <param name="lop"></param>
        /// <returns>-1 : Input rỗng</returns>
        /// <returns> 0 : Trùng</returns>
        /// <returns> 1 : Thành công</returns>
        /// <returns>2 : Exception</returns>
        public int Create(LopTinChi lop)
        {
            if (lop == null)
            {
                return -1;
            }
            if(lop.NienKhoa.Length == 4)
            {
                int nk = Int32.Parse(lop.NienKhoa) + 1;
                lop.NienKhoa = lop.NienKhoa + "-" + nk.ToString().Trim();            
            }
            try
            {
                LopTinChi lpTest = context.GetById(lop.MaLopTC);
                if (lpTest != null)
                {
                    return 0;
                }
                context.Create(lop);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 2;
            }
        }

        #endregion Create

        #region Edit

        /// <summary>
        /// Chỉnh sửa lớp tín chỉ
        /// </summary>
        /// <param name="lop"></param>
        /// <returns>true, false</returns>
        public bool Edit(LopTinChi lop)
        {
            if (lop == null)
            {
                return false;
            }
            if (lop.NienKhoa.Length == 4)
            {
                int nk = Int32.Parse(lop.NienKhoa) + 1;
                lop.NienKhoa = lop.NienKhoa + "-" + nk.ToString().Trim();
            }
            try
            {
                context.Edit(lop);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        #endregion Edit

        #region Delete

        /// <summary>
        /// Xoa khoa theo ma khoa
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>true, false</returns>
        public bool Delete(int maLop)
        {
            LopTinChi lp = new LopTinChi();
            try
            {
                lp = context.GetById(maLop);
                if (lp != null)
                {
                    context.Delete(maLop);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        #endregion Delete

        #region  GetListLTCOpen
        public List<LopTinChi> GetListLTCOpen(ICollection<LopTinChi> lst)
        {
            List<LopTinChi> lstOpen = new List<LopTinChi>();
            foreach (LopTinChi ltc in lst)
            {
                if (ltc.TrangThai == true)
                {
                    lstOpen.Add(ltc);
                }
            }
            return lstOpen;
        }
        #endregion
    }
}