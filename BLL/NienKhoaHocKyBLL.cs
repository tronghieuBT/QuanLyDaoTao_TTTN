using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NienKhoaHocKyBLL
    {
        NienKhoaHocKyDAO context = new NienKhoaHocKyDAO();
        #region GetAll
        /// <summary>
        /// Lay tat ca record
        /// </summary>
        /// <returns>List</returns>
        public List<NienKhoaHocKy> GetAll()
        {
            try
            {
                List<NienKhoaHocKy> lstKhoa = context.GetAll();
                return lstKhoa;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region  GetById
        /// <summary>
        /// Lay 1 record dua vao ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>Khoa</returns>
        public NienKhoaHocKy GetById(string ID)
        {
            if (ID == "" || ID == null)
            {
                return null;
            }
            try
            {
                NienKhoaHocKy nk = context.GetById(ID);
                return nk;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region   Create
        /// <summary>
        /// Tao moi 1 record
        /// </summary>
        /// <param name="nienKhoaHocKy">Niên khóa học kỳ</param>
        /// <returns>true , false</returns>
        public bool Create(NienKhoaHocKy nienKhoaHocKy)
        {
            if (nienKhoaHocKy == null)
            {
                return false;
            }
            try
            {
                context.Create(nienKhoaHocKy);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// Chỉnh sửa khoa
        /// </summary>
        /// <param name="khoa"></param>
        /// <returns>true, false</returns>
        public bool Edit(NienKhoaHocKy khoa)
        {
            if (khoa == null)
            {
                return false;
            }
            try
            {
                context.Edit(khoa);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Xoa khoa theo ma khoa
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                return false;
            }
            NienKhoaHocKy kh = new NienKhoaHocKy();
            try
            {
                kh = context.GetById(ID);
                if (kh != null)
                {
                    context.Delete(ID);
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
        #endregion

        public List<NienKhoaHocKy> GetNienKhoa()
        {
            try
            {
                List<NienKhoaHocKy> lstKhoa = context.GetAll();
                List<NienKhoaHocKy> listNew = new List<NienKhoaHocKy>();
                foreach (NienKhoaHocKy item in lstKhoa)
                {
                    if (item.HocKy == 1 && Int32.Parse(item.NienKhoa.Substring(0,4).Trim())>= DateTime.UtcNow.Year)
                    {
                        listNew.Add(item);
                    }
                }
                return listNew;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
