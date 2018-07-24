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
            SinhVienDAO context = new SinhVienDAO();
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
            SinhVienDAO sv = new SinhVienDAO();
            List<SinhVien> lstSV = new List<SinhVien>();
            try
            {
                lstSV = sv.GetByMaLop(maLop);
                return lstSV;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion
    }
}
