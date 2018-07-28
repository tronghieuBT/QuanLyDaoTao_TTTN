using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Models
{
    public class LopTinChiModel
    {

        public int GetMaNhom(string maMonHoc, string nienKhoa, string maGiangVien, int hocKy)
        {
            int nkTest = Int32.Parse(nienKhoa) +1;
            string nienKhoaNew = nienKhoa + "-" + nkTest.ToString().Trim();
            LopTinChiBLL contectLopTC = new LopTinChiBLL();
            List<LopTinChi> lstLopTinChi = contectLopTC.GetAll();
            int dem = 1;
            List<LopTinChi> lstLopTinChiTrung = new List<LopTinChi>();
            foreach(LopTinChi ltc in lstLopTinChi)
            {
                if(ltc.MaGV.Equals(maGiangVien) && ltc.NienKhoa.Equals(nienKhoaNew) && ltc.MaMonHoc.Equals(maMonHoc))
                {
                    lstLopTinChiTrung.Add(ltc);
                }
            }

            if(lstLopTinChiTrung.Count > 0)
            {
                foreach(LopTinChi ltc in lstLopTinChiTrung)
                {
                    if(ltc.HocKy == hocKy)
                    {
                        dem++;
                    }
                }
            }
            return dem;
        }
    }
}