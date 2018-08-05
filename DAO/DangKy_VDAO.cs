using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DangKy_VDAO
    {
        #region   GetByMaLopTC
        /// <summary>
        /// Lấy danh sach sinh vien theo lop
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>List<Sinhvien></returns>
        public List<DangKy_V> GetByMaLop(int maLopTC)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.DangKy_V.Where(x => x.MaLopTC == maLopTC).ToList();
                return query;
            }
        }
        #endregion
    }
}
