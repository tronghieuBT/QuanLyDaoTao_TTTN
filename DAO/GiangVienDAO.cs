using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GiangVienDAO
    {
        /// <summary>
        /// get login GiangVien
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>  
        /// <returns>NULL : false</returns>
        /// <return>#NULL : true</return>
        public static GiangVien GetLoginGiangVien(string email, string pass)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.GiangViens.Where(x => x.Email == email && x.MatKhau == pass).FirstOrDefault();
                return query;
            }
        }
    }
}
