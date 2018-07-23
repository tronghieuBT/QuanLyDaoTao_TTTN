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
        /// <summary>
        /// Chỉnh sửa 1 record
        /// </summary>
        /// <param name="khoa"></param>
        public void Edit(Khoa khoa)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                Khoa kh =  context.Khoas.Find(khoa.MaKhoa);
                if(kh != null)
                {
                    kh.TenKhoa = khoa.TenKhoa;
                    context.Khoas.Attach(kh);
                    context.Entry(kh).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
    }
}
