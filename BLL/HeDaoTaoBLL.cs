using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HeDaoTaoBLL
    {
        #region GetAll
        /// <summary>
        /// Lấy tất cả record
        /// </summary>
        /// <returns>List</returns>
        public List<HeDaoTao> GetAll()
        {
            HeDaoTaoDAO context = new HeDaoTaoDAO();
            try
            {
                List<HeDaoTao> lstHDT = context.GetAll();
                return lstHDT;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion
    }
}
