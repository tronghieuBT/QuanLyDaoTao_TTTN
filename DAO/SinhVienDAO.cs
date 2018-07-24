using System.Collections.Generic;
using System.Linq;

namespace DAO
{
    public class SinhVienDAO
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
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.SinhViens.Where(x => x.Email == email && x.MatKhau == pass).FirstOrDefault();
                return query;
            }
        }
        #endregion

        #region   GetByMaLop
        /// <summary>
        /// Lấy danh sach sinh vien theo lop
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>List<Sinhvien></returns>
        public List<SinhVien> GetByMaLop(string maLop)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.SinhViens.Where(x => x.MaLop == maLop).ToList();
                return query;
            }
        }
        #endregion
    }
}