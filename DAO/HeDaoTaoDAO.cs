using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO
{
    public class HeDaoTaoDAO
    {
        #region GetAll

        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<HeDaoTao> GetAll()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                List<HeDaoTao> listHDT = context.HeDaoTaos.ToList();
                return listHDT;
            }
        }

        #endregion GetAll

        public HeDaoTao GetById(string id)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                HeDaoTao hdt = context.HeDaoTaos.Find(id);
                return hdt;
            }
        }

        public void Create(HeDaoTao hdt)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.HeDaoTaos.Add(hdt);
                context.SaveChanges();
            }
        }

        public void Edit(HeDaoTao hdt)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.HeDaoTaos.Where(x => x.MaHDT == hdt.MaHDT).FirstOrDefault();
                context.Entry(query).CurrentValues.SetValues(hdt);
                context.SaveChanges();
            }
        }

        public void Delete(string maHDT)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                HeDaoTao hdt = context.HeDaoTaos.Find(maHDT);
                context.HeDaoTaos.Remove(hdt);
                context.SaveChanges();
            }
        }
    }
}