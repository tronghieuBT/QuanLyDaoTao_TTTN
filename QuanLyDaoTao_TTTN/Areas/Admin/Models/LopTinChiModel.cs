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
        public int MaLopTC { get; set; }      

        public short Nhom { get; set; }

        public string NienKhoa { get; set; }

        public string MaMonHoc { get; set; }

        public string MaGV { get; set; }

        public Nullable<bool> TrangThai { get; set; }

        public MonHocModel MonHoc { get; set; } 
        public GiangVienModel GiangVien { get; set; }

        public int GetMaNhom(string maMonHoc, string idNienKhoa, string maGiangVien, int hocKy)
        {
            LopTinChiBLL contectLopTC = new LopTinChiBLL();
            NienKhoaHocKyBLL contextNKHK = new NienKhoaHocKyBLL();
            List<LopTinChi> lstLopTinChiTrung = new List<LopTinChi>();

            List<LopTinChi> lstLopTinChi = contectLopTC.GetAll(); 
            
            int dem = 1;
            foreach(LopTinChi ltc in lstLopTinChi)
            {
                if(ltc.MaGV.Equals(maGiangVien) && ltc.NienKhoa.Equals(idNienKhoa) && ltc.MaMonHoc.Equals(maMonHoc))
                {
                    lstLopTinChiTrung.Add(ltc);
                }
            }

            if(lstLopTinChiTrung.Count > 0)
            {
                foreach(LopTinChi ltc in lstLopTinChiTrung)
                {
                    NienKhoaHocKy nkhk = contextNKHK.GetById(ltc.NienKhoa);
                    if (nkhk.HocKy == hocKy)
                    {
                        dem++;
                    }
                }
            }
            return dem;
        }
    }
}