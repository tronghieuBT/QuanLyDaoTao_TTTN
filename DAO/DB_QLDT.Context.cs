﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QuanLyDaoTaoEntities : DbContext
    {
        public QuanLyDaoTaoEntities()
            : base("name=QuanLyDaoTaoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DiemDanh> DiemDanhs { get; set; }
        public virtual DbSet<DongHocPhi> DongHocPhis { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<GiaTinChi> GiaTinChis { get; set; }
        public virtual DbSet<HeDaoTao> HeDaoTaos { get; set; }
        public virtual DbSet<HocPhiTheoDangKy> HocPhiTheoDangKies { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<LopTinChi> LopTinChis { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<NienKhoaHocKy> NienKhoaHocKies { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<ThoiKhoaBieu> ThoiKhoaBieux { get; set; }
        public virtual DbSet<DangKy_V> DangKy_V { get; set; }
    
        public virtual int Insert_DangKy(string maSV, Nullable<int> maLopTC)
        {
            var maSVParameter = maSV != null ?
                new ObjectParameter("MaSV", maSV) :
                new ObjectParameter("MaSV", typeof(string));
    
            var maLopTCParameter = maLopTC.HasValue ?
                new ObjectParameter("MaLopTC", maLopTC) :
                new ObjectParameter("MaLopTC", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_DangKy", maSVParameter, maLopTCParameter);
        }
    }
}
