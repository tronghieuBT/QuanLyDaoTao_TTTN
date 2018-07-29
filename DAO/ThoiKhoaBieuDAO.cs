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

        #region Create
        public void Create(ThoiKhoaBieu tkb)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.ThoiKhoaBieux.Add(tkb);
                context.SaveChanges();
            }
        }
        #endregion

        #region Edit
        public void Edit(ThoiKhoaBieu tkb)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.ThoiKhoaBieux.Where(x => x.Ngay == tkb.Ngay && x.Buoi == tkb.Buoi && x.MaLopTC == tkb.MaLopTC).FirstOrDefault();
                context.Entry(query).CurrentValues.SetValues(tkb);
                context.SaveChanges();
            }
        }
        #endregion

        #region Delete
        public void Delete(DateTime ngay, string buoi,int maLopTC)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                ThoiKhoaBieu tkb = context.ThoiKhoaBieux.Where(x => x.Ngay == ngay && x.Buoi == buoi&& x.MaLopTC == maLopTC).FirstOrDefault();
                context.ThoiKhoaBieux.Remove(tkb);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
