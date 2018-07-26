using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDaoTao_TTTN.Models
{
    public class SupportThoiKhoaBieu
    {
        public List<ThoiKhoaBieu> listTKB { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}