using System;
using System.Collections.Generic;
using System.Linq;

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

        #endregion GetAll

        #region GetByMaLopTC

        /// <summary>
        /// Lấy record theo maLopTC
        /// </summary>
        /// <returns>List</returns>
        public List<ThoiKhoaBieu> GetByMaLopTC(int maLopTC)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                List<ThoiKhoaBieu> listThoiKhoaBieu = context.ThoiKhoaBieux.Where(x => x.MaLopTC == maLopTC).ToList();
                return listThoiKhoaBieu;
            }
        }

        #endregion GetByMaLopTC

        #region Create

        public void Create(ThoiKhoaBieu tkb)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.ThoiKhoaBieux.Add(tkb);
                context.SaveChanges();
            }
        }

        #endregion Create

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

        #endregion Edit

        #region Delete

        public void Delete(ThoiKhoaBieu tkb)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                ThoiKhoaBieu thoiKhoaBieu = context.ThoiKhoaBieux.Where(x => x.Ngay == tkb.Ngay && x.Buoi == tkb.Buoi && x.MaLopTC == tkb.MaLopTC).FirstOrDefault();
                context.ThoiKhoaBieux.Remove(thoiKhoaBieu);
                context.SaveChanges();
            }
        }

        #endregion Delete

        #region GetCurent

        /// <summary>
        /// Lấy tất cả record trong nam hiện tại
        /// </summary>
        /// <returns>List</returns>
        public List<ThoiKhoaBieu> GetCurent()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                List<ThoiKhoaBieu> listThoiKhoaBieu = context.ThoiKhoaBieux.ToList();
                return listThoiKhoaBieu;
            }
        }

        #endregion GetCurent
    }
}