using System.Linq;

namespace DAO
{
    public class SinhVienDAO
    {
        /// <summary>
        /// Get login SinhVien
        /// </summary>
        /// <param name="maSV"></param>
        /// <returns>NULL : false</returns>
        /// <return>#NULL : true</return>
        public static SinhVien GetLoginSinhVien(string email, string pass)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.SinhViens.Where(x => x.Email == email && x.MatKhau == pass).FirstOrDefault();
                return query;
            }
        }
    }
}