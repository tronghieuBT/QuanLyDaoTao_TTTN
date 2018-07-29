using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Models
{
    public class MonHocModel
    {

        public string MaMH { get; set; }

        public string TenMH { get; set; }

        public short SoTinChiLyThuyet { get; set; }

        public short SoTinChiThucHanh { get; set; }

        public int TongSoTinChi {
            get
            {
                return this.SoTinChiLyThuyet + this.SoTinChiThucHanh;
            }
        }
    }
}