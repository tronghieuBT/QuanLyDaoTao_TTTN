using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO
{
    public class GiangVienDAO
    {
        /// <summary>
        /// get login GiangVien
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns>NULL : false</returns>
        /// <return>#NULL : true</return>
        public static GiangVien GetLoginGiangVien(string email, string pass)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.GiangViens.Where(x => x.Email == email && x.MatKhau == pass).FirstOrDefault();
                return query;
            }
        }

        public GiangVien GetById(string maGV)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.GiangViens.Where(x => x.MaGV == maGV).FirstOrDefault();
                return query;
            }
        }

        public List<GiangVien> GetAll()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.GiangViens.Include(g => g.Khoa).ToList();
                return query;
            }
        }

        public void Create(GiangVien giangVien)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.GiangViens.Add(giangVien);
                context.SaveChanges();
            }
        }

        public void Edit(GiangVien giangVien)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.GiangViens.Where(x => x.MaGV == giangVien.MaGV).FirstOrDefault();
                context.Entry(query).CurrentValues.SetValues(giangVien);
                context.SaveChanges();
            }
        }

        public void Delete(string maGV)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                GiangVien giangVien = context.GiangViens.Find(maGV);
                context.GiangViens.Remove(giangVien);
                context.SaveChanges();
            }
        }
    }
}