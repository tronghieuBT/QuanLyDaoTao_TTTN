using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GiaTinChiBLL
    {
        private GiaTinChiDAO context = new GiaTinChiDAO();

        #region GetByHDT    
        /// <summary>
        /// Lấy danh sach lop theo hệ đào tạo
        /// </summary>
        /// <param name="maHDT">mã hệ đào tạo</param>
        /// <returns>List<Lop></LOP></returns>
        public List<GiaTinChi> GetByHeDT(string maHDT)
        {
            List<GiaTinChi> lstGia = new List<GiaTinChi>();
            try
            {
                lstGia = context.GetByHeDT(maHDT);
                return lstGia;
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
        public List<GiaTinChi> GetAll()
        {
            try
            {
                List<GiaTinChi> lstGia = context.GetAll();
                return lstGia;
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
        /// Lay 1 record dua vao ma giá tín chỉ
        /// </summary>
        /// <param name="maGiaTC">Mã giá tín chỉ</param>
        /// <returns>Giá tín chỉ</returns>
        public GiaTinChi GetById(string maGiaTC)
        {
            try
            {
                GiaTinChi gtc = context.GetById(maGiaTC);
                return gtc;
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
        /// <param name="giaTC">Giá tín chỉ</param>
        /// <returns>-1 : Input rỗng</returns>
        /// <returns> 0 : Trùng</returns>
        /// <returns> 1 : Thành công</returns>
        /// <returns>2 : Exception</returns>
        public int Create(GiaTinChi giaTC)
        {
            if (giaTC == null)
            {
                return -1;
            }
            try
            {
                GiaTinChi lpTest = context.GetById(giaTC.MaGiaTC);
                if (lpTest != null)
                {
                    return 0;
                }
                context.Create(giaTC);
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
        /// Chỉnh sửa giá tín chỉ
        /// </summary>
        /// <param name="giaTC">Giá tín chỉ</param>
        /// <returns>true, false</returns>
        public bool Edit(GiaTinChi giaTC)
        {
            if (giaTC == null)
            {
                return false;
            }
            try
            {
                context.Edit(giaTC);
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
        /// Xoa giá tín chỉ
        /// </summary>
        /// <param name="maGiaTC">mã giá tín chỉ</param>
        /// <returns>true, false</returns>
        public bool Delete(string maGiaTC)
        {
            GiaTinChi lp = new GiaTinChi();
            try
            {
                lp = context.GetById(maGiaTC);
                if (lp != null)
                {
                    context.Delete(maGiaTC);
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
    }
}
