using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ThoiKhoaBieuDAO
    {
        #region GetAll
        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<ThoiKhoaBieu> GetAll()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                List<ThoiKhoaBieu> listThoiKhoaBieu = context.ThoiKhoaBieux.ToList();
                return listThoiKhoaBieu;
            }
        }
        #endregion

        #region GetByMaLopTC
        /// <summary>
        /// Lấy record theo maLopTC 
        /// </summary>
        /// <returns>List</returns>
        public List<ThoiKhoaBieu> GetByMaLopTC(int maLopTC)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                List<ThoiKhoaBieu> listThoiKhoaBieu = context.ThoiKhoaBieux.Where(x=>x.MaLopTC == maLopTC).ToList();
                return listThoiKhoaBieu;
            }
        }
        #endregion
    }
}
