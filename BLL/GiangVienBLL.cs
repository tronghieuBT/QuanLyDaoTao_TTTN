using DAO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class GiangVienBLL
    {
        private GiangVienDAO contextGV = new GiangVienDAO();

        public GiangVien GetById(string maGV)
        {
            if (string.IsNullOrEmpty(maGV))
            {
                return null;
            }
            try
            {
                GiangVien gv = contextGV.GetById(maGV);
                return gv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public List<GiangVien> GetAll()
        {
            GiangVienDAO context = new GiangVienDAO();
            try
            {
                List<GiangVien> lstLop = contextGV.GetAll();
                return lstLop;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public int Create(GiangVien giangVien)
        {
            if (giangVien == null)
            {
                return -1;
            }
            try
            {
                GiangVien gv = contextGV.GetById(giangVien.MaGV);
                if (gv != null)
                {
                    return 0;
                }
                contextGV.Create(giangVien);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 2;
            }
        }

        public void Edit(GiangVien giangVien)
        {
            if (giangVien == null)
            {
                return;
            }
            try
            {
                contextGV.Edit(giangVien);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool Delete(string maGV)
        {
            if (string.IsNullOrEmpty(maGV))
            {
                return false;
            }
            try
            {
                GiangVien gv = contextGV.GetById(maGV);
                if (gv != null)
                {
                    contextGV.Delete(maGV);
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