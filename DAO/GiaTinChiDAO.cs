using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAO
{
    public class GiaTinChiDAO
    {
        #region GetAll
        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<GiaTinChi> GetAll()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var listLop = context.GiaTinChis.Include(l => l.HeDaoTao).ToList();
                return listLop;
            }
        }
        #endregion

        #region GetById
        /// <summary>
        /// Lấy 1 record dựa vào ma giá tín chỉ
        /// </summary>
        /// <param name="maGiaTC">Mã giá tín chỉ</param>
        /// <returns>Khoa</returns>
        public GiaTinChi GetById(string maGiaTC)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                GiaTinChi giaTC = context.GiaTinChis.Where(x => x.MaGiaTC == maGiaTC).FirstOrDefault();
                return giaTC;
            }
        }
        #endregion

        #region Create
        /// <summary>
        /// Tạo mới 1 record
        /// </summary>
        /// <param name="lop">lop</param>
        public void Create(GiaTinChi giaTC)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.GiaTinChis.Add(giaTC);
                context.SaveChanges();
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// Chỉnh sửa 1 record
        /// </summary>
        /// <param name="lop"></param>
        public void Edit(GiaTinChi giaTC)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                GiaTinChi gtc = context.GiaTinChis.Find(giaTC.MaGiaTC);
                if (gtc != null)
                {
                    context.Entry(giaTC).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete
        /// <summary>
        ///  Xoa 1 record dựa vào mã giá tín chỉ
        /// </summary>
        /// <param name="maGiaTC">mã giá tín chỉ</param>
        public void Delete(string maGiaTC)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                GiaTinChi gtc = context.GiaTinChis.Find(maGiaTC);
                if (gtc != null)
                {
                    context.GiaTinChis.Remove(gtc);
                    context.SaveChanges();
                }
            }
        }
        #endregion

        #region GetByHeDT
        /// <summary>
        /// Lấy 1 record dựa vào mã hệ đào tào
        /// </summary>
        /// <param name="maHeDT">Mã hệ đào tào</param>
        /// <returns>Khoa</returns>
        public List<GiaTinChi> GetByHeDT(string maHeDT)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                List<GiaTinChi> giaTCs = context.GiaTinChis.Where(x => x.MaHDT == maHeDT).ToList();
                return giaTCs;
            }
        }
        #endregion

    }
}
