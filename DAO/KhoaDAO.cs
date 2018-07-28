using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhoaDAO
    {
        #region GetAll
        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<Khoa> GetAll()
        {
            using(var context = new QuanLyDaoTaoEntities())
            {
                List<Khoa> listKhoa = context.Khoas.ToList();
                return listKhoa;
            }
        }
        #endregion

        #region GetById
        /// <summary>
        /// Lấy 1 record dựa vào ma khoa
        /// </summary>
        /// <param name="maKhoa"></param>
        /// <returns>Khoa</returns>
        public Khoa GetById(string maKhoa)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                Khoa khoa = context.Khoas.Where(x=> x.MaKhoa == maKhoa).FirstOrDefault();
                return khoa;
            }
        }
        #endregion

        #region Create
        /// <summary>
        /// Tạo mới 1 record
        /// </summary>
        /// <param name="khoa">khoa</param>
        public void Create(Khoa khoa)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.Khoas.Add(khoa);
                context.SaveChanges(); 
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// Chỉnh sửa 1 record
        /// </summary>
        /// <param name="khoa"></param>
        public void Edit(Khoa khoa)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.Khoas.Where(x => x.MaKhoa == khoa.MaKhoa).FirstOrDefault();
                context.Entry(query).CurrentValues.SetValues(khoa);
                context.SaveChanges();
            }
        }
        #endregion

        #region Delete
        /// <summary>
        ///  Xoa 1 record dựa vào mã khoa
        /// </summary>
        /// <param name="maKhoa"></param>
        public void Delete(string maKhoa)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                Khoa kh = context.Khoas.Find(maKhoa);
                if (kh != null)
                {                              
                    context.Khoas.Remove(kh);                       
                    context.SaveChanges();
                }
            }
        }
        #endregion
    }
}
