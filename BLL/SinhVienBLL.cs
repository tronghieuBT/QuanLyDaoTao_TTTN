using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SinhVienBLL
    {
        private SinhVienDAO context = new SinhVienDAO();

        #region  GetLoginSinhVien
        /// <summary>
        /// Get login SinhVien
        /// </summary>
        /// <param name="maSV"></param>
        /// <returns>NULL : false</returns>
        /// <return>#NULL : true</return>
        public SinhVien GetLoginSinhVien(string email, string pass)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                return null;
            }   
            try
            {
                SinhVien sv = context.GetLoginSinhVien(email, pass);
                return sv;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }
        #endregion

        #region GetByMaLop
        /// <summary>
        /// Lấy danh sach lop theo khoa
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>List<SinhVien></returns>
        public List<SinhVien> GetByMaLop(string maLop)
        {  
            List<SinhVien> lstSV = new List<SinhVien>();
            try
            {
                lstSV = context.GetByMaLop(maLop);
                return lstSV;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region GetAll
        public List<SinhVien> GetAll()
        {                                       
            List<SinhVien> lstSV = new List<SinhVien>();
            try
            {
                lstSV = context.GetAll();
                return lstSV;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion  

        #region GetById
        public SinhVien GetById(string maSV)
        {
            try
            {
                SinhVien sv = context.GetById(maSV);
                return sv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region Create
        public void Create(SinhVien sv)
        {
            try
            {
                context.Create(sv);       
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  
            }
        }
        #endregion

        #region Edit
        public void Edit(SinhVien sv)
        {
            try
            {
                context.Edit(sv);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region Delete
        public void Delete(string id)
        {
            try
            {
                context.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }   
        #endregion
    }
}
