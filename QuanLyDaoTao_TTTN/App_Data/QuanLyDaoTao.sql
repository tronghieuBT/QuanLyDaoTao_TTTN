USE [QuanLyDaoTao]
GO
/****** Object:  Table [dbo].[DangKy]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangKy](
	[MaSV] [varchar](10) NOT NULL,
	[MaLopTC] [int] NOT NULL,
 CONSTRAINT [PK_DangKy] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC,
	[MaLopTC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[DangKy_V]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DangKy_V] AS SELECT MaSV AS Expr1, dbo.DangKy.*, MaLopTC AS Expr2 FROM dbo.DangKy
GO
/****** Object:  Table [dbo].[DiemDanh]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDanh](
	[MaPhieuDD] [varchar](10) NOT NULL,
	[Ngay] [datetime] NOT NULL,
	[Buoi] [nvarchar](10) NOT NULL,
	[MaSV] [varchar](10) NOT NULL,
	[MaLopTC] [int] NOT NULL,
 CONSTRAINT [PK_DiemDanh] PRIMARY KEY CLUSTERED 
(
	[MaPhieuDD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DongHocPhi]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DongHocPhi](
	[MaSV] [varchar](10) NOT NULL,
	[IDHocPhi] [varchar](10) NOT NULL,
	[Ngay] [datetime] NOT NULL,
	[SoTien] [int] NOT NULL,
	[NienKhoa] [nvarchar](50) NULL,
 CONSTRAINT [PK_DongHocPhi] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC,
	[IDHocPhi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiangVien]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangVien](
	[MaGV] [varchar](10) NOT NULL,
	[HoVaTenLot] [nvarchar](150) NOT NULL,
	[TenGV] [nvarchar](50) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[TrinhDo] [nvarchar](150) NOT NULL,
	[SDT] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[MaKhoa] [varchar](10) NOT NULL,
	[MatKhau] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_GiangVien] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiaTinChi]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaTinChi](
	[MaGiaTC] [varchar](10) NOT NULL,
	[MaHDT] [varchar](10) NOT NULL,
	[Gia] [float] NOT NULL,
	[NgayThayDoi] [datetime] NOT NULL,
	[NienKhoa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GiaTinChi] PRIMARY KEY CLUSTERED 
(
	[MaGiaTC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HeDaoTao]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeDaoTao](
	[MaHDT] [varchar](10) NOT NULL,
	[TenHDT] [nvarchar](150) NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_HeDaoTao] PRIMARY KEY CLUSTERED 
(
	[MaHDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocPhiTheoDangKy]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocPhiTheoDangKy](
	[ID] [varchar](10) NOT NULL,
	[SoTienDong] [float] NOT NULL,
	[SoTinChi] [int] NOT NULL,
	[NienKhoa] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[MaGiaTC] [varchar](10) NOT NULL,
 CONSTRAINT [PK_HocPhiTheoDangKy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[MaKhoa] [varchar](10) NOT NULL,
	[TenKhoa] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lop]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[MaLop] [varchar](10) NOT NULL,
	[TenLop] [nvarchar](250) NOT NULL,
	[NienKhoa] [nvarchar](50) NOT NULL,
	[MaKhoa] [varchar](10) NOT NULL,
	[MaHDT] [varchar](10) NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LopTinChi]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopTinChi](
	[MaLopTC] [int] IDENTITY(1,1) NOT NULL,
	[HocKy] [smallint] NOT NULL,
	[Nhom] [smallint] NOT NULL,
	[NienKhoa] [nvarchar](50) NOT NULL,
	[MaMonHoc] [varchar](10) NOT NULL,
	[MaGV] [varchar](10) NOT NULL,
	[TrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_LopTinChi] PRIMARY KEY CLUSTERED 
(
	[MaLopTC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMH] [varchar](10) NOT NULL,
	[TenMH] [nvarchar](150) NOT NULL,
	[SoTinChiLyThuyet] [smallint] NOT NULL,
	[SoTinChiThucHanh] [smallint] NOT NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSV] [varchar](10) NOT NULL,
	[HoVaTenLot] [nvarchar](150) NOT NULL,
	[TenSV] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[MaLop] [varchar](10) NOT NULL,
	[MatKhau] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThoiKhoaBieu]    Script Date: 8/7/2018 10:56:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThoiKhoaBieu](
	[Ngay] [datetime] NOT NULL,
	[Buoi] [nvarchar](10) NOT NULL,
	[TietBD] [smallint] NOT NULL,
	[MaLopTC] [int] NOT NULL,
 CONSTRAINT [PK_BuoiHoc] PRIMARY KEY CLUSTERED 
(
	[Ngay] ASC,
	[Buoi] ASC,
	[MaLopTC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[DangKy] ([MaSV], [MaLopTC]) VALUES (N'N14DCCN001', 14)
INSERT [dbo].[DangKy] ([MaSV], [MaLopTC]) VALUES (N'N14DCCN001', 16)
INSERT [dbo].[DangKy] ([MaSV], [MaLopTC]) VALUES (N'N14DCCN002', 15)
INSERT [dbo].[DangKy] ([MaSV], [MaLopTC]) VALUES (N'N14DCCN002', 17)
INSERT [dbo].[DangKy] ([MaSV], [MaLopTC]) VALUES (N'N14DCCN002', 18)
INSERT [dbo].[GiangVien] ([MaGV], [HoVaTenLot], [TenGV], [NgaySinh], [GioiTinh], [TrinhDo], [SDT], [Email], [MaKhoa], [MatKhau]) VALUES (N'GV01', N'Lưu Nguyễn Kỳ', N'Thư', CAST(N'1985-01-01T00:00:00.000' AS DateTime), N'nam', N'Thạc sĩ', N'0123456789', N'lnkthu@teacher.ptithcm.edu.vn', N'CNTT', N'1111')
INSERT [dbo].[GiangVien] ([MaGV], [HoVaTenLot], [TenGV], [NgaySinh], [GioiTinh], [TrinhDo], [SDT], [Email], [MaKhoa], [MatKhau]) VALUES (N'GV02', N'Huỳnh Trung', N'Trụ', CAST(N'1985-01-01T00:00:00.000' AS DateTime), N'nam', N'Thạc sĩ', N'0123456789', N'truht@teacher.ptithcm.edu.vn', N'CNTT', N'1111')
INSERT [dbo].[GiangVien] ([MaGV], [HoVaTenLot], [TenGV], [NgaySinh], [GioiTinh], [TrinhDo], [SDT], [Email], [MaKhoa], [MatKhau]) VALUES (N'GV03', N'Nguyễn Văn ', N'Nam', CAST(N'1985-01-01T00:00:00.000' AS DateTime), N'nam', N'Tiến sĩ', N'0123456789', N'NamNV@teacher.ptithcm.edu.vn', N'CNTT', N'1111')
INSERT [dbo].[GiangVien] ([MaGV], [HoVaTenLot], [TenGV], [NgaySinh], [GioiTinh], [TrinhDo], [SDT], [Email], [MaKhoa], [MatKhau]) VALUES (N'GV04', N'Huỳnh Trọng', N'Thưa', CAST(N'1985-01-01T00:00:00.000' AS DateTime), N'Nam', N'Thạc sĩ', N'0123456789', N'thuaht@gmail.com', N'CNTT', N'1111')
INSERT [dbo].[GiangVien] ([MaGV], [HoVaTenLot], [TenGV], [NgaySinh], [GioiTinh], [TrinhDo], [SDT], [Email], [MaKhoa], [MatKhau]) VALUES (N'GV05', N'Nguyễn Thị Kim', N'Lài', CAST(N'1989-01-01T00:00:00.000' AS DateTime), N'Nữ', N'Thạc sĩ', N'0123456987', N'LaiNTK@gmail.com', N'KT        ', N'1111')
INSERT [dbo].[GiaTinChi] ([MaGiaTC], [MaHDT], [Gia], [NgayThayDoi], [NienKhoa]) VALUES (N'DH01', N'DHCQ      ', 395000, CAST(N'2018-07-28T00:00:00.000' AS DateTime), N'2014-2019')
INSERT [dbo].[HeDaoTao] ([MaHDT], [TenHDT], [GhiChu]) VALUES (N'CDCQ      ', N'Cao đẳng chính qui', NULL)
INSERT [dbo].[HeDaoTao] ([MaHDT], [TenHDT], [GhiChu]) VALUES (N'DHCQ      ', N'Đại học chính qui', NULL)
INSERT [dbo].[HeDaoTao] ([MaHDT], [TenHDT], [GhiChu]) VALUES (N'DHLT    ', N'Liên thông đại học', NULL)
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'CNTT', N'Công nghệ thông tin')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'DT', N'Điện tử')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'KT', N'Kinh tế 2')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'VT', N'Viễn thông')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'C14CQCN01 ', N'Công nghệ thông tin', N'2014-2019', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D10CQCN01 ', N'Công nghệ thông tin', N'2010-2015', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D10CQDT01 ', N'đâsdasdsa', N'2010-2015', N'DT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D10CQKT01 ', N'Kế toán', N'2010-2015', N'KT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D10LTKT01 ', N'Kế toán', N'2010-2015', N'KT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D11CQCN01 ', N'sfsfs', N'2011-2016', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D12CQCN01 ', N'Công nghệ thông tin', N'2012-2017', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D12LTCN01 ', N'y', N'2012-2017', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D13CQCN01 ', N'dấda', N'2013-2018', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D13CQKT01 ', N'ss', N'2013-2018', N'KT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D13LTKT01 ', N'Kinh tế', N'2013-2018', N'KT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D14CQCN01 ', N'adsadas', N'2014-2019', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D14CQDT01 ', N'Điện tử', N'2014-2019', N'DT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D14CQIS01 ', N'Hệ thống thông tin', N'2014-2019', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D14CQVT01 ', N'Viễn thông', N'2014-2019', N'VT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D15CQCN01 ', N'eqweqweqw', N'2015-2020', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D15LTCN01 ', N'sdfd', N'2015-2020', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D16CQCN01 ', N'Công nghệ thông tin', N'2016-2021', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D16LTCN01 ', N'sdsf', N'2016-2021', N'CNTT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D17CQDT01 ', N'đasadasd', N'2017-2022', N'DT', NULL)
INSERT [dbo].[Lop] ([MaLop], [TenLop], [NienKhoa], [MaKhoa], [MaHDT]) VALUES (N'D18CQCN2  ', N'Công nghệ thông tin', N'2018-2023', N'CNTT', NULL)
SET IDENTITY_INSERT [dbo].[LopTinChi] ON 

INSERT [dbo].[LopTinChi] ([MaLopTC], [HocKy], [Nhom], [NienKhoa], [MaMonHoc], [MaGV], [TrangThai]) VALUES (14, 1, 1, N'2018-2019', N'CNCPP', N'GV01', 1)
INSERT [dbo].[LopTinChi] ([MaLopTC], [HocKy], [Nhom], [NienKhoa], [MaMonHoc], [MaGV], [TrangThai]) VALUES (15, 2, 1, N'2018-2019', N'CNCTDL', N'GV01', 1)
INSERT [dbo].[LopTinChi] ([MaLopTC], [HocKy], [Nhom], [NienKhoa], [MaMonHoc], [MaGV], [TrangThai]) VALUES (16, 2, 1, N'2019-2020', N'CBTA2', N'GV03', 1)
INSERT [dbo].[LopTinChi] ([MaLopTC], [HocKy], [Nhom], [NienKhoa], [MaMonHoc], [MaGV], [TrangThai]) VALUES (17, 1, 1, N'2019-2020', N'CNLTHDT', N'GV04', 1)
INSERT [dbo].[LopTinChi] ([MaLopTC], [HocKy], [Nhom], [NienKhoa], [MaMonHoc], [MaGV], [TrangThai]) VALUES (18, 1, 1, N'2018-2019', N'CNCTDL', N'GV01', 1)
SET IDENTITY_INSERT [dbo].[LopTinChi] OFF
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'CBGT1', N'Giải tích 1', 3, 0)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'CBTA1', N'Tiếng anh 1', 7, 0)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'CBTA2', N'Tiếng anh  2', 7, 0)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'CNCPP', N'Ngôn ngữ lập trình c++', 2, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'CNCTDL', N'Cấu trúc dữ liệu và giải thuật', 2, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'CNLTHDT', N'Lập trình hướng đối tượng', 2, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'CNPT', N'Cơ sở dữ liệu phân tán', 2, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'CNTRR1', N'Toán rời rạc 1', 3, 0)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'CNTRR2', N'Toán rời rạc 2', 3, 0)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'CNTTNT', N'Trí tuệ nhân tạo', 3, 0)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTinChiLyThuyet], [SoTinChiThucHanh]) VALUES (N'VTXLTTS', N'Xử lý tín hiệu số', 2, 1)
INSERT [dbo].[SinhVien] ([MaSV], [HoVaTenLot], [TenSV], [GioiTinh], [NgaySinh], [Email], [MaLop], [MatKhau]) VALUES (N'N14DCCN001', N'Huỳnh Thanh', N'Trúc', N'Nữ', CAST(N'1996-09-04T00:00:00.000' AS DateTime), N'N14DCCN001@student.ptithcm.edu.vn', N'D14CQIS01 ', N'1111')
INSERT [dbo].[SinhVien] ([MaSV], [HoVaTenLot], [TenSV], [GioiTinh], [NgaySinh], [Email], [MaLop], [MatKhau]) VALUES (N'N14DCCN002', N'Bùi Trọng', N'Hiếu', N'Nam', CAST(N'1996-03-20T00:00:00.000' AS DateTime), N'N14DCCN002@student.ptithcm.edu.vn', N'D14CQIS01 ', N'1111')
INSERT [dbo].[SinhVien] ([MaSV], [HoVaTenLot], [TenSV], [GioiTinh], [NgaySinh], [Email], [MaLop], [MatKhau]) VALUES (N'N14DCCN003', N'Trịnh Thông', N'Mãn', N'Nam', CAST(N'1996-01-01T00:00:00.000' AS DateTime), N'N14DCCN003@student.ptithcm.edu.vn', N'D14CQIS01 ', N'1111')
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-09-12T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-09-19T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-09-26T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-10-03T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-10-10T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-10-17T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-10-24T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-10-31T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-11-07T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-11-14T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-11-21T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
INSERT [dbo].[ThoiKhoaBieu] ([Ngay], [Buoi], [TietBD], [MaLopTC]) VALUES (CAST(N'2018-11-28T00:00:00.000' AS DateTime), N'Sáng', 1, 14)
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_LopTinChi]    Script Date: 8/7/2018 10:56:19 PM ******/
ALTER TABLE [dbo].[LopTinChi] ADD  CONSTRAINT [IX_LopTinChi] UNIQUE NONCLUSTERED 
(
	[NienKhoa] ASC,
	[HocKy] ASC,
	[MaMonHoc] ASC,
	[Nhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DangKy]  WITH CHECK ADD  CONSTRAINT [FK_DangKy_LopTinChi] FOREIGN KEY([MaLopTC])
REFERENCES [dbo].[LopTinChi] ([MaLopTC])
GO
ALTER TABLE [dbo].[DangKy] CHECK CONSTRAINT [FK_DangKy_LopTinChi]
GO
ALTER TABLE [dbo].[DangKy]  WITH CHECK ADD  CONSTRAINT [FK_DangKy_SinhVien] FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[DangKy] CHECK CONSTRAINT [FK_DangKy_SinhVien]
GO
ALTER TABLE [dbo].[DiemDanh]  WITH CHECK ADD  CONSTRAINT [FK_DiemDanh_LopTinChi] FOREIGN KEY([MaLopTC])
REFERENCES [dbo].[LopTinChi] ([MaLopTC])
GO
ALTER TABLE [dbo].[DiemDanh] CHECK CONSTRAINT [FK_DiemDanh_LopTinChi]
GO
ALTER TABLE [dbo].[DiemDanh]  WITH CHECK ADD  CONSTRAINT [FK_DiemDanh_SinhVien] FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[DiemDanh] CHECK CONSTRAINT [FK_DiemDanh_SinhVien]
GO
ALTER TABLE [dbo].[DongHocPhi]  WITH CHECK ADD  CONSTRAINT [FK_DongHocPhi_HocPhiTheoDangKy] FOREIGN KEY([IDHocPhi])
REFERENCES [dbo].[HocPhiTheoDangKy] ([ID])
GO
ALTER TABLE [dbo].[DongHocPhi] CHECK CONSTRAINT [FK_DongHocPhi_HocPhiTheoDangKy]
GO
ALTER TABLE [dbo].[DongHocPhi]  WITH CHECK ADD  CONSTRAINT [FK_DongHocPhi_SinhVien] FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[DongHocPhi] CHECK CONSTRAINT [FK_DongHocPhi_SinhVien]
GO
ALTER TABLE [dbo].[GiangVien]  WITH CHECK ADD  CONSTRAINT [FK_GiangVien_Khoa] FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[Khoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[GiangVien] CHECK CONSTRAINT [FK_GiangVien_Khoa]
GO
ALTER TABLE [dbo].[GiaTinChi]  WITH CHECK ADD  CONSTRAINT [FK_GiaTinChi_HeDaoTao] FOREIGN KEY([MaHDT])
REFERENCES [dbo].[HeDaoTao] ([MaHDT])
GO
ALTER TABLE [dbo].[GiaTinChi] CHECK CONSTRAINT [FK_GiaTinChi_HeDaoTao]
GO
ALTER TABLE [dbo].[HocPhiTheoDangKy]  WITH CHECK ADD  CONSTRAINT [FK_HocPhiTheoDangKy_GiaTinChi] FOREIGN KEY([MaGiaTC])
REFERENCES [dbo].[GiaTinChi] ([MaGiaTC])
GO
ALTER TABLE [dbo].[HocPhiTheoDangKy] CHECK CONSTRAINT [FK_HocPhiTheoDangKy_GiaTinChi]
GO
ALTER TABLE [dbo].[LopTinChi]  WITH CHECK ADD  CONSTRAINT [FK_LopTinChi_GiangVien] FOREIGN KEY([MaGV])
REFERENCES [dbo].[GiangVien] ([MaGV])
GO
ALTER TABLE [dbo].[LopTinChi] CHECK CONSTRAINT [FK_LopTinChi_GiangVien]
GO
ALTER TABLE [dbo].[LopTinChi]  WITH CHECK ADD  CONSTRAINT [FK_LopTinChi_MonHoc] FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MonHoc] ([MaMH])
GO
ALTER TABLE [dbo].[LopTinChi] CHECK CONSTRAINT [FK_LopTinChi_MonHoc]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Lop] FOREIGN KEY([MaLop])
REFERENCES [dbo].[Lop] ([MaLop])
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Lop]
GO
ALTER TABLE [dbo].[ThoiKhoaBieu]  WITH CHECK ADD  CONSTRAINT [FK_BuoiHoc_LopTinChi] FOREIGN KEY([MaLopTC])
REFERENCES [dbo].[LopTinChi] ([MaLopTC])
GO
ALTER TABLE [dbo].[ThoiKhoaBieu] CHECK CONSTRAINT [FK_BuoiHoc_LopTinChi]
GO
/****** Object:  StoredProcedure [dbo].[Insert_DangKy]    Script Date: 8/7/2018 10:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Insert_DangKy] 
	@MaSV varchar(10),
	@MaLopTC int
AS
BEGIN
	INSERT INTO DangKy
           ([MaLopTC]
           ,[MaSV])
     VALUES
           (@MaLopTC, @MaSV)
END

GO
