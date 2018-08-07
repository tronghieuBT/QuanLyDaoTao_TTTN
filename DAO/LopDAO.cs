using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO
{
    public class LopDAO
    {
        #region GetByMaKhoa

        /// <summary>
        /// Lấy danh sach lop theo khoa
        /// </summary>
        /// <param name="maKhoa"></param>
        /// <returns>List<Lop></LOP></returns>
        public List<Lop> GetByMaKhoa(string maKhoa)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.Lops.Where(x => x.MaKhoa == maKhoa).ToList();
                return query;
            }
        }

        #endregion GetByMaKhoa

        #region GetAll

        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<Lop> GetAll()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var listLop = context.Lops.ToList();
                return listLop;
            }
        }

        #endregion GetAll

        #region GetById

        /// <summary>
        /// Lấy 1 record dựa vào ma lop
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>Khoa</returns>
        public Lop GetById(string maLop)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                Lop lop = context.Lops.Where(x => x.MaLop == maLop).FirstOrDefault();
                return lop;
            }
        }

        #endregion GetById

        #region Create

        /// <summary>
        /// Tạo mới 1 record
        /// </summary>
        /// <param name="lop">lop</param>
        public void Create(Lop lop)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.Lops.Add(lop);
                context.SaveChanges();
            }
        }

        #endregion Create

        #region Edit

        /// <summary>
        /// Chỉnh sửa 1 record
        /// </summary>
        /// <param name="lop"></param>
        public void Edit(Lop lop)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.Lops.Where(x => x.MaLop == lop.MaLop).FirstOrDefault();
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
        public void Delete(string maLop)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                Lop lp = context.Lops.Find(maLop);
                if (lp != null)
                {
                    context.Lops.Remove(lp);
                    context.SaveChanges();
                }
            }
        }

        #endregion Delete



        #region GetByMaKhoaAndNienKhoa

        /// <summary>
        /// Lấy danh sach lop theo khoa
        /// </summary>
        /// <param name="maKhoa"></param>
        /// <returns>List<Lop></LOP></returns>
        public List<Lop> GetByMaKhoaAndNienKhoa(string maKhoa, string nienKhoa)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.Lops.Where(x => x.MaKhoa == maKhoa && x.NienKhoa == nienKhoa).ToList();
                return query;
            }
        }

        #endregion GetByMaKhoaAndNienKhoa
    }
}