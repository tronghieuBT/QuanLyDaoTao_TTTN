using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SinhVienBLL
    {
        public const string MailSinhVien = "student.ptithcm.edu.vn";
        private SinhVienDAO context = new SinhVienDAO();

        #region  GetLoginSinhVien
        /// <summary>
        /// Get login SinhVien
        /// </summary>
        /// <param name="maSV"></param>
        /// <returns>NULL : false</returns>
        /// <return>#NULL : true</return>
        public SinhVien GetLoginSinhVien(string email, string pass)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                return null;
            }
            try
            {
                SinhVien sv = context.GetLoginSinhVien(email, pass);
                return sv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        #endregion

        #region GetByMaLop
        /// <summary>
        /// Lấy danh sach lop theo khoa
        /// </summary>
        /// <param name="maLop"></param>
        /// <returns>List<SinhVien></returns>
        public List<SinhVien> GetByMaLop(string maLop)
        {
            List<SinhVien> lstSV = new List<SinhVien>();
            try
            {
                lstSV = context.GetByMaLop(maLop);
                return lstSV;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region GetAll
        public List<SinhVien> GetAll()
        {
            List<SinhVien> lstSV = new List<SinhVien>();
            try
            {
                lstSV = context.GetAll();
                return lstSV;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion  

        #region GetById
        public SinhVien GetById(string maSV)
        {
            try
            {
                SinhVien sv = context.GetById(maSV);
                return sv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        #endregion

        #region Create
        public void Create(SinhVien sv)
        {
            try
            {
                sv.MaSV = CreateMaSV(sv.MaLop);
                sv.Email = CreateEmail(sv.MaSV);
                context.Create(sv);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region Edit
        public void Edit(SinhVien sv)
        {
            try
            {
                context.Edit(sv);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        #region Delete
        public void Delete(string id)
        {
            try
            {
                context.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion


        public string CreateMaSV(string maLop)
        {
            SinhVienBLL contextSV = new SinhVienBLL();
            LopBLL contextL = new LopBLL();
            HeDaoTaoBLL contextHDT = new HeDaoTaoBLL();
            try
            {
                Lop Lop = contextL.GetById(maLop);
                if (Lop != null)
                {
                    string stt = "";
                    int dem = contextSV.GetByMaLop(maLop).Count;
                    if (dem >= 100)
                    {
                        stt = dem.ToString().Trim();
                    }
                    else if (dem < 100 && dem >= 10)
                    {
                        stt = "0" + dem.ToString().Trim();
                    }
                    else
                    {
                        stt = "00" + dem.ToString().Trim();
                    }
                    string ma = "N" + Lop.NienKhoa.Substring(2, 2) + Lop.MaHDT.Substring(0, 1) + Lop.MaHDT.Substring(2, 1) + Lop.MaKhoa.Substring(0, 2) + stt;
                    return ma;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public string CreateEmail(string maSV)
        {
            return ( maSV + "@" + MailSinhVien);
        }
    }
}
