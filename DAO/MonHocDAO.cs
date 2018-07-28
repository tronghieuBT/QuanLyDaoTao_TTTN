using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO
{
    public class MonHocDAO
    {
        #region GetAll

        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<MonHoc> GetAll()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var monHocs = context.MonHocs.ToList();
                return monHocs;
            }
        }

        #endregion GetAll

        #region GetById

        /// <summary>
        /// Lấy 1 record dựa vào ma lop
        /// </summary>
        /// <param name="maMH"></param>
        /// <returns>Khoa</returns>
        public MonHoc GetById(string maMonHoc)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                MonHoc mh = context.MonHocs.Where(x => x.MaMH == maMonHoc).FirstOrDefault();
                return mh;
            }
        }

        #endregion GetById

        #region Create

        /// <summary>
        /// Tạo mới 1 record
        /// </summary>
        /// <param name="mh">môn học</param>
        public void Create(MonHoc mh)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.MonHocs.Add(mh);
                context.SaveChanges();
            }
        }

        #endregion Create

        #region Edit

        /// <summary>
        /// Chỉnh sửa 1 record
        /// </summary>
        /// <param name="mh">Môn học</param>
        public void Edit(MonHoc mh)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.MonHocs.Where(x => x.MaMH == mh.MaMH).FirstOrDefault();
                context.Entry(query).CurrentValues.SetValues(mh);
                context.SaveChanges();
               
            }
        }

        #endregion Edit

        #region Delete

        /// <summary>
        ///  Xoa 1 record dựa vào mã lop
        /// </summary>
        /// <param name="maMH">Mã môn học</param>
        public void Delete(string maMH)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                MonHoc mh = context.MonHocs.Find(maMH);
                if (mh != null)
                {
                    context.MonHocs.Remove(mh);
                    context.SaveChanges();
                }
            }
        }

        #endregion Delete

    }
}