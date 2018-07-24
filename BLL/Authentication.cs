using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Authentication
    {
        public const string MailSinhVien = "student.ptithcm.edu.vn";
        public const string MailGiangVien = "teacher.ptithcm.edu.vn";

        /// <summary>
        /// Check Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns>NULL : false</returns>
        /// <returns># NULL : true</returns> 
        public string CheckLogin(string email, string pass)
        {
            string hoten = null;
            int flag = CheckMail(email);
            if (flag == 0)
            {
                return null;
            } 
            if(flag == 1)
            {
                SinhVienDAO context = new SinhVienDAO();
                SinhVien sv = context.GetLoginSinhVien(email, pass);
                if(sv == null)
                {
                    return null;
                }
                hoten = "SINHVIEN:" + sv.HoVaTenLot + " " + sv.TenSV;
                return hoten;
            }
            if(flag == 2)
            {
                GiangVien gv = GiangVienDAO.GetLoginGiangVien(email, pass);
                if (gv == null)
                {
                    return null;
                }
                hoten = "GIANGVIEN:" + gv.HoVaTenLot + " " + gv.TenGV;
                return hoten;
            }
            return null;
        }

        /// <summary>
        /// Check mail login   
        /// </summary>
        /// <param name="email"></param>
        /// <returns>1 : Sinh Vien</returns>
        /// <returns>2 : Giao vien</returns>
        /// <returns>0 : mail khong hop le</returns>
        public int CheckMail(string email)
        {
            string[] em = email.Split('@');
            if (em[1].Equals(MailSinhVien))
            {
                return 1;
            }
            if(em[1].Equals(MailGiangVien))
            {
                return 2;
            }
            return 0;
        }
    }
}
