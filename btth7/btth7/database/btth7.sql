CREATE TABLE [dbo].[DanhMuc](
	[MaDanhMuc] [nvarchar] (50)PRIMARY KEY ,
	[TenDanhMuc] [nvarchar](50) NOT NULL
)
CREATE TABLE [dbo].[SanPham](
	[Ma] [varchar](30) PRIMARY KEY,
	[Ten] [nvarchar](50) NOT NULL,
	[DonGia] [int] NULL,
	[MaDanhMuc] [nvarchar](50) NULL,
	CONSTRAINT [FK] FOREIGN KEY([MaDanhMuc])REFERENCES [dbo].[DanhMuc] ([MaDanhMuc])
)

insert DanhMuc  values('1','dongho')
insert DanhMuc  values('2','dienthoai')
insert DanhMuc  values('3','maytinh')
select * from  DanhMuc

insert SanPham values('1','miband','300000','1')
insert SanPham values('2','miband2','400000','1')
insert SanPham values('3','miband3','500000','1')
insert SanPham values('4','miband4','600000','1')


insert SanPham values('5','huawei','1300000','2')
insert SanPham values('6','huawei2','1400000','2')
insert SanPham values('7','huawei3','1500000','2')
insert SanPham values('8','huawei4','1600000','2')

insert SanPham values('9','macbook','13000000','3')
insert SanPham values('10','macbook2','14000000','3')
insert SanPham values('11','macbook3','15000000','3')
insert SanPham values('12','macbook4','16000000','3')

select* from SanPham