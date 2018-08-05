using DAO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class DangKy_VBLL
    {
        private DangKy_VDAO context = new DangKy_VDAO();

        #region GetByMaLopTC

        public List<DangKy_V> GetByMaLopTC(int maLopTC)
        {
            try
            {
                List<DangKy_V> dk = context.GetByMaLop(maLopTC);
                return dk;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        #endregion GetByMaLopTC
    }
}