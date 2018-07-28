using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace QuanLyDaoTao_TTTN.Models
{
    public class SupportThoiKhoaBieu
    {
        public List<ThoiKhoaBieuModel> listTKB { get; set; }
        public MonHocModel MonHoc { get; set; }

        public List<SupportThoiKhoaBieu> GetListSPTKB(string tuan, ICollection<LopTinChi> lopTCs)
        {
            List<SupportThoiKhoaBieu> lstSPTKB = new List<SupportThoiKhoaBieu>();
            ThoiKhoaBieuBLL contextTKB = new ThoiKhoaBieuBLL();
            DateTime dtStart = DateTime.Parse(tuan.Split('-')[1].ToString().Trim(), new CultureInfo("en-US"));
            DateTime dtEnd = DateTime.Parse(tuan.Split('-')[3].ToString().Trim(), new CultureInfo("en-US"));
            MonHocBLL contextMH = new MonHocBLL();
            foreach (var item in lopTCs)
            {
                SupportThoiKhoaBieu spTKB = new SupportThoiKhoaBieu();
                spTKB.listTKB = contextTKB.GetByMaLopTC(item.MaLopTC).Select(s=> new ThoiKhoaBieuModel {
                Ngay = s.Ngay,
                Buoi = s.Buoi,
                MaLopTC = s.MaLopTC,
                TietBD = s.TietBD
                }).ToList();
                //duyệt danh sách thời khóa biểu của lớp tín chỉ đăng ký xem đã hoàn thành chưa
                foreach (var tkb in spTKB.listTKB)
                {
                    if (tkb.Ngay.DayOfYear >= dtStart.DayOfYear && tkb.Ngay.DayOfYear <= dtEnd.DayOfYear)
                    {
                        var moHoc = contextMH.GetById(item.MaMonHoc);
                        spTKB.MonHoc = new MonHocModel
                        {
                            MaMH = moHoc.MaMH,
                            SoTinChiLyThuyet = moHoc.SoTinChiLyThuyet,
                            SoTinChiThucHanh = moHoc.SoTinChiThucHanh,
                            TenMH = moHoc.TenMH
                        };
                        lstSPTKB.Add(spTKB);
                    }
                }
            }
            return lstSPTKB;
        }
    }
}