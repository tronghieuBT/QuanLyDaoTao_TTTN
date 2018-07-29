using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDaoTao_TTTN.Areas.Admin.Models
{
    public class ThoiKhoaBieuModel
    {
        public System.DateTime Ngay { get; set; }
        public string Buoi { get; set; }
        public short TietBD { get; set; }
        public int MaLopTC { get; set; }

        public string NgayString
        {
            get
            {
                return Ngay.ToString("yyyy-MM-dd");
            }
        }
    }
}