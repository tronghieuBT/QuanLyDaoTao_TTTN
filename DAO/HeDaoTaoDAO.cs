using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion
    }
}
