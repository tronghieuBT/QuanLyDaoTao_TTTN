using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAO
{
    public class SinhVienDAO
    {
        #region  GetLoginSinhVien
        /// <summary>
        /// Get login SinhVien
        /// </summary>
        /// <param name="maSV"></param>
        /// <returns>NULL : false</returns>
        /// <return>#NULL : true</return>
        public SinhVien GetLoginSinhVien(string email, string pass)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.SinhViens.Where(x => x.Email == email && x.MatKhau == pass).FirstOrDefault();
                return query;
            }
        }
        #endregion

        #region   GetByMaLop
        /// <summary>
        /// Lấy danh sach sinh vien theo lop
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>List<Sinhvien></returns>
        public List<SinhVien> GetByMaLop(string maLop)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.SinhViens.Where(x => x.MaLop == maLop).ToList();
                return query;
            }
        }
        #endregion

        #region GetALL
        public List<SinhVien> GetAll()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var sinhViens = context.SinhViens.Include(s => s.HeDaoTao1).Include(s=>s.DiemDanhs).Include(s=>s.DongHocPhis).Include(s => s.LopTinChis).Include(s => s.Lop).ToList();
                return sinhViens;
            }
        }
        #endregion

        #region GetById
        public SinhVien GetById(string maSV)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                SinhVien sinhVien = context.SinhViens.Find(maSV);
                return sinhVien;
            }
        }
        #endregion

        #region Create
        public void Create(SinhVien sv)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.SinhViens.Add(sv);
                context.SaveChanges();
            }
        }
        #endregion

        #region Edit
        public void Edit(SinhVien sinhVien)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.Entry(sinhVien).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        #endregion

        #region Delete
        public void Delete(string id)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                SinhVien sv = context.SinhViens.Find(id);
                context.SinhViens.Remove(sv);
                context.SaveChanges();
            }
        }
        #endregion

        //#region GetAllLopTinChi
        //public List<LopTinChi> GetAllLopTinChi(string MaSV)
        //{
        //    using (var context = new QuanLyDaoTaoEntities())
        //    {
        //        var query = context.;
        //    }
        //}
        //#endregion
    }
}