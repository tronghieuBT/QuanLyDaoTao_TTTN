using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO
{
    public class DiemDanhDAO
    {
        #region GetByMaSV

        /// <summary>
        /// Lấy danh sách điểm danh theo mã sinh viên
        /// </summary>
        /// <param name="maSV"></param>
        /// <returns>List điểm danh</returns>
        public List<DiemDanh> GetByMaSV(string maSV)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.DiemDanhs.Where(x => x.MaSV == maSV).ToList();
                return query;
            }
        }

        #endregion GetByMaSV

        #region GetAll

        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<DiemDanh> GetAll()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var listLop = context.DiemDanhs.Include(l => l.LopTinChi).Include(l => l.SinhVien).ToList();
                return listLop;
            }
        }

        #endregion GetAll

        #region GetById

        /// <summary>
        /// Lấy 1 record dựa vào mã phiếu điểm danh
        /// </summary>
        /// <param name="maPDD"></param>
        /// <returns>Khoa</returns>
        public DiemDanh GetById(string maPDD)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                DiemDanh dd = context.DiemDanhs.Where(x => x.MaPhieuDD == maPDD).FirstOrDefault();
                return dd;
            }
        }

        #endregion GetById

        #region Create

        /// <summary>
        /// Tạo mới 1 record
        /// </summary>
        /// <param name="dd">Điểm danh</param>
        public void Create(DiemDanh dd)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.DiemDanhs.Add(dd);
                context.SaveChanges();
            }
        }

        #endregion Create

        #region Edit

        /// <summary>
        /// Chỉnh sửa 1 record
        /// </summary>
        /// <param name="dd">Điểm danh</param>
        public void Edit(DiemDanh dd)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.DiemDanhs.Where(x => x.MaPhieuDD == dd.MaPhieuDD).FirstOrDefault();
                context.Entry(query).CurrentValues.SetValues(dd);
                context.SaveChanges();
            }
        }

        #endregion Edit

        #region Delete

        /// <summary>
        ///  Xoa 1 record dựa vào mã phiếu điểm danh
        /// </summary>
        /// <param name="maPDD">Mã phiếu điểm danh</param>
        public void Delete(string maPDD)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                DiemDanh dd = context.DiemDanhs.Find(maPDD);
                if (dd != null)
                {
                    context.DiemDanhs.Remove(dd);
                    context.SaveChanges();
                }
            }
        }

        #endregion Delete

        #region GetByMaLopTC

        /// <summary>
        /// Lấy danh sách điểm danh theo mã lớp tín chỉ
        /// </summary>
        /// <param name="maLopTC">Mã lớp tín chỉ</param>
        /// <returns>List điểm danh</returns>
        public List<DiemDanh> GetByMaLopTC(int maLopTC)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.DiemDanhs.Where(x => x.MaLopTC == maLopTC).ToList();
                return query;
            }
        }

        #endregion GetByMaLopTC
    }
}