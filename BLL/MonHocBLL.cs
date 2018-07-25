using DAO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class MonHocBLL
    {
        private MonHocDAO context = new MonHocDAO();

        #region GetAll

        /// <summary>
        /// Lay tat ca record
        /// </summary>
        /// <returns>List monhoc</returns>
        public List<MonHoc> GetAll()
        {
            try
            {
                List<MonHoc> lstMH = context.GetAll();
                return lstMH;
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
        /// <param name="maMH">Mã môn học</param>
        /// <returns>Lop</returns>
        public MonHoc GetById(string maMH)
        {
            if (string.IsNullOrEmpty(maMH))
            {
                return null;
            }
            try
            {
                MonHoc mh = context.GetById(maMH);
                return mh;
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
        /// <param name="monHoc">Môn học</param>
        /// <returns>-1 : Input rỗng</returns>
        /// <returns> 0 : Trùng</returns>
        /// <returns> 1 : Thành công</returns>
        /// <returns>2 : Exception</returns>
        public int Create(MonHoc monHoc)
        {
            if (monHoc == null)
            {
                return -1;
            }
            try
            {
                MonHoc mh = context.GetById(monHoc.MaMH);
                if (mh != null)
                {
                    return 0;
                }
                context.Create(mh);
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
        /// Chỉnh sửa khoa
        /// </summary>
        /// <param name="mh">Môn học</param>
        /// <returns>true, false</returns>
        public bool Edit(MonHoc mh)
        {
            if (mh == null)
            {
                return false;
            }
            try
            {
                context.Edit(mh);
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
        /// <param name="maMH">Mã môn học</param>
        /// <returns>true, false</returns>
        public bool Delete(string maMH)
        {
            if (string.IsNullOrEmpty(maMH))
            {
                return false;
            }
            try
            {
                context.Delete(maMH);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        #endregion Delete
    }
}