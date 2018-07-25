using DAO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class HeDaoTaoBLL
    {
        private HeDaoTaoDAO contextHdt = new HeDaoTaoDAO();

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

        #endregion GetAll

        public HeDaoTao GetById(string id)
        {
            HeDaoTaoDAO context = new HeDaoTaoDAO();
            try
            {
                HeDaoTao hdt = contextHdt.GetById(id);
                return hdt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public int Create(HeDaoTao hdt)
        {
            if (hdt == null)
            {
                return -1;
            }
            try
            {
                HeDaoTao gv = contextHdt.GetById(hdt.MaHDT);
                if (gv != null)
                {
                    return 0;
                }
                contextHdt.Create(hdt);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 2;
            }
        }

        public void Edit(HeDaoTao hdt)
        {
            if (hdt == null)
            {
                return;
            }
            try
            {
                contextHdt.Edit(hdt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool Delete(string maHdt)
        {
            if (string.IsNullOrEmpty(maHdt))
            {
                return false;
            }
            try
            {
                HeDaoTao gv = contextHdt.GetById(maHdt);
                if (gv != null)
                {
                    contextHdt.Delete(maHdt);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}