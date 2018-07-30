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
                if (item.TrangThai == true)
                {
                    SupportThoiKhoaBieu spTKB = new SupportThoiKhoaBieu();
                    spTKB.listTKB = contextTKB.GetByMaLopTC(item.MaLopTC).Select(s => new ThoiKhoaBieuModel
                    {
                        Ngay = s.Ngay,
                        Buoi = s.Buoi,
                        MaLopTC = s.MaLopTC,
                        TietBD = s.TietBD
                    }).ToList();
                    //duyệt danh sách thời khóa biểu của lớp tín chỉ đăng ký xem đã hoàn thành chưa
                    foreach (var tkb in spTKB.listTKB)
                    {
                        if (lstSPTKB.Count > 0)
                        {
                            int count = lstSPTKB.Count;
                            for (int i = 0; i < count; i++)
                            {
                                var itemSPTKB = lstSPTKB[i];
                                if (itemSPTKB.MonHoc.MaMH == item.MaMonHoc)
                                {
                                    if (tkb.Ngay.DayOfYear >= dtStart.DayOfYear && tkb.Ngay.DayOfYear <= dtEnd.DayOfYear)
                                    {
                                        ThoiKhoaBieuModel tkbModel = new ThoiKhoaBieuModel
                                        {
                                            Buoi = tkb.Buoi,
                                            MaLopTC = tkb.MaLopTC,
                                            Ngay = tkb.Ngay,
                                            TietBD = tkb.TietBD
                                        };
                                        itemSPTKB.listTKB.Add(tkbModel);
                                    }
                                }
                                else
                                {
                                    SupportThoiKhoaBieu sptkb = new SupportThoiKhoaBieu();
                                    sptkb.listTKB = new List<ThoiKhoaBieuModel>();
                                    MonHoc mh = contextMH.GetById(item.MaMonHoc);
                                    sptkb.MonHoc = new MonHocModel
                                    {
                                        MaMH = mh.MaMH,
                                        SoTinChiLyThuyet = mh.SoTinChiLyThuyet,
                                        SoTinChiThucHanh = mh.SoTinChiThucHanh,
                                        TenMH = mh.TenMH
                                    };
                                    ThoiKhoaBieuModel tkbModel = new ThoiKhoaBieuModel
                                    {
                                        Buoi = tkb.Buoi,
                                        MaLopTC = tkb.MaLopTC,
                                        Ngay = tkb.Ngay,
                                        TietBD = tkb.TietBD
                                    };
                                    sptkb.listTKB.Add(tkbModel);
                                    lstSPTKB.Add(sptkb);
                                }
                            }
                        }
                        else
                        {
                            if (tkb.Ngay.DayOfYear >= dtStart.DayOfYear && tkb.Ngay.DayOfYear <= dtEnd.DayOfYear)
                            {
                                SupportThoiKhoaBieu sptkb = new SupportThoiKhoaBieu();
                                sptkb.listTKB = new List<ThoiKhoaBieuModel>();
                                MonHoc mh = contextMH.GetById(item.MaMonHoc);
                                sptkb.MonHoc = new MonHocModel
                                {
                                    MaMH = mh.MaMH,
                                    SoTinChiLyThuyet = mh.SoTinChiLyThuyet,
                                    SoTinChiThucHanh = mh.SoTinChiThucHanh,
                                    TenMH = mh.TenMH
                                };
                                ThoiKhoaBieuModel tkbModel = new ThoiKhoaBieuModel
                                {
                                    Buoi = tkb.Buoi,
                                    MaLopTC = tkb.MaLopTC,
                                    Ngay = tkb.Ngay,
                                    TietBD = tkb.TietBD
                                };
                                sptkb.listTKB.Add(tkbModel);
                                lstSPTKB.Add(sptkb);
                            }
                        }
                    }
                }
            }
            return lstSPTKB;
        }
    }
}