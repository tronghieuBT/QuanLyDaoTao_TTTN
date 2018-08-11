using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LopBLL
    {
        private const int SONAMDAOTAODH = 5;
        private const int SONAMDAOTAOCD = 3;

        #region GetByMaKhoa
        /// <summary>
        /// Lấy danh sach lop theo khoa
        /// </summary>
        /// <param name="maKhoa"></param>
        /// <returns>List<Lop></LOP></returns>
        public List<Lop> GetByMaKhoa(string maKhoa)
        {
            LopDAO lp = new LopDAO();
            List<Lop> lstLop = new List<Lop>();
            try
            {
                lstLop = lp.GetByMaKhoa(maKhoa);
                return lstLop;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Lay tat ca record
        /// </summary>
        /// <returns>List lop</returns>
        public List<Lop> GetAll()
        {
            LopDAO context = new LopDAO();
            try
            {
                List<Lop> lstLop = context.GetAll();
                return lstLop;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region  GetById
        /// <summary>
        /// Lay 1 record dua vao ma lop
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>Lop</returns>
        public Lop GetById(string maLop)
        {
            if (maLop == "" || maLop == null)
            {
                return null;
            }
            LopDAO context = new LopDAO();
            try
            {
                Lop lp = context.GetById(maLop);
                return lp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region   Create
        /// <summary>
        /// Tao moi 1 record
        /// </summary>
        /// <param name="lop"></param>
        /// <returns>-1 : Input rỗng</returns>
        /// <returns> 0 : Trùng</returns>
        /// <returns> 1 : Thành công</returns> 
        /// <returns>2 : Exception</returns>
        public int Create(Lop lop)
        {
            if (lop == null)
            {
                return -1;
            }
            LopDAO context = new LopDAO();
            
            try
            {     
                LopBLL contextL = new LopBLL();
                lop.MaLop = contextL.CreateMaLop(lop.MaKhoa, lop.NienKhoa, lop.MaHDT);
                context.Create(lop);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 2;
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// Chỉnh sửa khoa
        /// </summary>
        /// <param name="lop"></param>
        /// <returns>true, false</returns>
        public bool Edit(Lop lop)
        {
            if (lop == null)
            {
                return false;
            }
            LopDAO context = new LopDAO();
            try
            {
                context.Edit(lop);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Xoa khoa theo ma khoa
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>true, false</returns>
        public bool Delete(string maLop)
        {
            if (string.IsNullOrEmpty(maLop))
            {
                return false;
            }
            LopDAO context = new LopDAO();
            Lop lp = new Lop();
            try
            {
                lp = context.GetById(maLop);
                if (lp != null)
                {
                    SinhVienBLL svContext = new SinhVienBLL();
                    List<SinhVien> lstSV = svContext.GetByMaLop(maLop);
                    if (lstSV.Count == 0)
                    {
                        context.Delete(maLop);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        #endregion

        #region  CreateMaLop
        /// <summary>
        ///  Tạo mã lớp tự động
        /// </summary>
        /// <param name="maKhoa">Mã khoa</param>
        /// <param name="nienKhoa">Niên khóa</param>
        /// <param name="maHDT">Mã hệ đào tạo</param>
        /// <returns></returns>
        public string CreateMaLop(string maKhoa, string nienKhoa, string maHDT)
        {
            LopDAO lp = new LopDAO();
            string maLop = "";
            try
            {
                List<Lop> lstLop = lp.GetByMaKhoaAndNienKhoaHDT(maKhoa,nienKhoa,maHDT);
                if(lstLop == null)
                {
                    maLop = maHDT.Substring(0,1) + nienKhoa.Substring(2, 2) + maHDT.Substring(2, 2) + maKhoa.Substring(0, 2)+"01";
                    return maLop.Trim() ;
                }
                int dem = lstLop.Count + 1;
                maLop = maHDT.Substring(0, 1) + nienKhoa.Substring(2, 2) + maHDT.Substring(2, 2) + maKhoa.Substring(0, 2) +"0"+ dem.ToString();
                return maLop.Trim();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion
    }
}
