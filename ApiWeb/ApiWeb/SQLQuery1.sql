﻿CREATE TABLE [dbo].[SINHVIEN]
(
	[MASV] INT NOT NULL PRIMARY KEY, 
    [TENSV] NVARCHAR(50) NULL, 
    [GIOITINH] NVARCHAR(50) DEFAULT (N'Nam') NULL, 
    [DIACHI] NVARCHAR(50) NULL, 
    [NAMSINH] DATETIME NULL,
)
CREATE TABLE [dbo].[NHANVIEN] (
    [MaNV]     VARCHAR (50)  NOT NULL,
    [TenNV]    NVARCHAR (50) NOT NULL,
    [GioiTinh] NVARCHAR (50) DEFAULT (N'Nam') NULL,
    [NgaySinh] DATETIME      NULL,
    [Email]    VARCHAR (50)  NULL,
    [SDT]      CHAR (30)     NULL,
    PRIMARY KEY CLUSTERED ([MaNV] ASC)
);
CREATE TABLE [dbo].[SACH]
(
	[MASACH] INT NOT NULL PRIMARY KEY, 
    [TENSACH] NVARCHAR(50) NULL, 
    [TACGIA] NVARCHAR(50) NULL, 
    [NHAXUATBAN] NVARCHAR(50) NULL, 
    [NAMXUATBAN] DATETIME NULL
)
CREATE TABLE [dbo].[TAIKHOAN]
(
	[TENTK] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [MATKHAU] NVARCHAR(50) NULL, 
    [MOTA] NVARCHAR(50) NULL
)