using DAO;
using System.Collections.Generic;

namespace QuanLyDaoTao_TTTN.Models
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

        public virtual Khoa Khoa { get; set; }
        public virtual List<LopTinChi> LopTinChis { get; set; }
    }
}