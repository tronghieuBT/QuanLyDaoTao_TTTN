using BLL;
using DAO;
using System;

namespace QuanLyDaoTao_TTTN.Models
{
    public class LopTinChiModel
    {
        public int MaLopTC { get; set; }

        public short HocKy { get; set; }

        public short Nhom { get; set; }

        public string NienKhoa { get; set; }

        public string MaMonHoc { get; set; }

        public string MaGV { get; set; }

        public Nullable<bool> TrangThai { get; set; }

        public MonHocModel MonHoc { get; set; }

        public GiangVienModel GiangVienModel { get; set; }
      
        public string TenGiangVien
        {
            get
            {
                return this.GiangVienModel.HoVaTenLot + " " + this.GiangVienModel.TenGV;
            }
        }

        public int TongSoTinChi
        {
            get
            {
                return this.MonHoc.SoTinChiLyThuyet + this.MonHoc.SoTinChiThucHanh;
            }
        }

    }
}