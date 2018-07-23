using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhoaBLL
    {
        /// <summary>
        /// Lay tat ca record
        /// </summary>
        /// <returns>List</returns>
        public List<Khoa> GetAll()
        {
            KhoaDAO context = new KhoaDAO();
            try
            {        
                List<Khoa> lstKhoa = context.GetAll();
                return lstKhoa;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
         /// <summary>
         /// Lay 1 record dua vao ma khoa
         /// </summary>
         /// <param name="maKhoa"></param>
         /// <returns>Khoa</returns>
        public Khoa GetById(string maKhoa)
        {
            if(maKhoa == "" || maKhoa == null)
            {
                return null;
            }
            KhoaDAO context = new KhoaDAO();
            try
            {
                Khoa khoa = context.GetById(maKhoa);
                return khoa;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        /// <summary>
        /// Tao moi 1 record
        /// </summary>
        /// <param name="khoa"></param>
        /// <returns>true , false</returns>
        public bool Create(Khoa khoa)
        {
            if(khoa == null)
            {
                return false;
            }
            KhoaDAO context = new KhoaDAO();
            try
            {
                context.Create(khoa);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }          
        }
        /// <summary>
        /// Chỉnh sửa khoa
        /// </summary>
        /// <param name="khoa"></param>
        /// <returns>true, false</returns>
        public bool Edit(Khoa khoa)
        {
            if (khoa == null)
            {
                return false;
            }
            KhoaDAO context = new KhoaDAO();
            try
            {
                context.Edit(khoa);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }    
    }
}
