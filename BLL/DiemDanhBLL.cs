using DAO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class DiemDanhBLL
    {
        private DiemDanhDAO context = new DiemDanhDAO();

        #region GetByMaSV

        /// <summary>
        /// Lấy danh sách điểm danh theo mã sinh viên
        /// </summary>
        /// <param name="maSV"></param>
        /// <returns>List điểm danh</returns>
        public List<DiemDanh> GetByMaSV(string maSV)
        {
            List<DiemDanh> lstDiemDanh = new List<DiemDanh>();
            try
            {
                lstDiemDanh = context.GetByMaSV(maSV);
                return lstDiemDanh;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        #endregion GetByMaSV

        #region GetAll

        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<DiemDanh> GetAll()
        {
            try
            {
                List<DiemDanh> lstDiemDanh = context.GetAll();
                return lstDiemDanh;
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
        /// Lấy 1 record dựa vào mã phiếu điểm danh
        /// </summary>
        /// <param name="maPDD"></param>
        /// <returns>Khoa</returns>
        public DiemDanh GetById(string maPDD)
        {
            try
            {
                DiemDanh dd = context.GetById(maPDD);
                return dd;
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
        /// Tạo mới 1 record
        /// </summary>
        /// <param name="dd">Điểm danh</param>
        public void Create(DiemDanh dd)
        {
            try
            {
                context.Create(dd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion Create

        #region Edit

        /// <summary>
        /// Chỉnh sửa 1 record
        /// </summary>
        /// <param name="dd">Điểm danh</param>
        public void Edit(DiemDanh dd)
        {
            if (dd == null)
            {
                return;
            }
            try
            {
                context.Edit(dd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion Edit

        #region Delete

        /// <summary>
        ///  Xoa 1 record dựa vào mã phiếu điểm danh
        /// </summary>
        /// <param name="maPDD">Mã phiếu điểm danh</param>
        public void Delete(string maPDD)
        {
            try
            {
                context.Delete(maPDD);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion Delete

        #region GetByMaLopTC

        /// <summary>
        /// Lấy danh sách điểm danh theo mã lớp tín chỉ
        /// </summary>
        /// <param name="maLopTC">Mã lớp tín chỉ</param>
        /// <returns>List điểm danh</returns>
        public List<DiemDanh> GetByMaKhoaAndNienKhoa(int maLopTC)
        {
            List<DiemDanh> lstDiemDanh = new List<DiemDanh>();
            try
            {
                lstDiemDanh = context.GetByMaLopTC(maLopTC);
                return lstDiemDanh;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        #endregion GetByMaLopTC
    }
}