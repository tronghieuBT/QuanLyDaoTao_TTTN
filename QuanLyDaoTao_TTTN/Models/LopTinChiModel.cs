using BLL;
using DAO;
using System;
using System.Collections.Generic;

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
        public int Tong
        {
            get
            {
                return 50;
            }
        }

        public int ConLai
        {
            get
            {
                DangKy_VBLL context = new DangKy_VBLL();
                List<DangKy_V> lstDK = context.GetByMaLopTC(this.MaLopTC);
                return 50-lstDK.Count;
            }
        }
    }
}