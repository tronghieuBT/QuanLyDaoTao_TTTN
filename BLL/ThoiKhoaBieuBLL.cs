using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThoiKhoaBieuBLL
    {
        #region GetAll
        /// <summary>
        /// Lay tat ca record
        /// </summary>
        /// <returns>List</returns>
        public List<ThoiKhoaBieu> GetAll()
        {
            ThoiKhoaBieuDAO context = new ThoiKhoaBieuDAO();
            try
            {
                List<ThoiKhoaBieu> lstTKB = context.GetAll();
                return lstTKB;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region GetByMaLopTC
        /// <summary>
        /// Lấy record theo maLopTC 
        /// </summary>
        /// <returns>List</returns>
        public List<ThoiKhoaBieu> GetByMaLopTC(int maLopTC)
        {
            ThoiKhoaBieuDAO context = new ThoiKhoaBieuDAO();
            try
            {
                List<ThoiKhoaBieu> lstTKB = context.GetByMaLopTC(maLopTC);
                return lstTKB;
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
