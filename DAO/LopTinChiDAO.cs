using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO
{
    public class LopTinChiDAO
    {
        #region GetByMaGV

        /// <summary>
        /// Lấy danh sach lop theo giảng viên
        /// </summary>
        /// <param name="maGV"></param>
        /// <returns>List<Lop></LOP></returns>
        public List<LopTinChi> GetByMaGV(string maGV)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.LopTinChis.Where(x => x.MaGV == maGV).ToList();
                return query;
            }
        }

        #endregion GetByMaGV

        #region GetAll

        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<LopTinChi> GetAll()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var listLop = context.LopTinChis.Include(l => l.GiangVien).Include(l => l.MonHoc).Include(l => l.ThoiKhoaBieux).ToList();
                return listLop;
            }
        }

        #endregion GetAll

        #region GetById

        /// <summary>
        /// Lấy 1 record dựa vào mã lớp tín chỉ
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>Khoa</returns>
        public LopTinChi GetById(int id)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                LopTinChi lop = context.LopTinChis.Where(x => x.MaLopTC == id).FirstOrDefault();
                return lop;
            }
        }

        #endregion GetById

        #region Create

        /// <summary>
        /// Tạo mới 1 record
        /// </summary>
        /// <param name="lop">lop</param>
        public void Create(LopTinChi lop)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.LopTinChis.Add(lop);
                context.SaveChanges();
            }
        }

        #endregion Create

        #region Edit

        /// <summary>
        /// Chỉnh sửa 1 record
        /// </summary>
        /// <param name="lop"></param>
        public void Edit(LopTinChi lop)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.LopTinChis.Where(x => x.MaLopTC == lop.MaLopTC).FirstOrDefault();        
                context.Entry(query).CurrentValues.SetValues(lop);
                context.SaveChanges();
            }
        }

        #endregion Edit

        #region Delete

        /// <summary>
        ///  Xoa 1 record dựa vào mã lop
        /// </summary>
        /// <param name="maLop"></param>
        public void Delete(int maLop)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                LopTinChi lp = context.LopTinChis.Find(maLop);
                if (lp != null)
                {
                    context.LopTinChis.Remove(lp);
                    context.SaveChanges();
                }
            }
        }

        #endregion Delete

        #region GetByNhomAndNienKhoaAndMaMon

        /// <summary>
        /// Lấy danh sach lop theo khoa
        /// </summary>
        /// <param name="maKhoa"></param>
        /// <returns>List<Lop></LOP></returns>
        public LopTinChi GetByNhomAndNienKhoaAndMaMon(int nhom, string nienKhoa, string maMon)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.LopTinChis.Where(x => x.Nhom == nhom && x.NienKhoa == nienKhoa && x.MaMonHoc == maMon).FirstOrDefault();
                return query;
            }
        }

        #endregion GetByNhomAndNienKhoaAndMaMon

        #region  GetByMaGVVaMaMH
        public List<LopTinChi> GetByMaGVVaMaMH(string maGV, string maMH)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query  = context.LopTinChis.Where(x=> x.MaGV == maGV && x.MaMonHoc == maMH);
                if (query != null)
                {
                    List<LopTinChi> lstLopTC = query.ToList();
                    return lstLopTC;
                }
                return null;
            }
        }
        #endregion
    }
}