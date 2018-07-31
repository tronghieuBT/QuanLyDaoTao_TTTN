using BLL;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Models
{
    public class GiangVienModel
    {
        public string MaGV { get; set; }

        public string HoVaTenLot { get; set; }

        public string TenGV { get; set; }

        public System.DateTime NgaySinh { get; set; }

        public string GioiTinh { get; set; }

        public string TrinhDo { get; set; }

        public string SDT { get; set; }

        public string Email { get; set; }

        public string MaKhoa { get; set; }

        public string MatKhau { get; set; }

        public string TenDayDu
        {
            get
            {
                return HoVaTenLot + " " + TenGV;
            }
        }

        public List<GiangVienModel> GetALL()
        {
            GiangVienBLL contextGV = new GiangVienBLL();
            List<GiangVienModel> lstGV = contextGV.GetAll().Select(x => new GiangVienModel
            {
                MaGV = x.MaGV,
                HoVaTenLot = x.HoVaTenLot,
                TenGV = x.TenGV,
                GioiTinh = x.GioiTinh,
                Email = x.Email,
                MatKhau = x.MatKhau,
                NgaySinh = x.NgaySinh,
                SDT = x.SDT,
                TrinhDo = x.TrinhDo,
                MaKhoa = x.MaKhoa
            }).ToList();
            return lstGV;
        }
    }
}