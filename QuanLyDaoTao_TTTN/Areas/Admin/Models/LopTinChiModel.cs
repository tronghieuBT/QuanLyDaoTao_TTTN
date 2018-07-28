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
            LopTinChiBLL contectLopTC = new LopTinChiBLL();
            List<LopTinChi> lstLopTinChi = contectLopTC.GetAll();
            int dem = 1;
            List<LopTinChi> lstLopTinChiTrung = new List<LopTinChi>();
            foreach(LopTinChi ltc in lstLopTinChi)
            {
                if(ltc.MaGV == maGiangVien && ltc.NienKhoa == nienKhoa && ltc.MaMonHoc == maMonHoc)
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