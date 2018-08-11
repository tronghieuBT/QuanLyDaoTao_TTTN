using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NienKhoaHocKyDAO
    {

        #region GetAll
        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<NienKhoaHocKy> GetAll()
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                List<NienKhoaHocKy> listNK = context.NienKhoaHocKies.ToList();
                return listNK;
            }
        }
        #endregion

        #region GetById
        /// <summary>
        /// Lấy 1 record dựa vào ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>NienKhoaHocKy</returns>
        public NienKhoaHocKy GetById(string ID)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                NienKhoaHocKy nk = context.NienKhoaHocKies.Where(x => x.ID == ID).FirstOrDefault();
                return nk;
            }
        }
        #endregion

        #region Create
        /// <summary>
        /// Tạo mới 1 record
        /// </summary>
        /// <param name="nienKhoaHocKy">Niên khóa học kỳ</param>
        public void Create(NienKhoaHocKy nienKhoaHocKy)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                context.NienKhoaHocKies.Add(nienKhoaHocKy);
                context.SaveChanges();
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// Chỉnh sửa 1 record
        /// </summary>
        /// <param name="nienKhoaHocKy"></param>
        public void Edit(NienKhoaHocKy nienKhoaHocKy)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                var query = context.NienKhoaHocKies.Where(x => x.ID == nienKhoaHocKy.ID).FirstOrDefault();
                context.Entry(query).CurrentValues.SetValues(nienKhoaHocKy);
                context.SaveChanges();
            }
        }
        #endregion

        #region Delete
        /// <summary>
        ///  Xoa 1 record dựa vào ID
        /// </summary>
        /// <param name="ID"></param>
        public void Delete(string ID)
        {
            using (var context = new QuanLyDaoTaoEntities())
            {
                NienKhoaHocKy nkhk = context.NienKhoaHocKies.Find(ID);
                if (nkhk != null)
                {
                    context.NienKhoaHocKies.Remove(nkhk);
                    context.SaveChanges();
                }
            }
        }
        #endregion
    }
}
