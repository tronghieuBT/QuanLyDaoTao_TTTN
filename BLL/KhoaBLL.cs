using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhoaBLL
    {

        #region GetAll
        /// <summary>
        /// Lay tat ca record
        /// </summary>
        /// <returns>List</returns>
        public List<Khoa> GetAll()
        {
            KhoaDAO context = new KhoaDAO();
            try
            {        
                List<Khoa> lstKhoa = context.GetAll();
                return lstKhoa;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region  GetById
        /// <summary>
        /// Lay 1 record dua vao ma khoa
        /// </summary>
        /// <param name="maKhoa"></param>
        /// <returns>Khoa</returns>
        public Khoa GetById(string maKhoa)
        {
            if(maKhoa == "" || maKhoa == null)
            {
                return null;
            }
            KhoaDAO context = new KhoaDAO();
            try
            {
                Khoa khoa = context.GetById(maKhoa);
                return khoa;
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
        /// <param name="khoa"></param>
        /// <returns>true , false</returns>
        public bool Create(Khoa khoa)
        {
            if(khoa == null)
            {
                return false;
            }
            KhoaDAO context = new KhoaDAO();
            try
            {
                context.Create(khoa);
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
        public bool Edit(Khoa khoa)
        {
            if (khoa == null)
            {
                return false;
            }
            KhoaDAO context = new KhoaDAO();
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
        /// <param name="maKhoa"></param>
        /// <returns></returns>
        public bool Delete(string maKhoa)
        {
            if (string.IsNullOrEmpty(maKhoa))
            {
                return false;
            }
            KhoaDAO context = new KhoaDAO();
            Khoa kh = new Khoa();
            try
            {
                kh = context.GetById(maKhoa);
                if (kh != null)
                {
                    LopBLL lopContext = new LopBLL();
                    List<Lop> lstLop = lopContext.GetByMaKhoa(maKhoa);
                    if(lstLop.Count == 0)
                    {
                        context.Delete(maKhoa);
                        return true;
                    }
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
    }
}
