use DBMAKETAPI;
create table admin( 
ad_id	nvarchar(50) primary key,
ad_username nvarchar(50) not null unique,
ad_password nvarchar(50) not null,
)
insert into admin values('1,''root','admin');
insert into admin values('2','admin','admin');
insert into admin values('3','test','admin');
select * from admin;
-------------------------
create table category(
cat_id nvarchar(50) primary key,
cat_username nvarchar(50) not null unique,
cat_image nvarchar(max) not null ,
cat_status nvarchar(50) )

insert category values(1,N'Máy chấm công','~/Content/upload/maychamcong1.jpg',NULL)
insert category values(2,N'Đầu đọc mã vạch','~/Content/upload/daudocmavach.jpg',NULL)
insert category values(3,N'Đồng hồ vạn năng','~/Content/upload/donghovannang.jpg',NULL)

insert category values(4,N'Ram máy tính','~/Content/upload/ram.jpg',NULL)
insert category values(5,N'Ổ cứng máy tính','~/Content/upload/ocung.jpg',NULL)
insert category values(6,N'Màn hình máy tính','~/Content/upload/manmaytinh.jpg',NULL)

--drop table category;
select *from category;
delete category where cat_id
------
create table users(
u_id nvarchar(50)primary key,
u_username nvarchar(50) not null ,
u_email nvarchar(50) not null unique,
u_password nvarchar(50) not null ,
u_image nvarchar(max) not null ,
u_contact nvarchar(50) not null unique,

)
insert users values(1,'tovanhung','hungto227@gmail.com','tovanhung','~/Content/upload/chandung.jpg','0379117280')
insert users values(2,'hungto228','hungto228@gmail.com','hungto228','~/Content/upload/chandung2.jpg','01679117280')
insert users values(3,'kiemhieu','hieu1802@gmail.com','kiemhieu','~/Content/upload/chandung3.jpg','01679117266')
--~/Content/upload/2088612622chandung.jpg
select *from users
delete users where u_id=4
--------------------
create table product(
pro_id nvarchar(50) primary key,
pro_username nvarchar(50) not null ,
pro_image nvarchar(max) not null ,
pro_desc nvarchar (max) not null,
pro_price int,

)
select *from product
delete product where pro_id=2


 insert product values(1,N'Máy chấm công iface 402','~/Content/upload/maychamcong1.jpg',N'Máy chấm công khuôn mặt và vân tay IFACE 402
Chấm công bằng khuôn mặt – và vân tay 
Quản lý đến 3.000 dấu vân tay & 700 khuôn mặt
Sử dụng Chip xử lý Intel của Mỹ
Sử dụng Sensor thế hệ mới chống trầy .
Dung lượng nhớ 100.000 IN/OUT
Tích hợp âm thanh. Chuông báo giờ vào, ra, tăng ca….
Kết nối với máy tính  qua cổng RS – 232/485, TCP/IP, USB
Chuông báo giờ vào, ra, tăng ca
Hiển thị tên người chấm công lên máy.
Dữ liệu trong máy không bị mất khi xãy ra cúp điện . 
Tốc độ xử lý nhanh dưới 1s/1lần chấm công.
Kết hợp sử dụng dấu vân tay & khuôn mặt
Bảo mật cao, hiển thị Tiếng Anh & Tiếng Việt','2000000')
insert product values(2,N'Máy chấm công vân tay Ronald Jack 5000T-C','~/Content/upload/maychamcong3.jpg',
N'Máy chấm công vân tay Ronald Jack 5000T-C có khả năng quản lý tới 3000 dấu vân tay và password cho phép doanh nghiệp có thẻ quản lý về bảo mật tốt nhất có thể. Sử dụng chip xử lý mới nhất của Intel cũng giúp tới tay người dụng. Việc được kết nối không dây sẽ giúp cho việc lấy dữ liệu và truyền tải dữ liệu được tốt hơn. Để khi mất điện máy vẫn hoạt động chấm công liên tục các bạn có thể mua thêm pin lưu điện cho máy.Thời gian chấm công khi cúp điện từ 2 đến 4 giờ. Dung lượng Pin 12v/DC. Máy có UPS sẽ báo đèn  khi đang sạc 
& đèn xanh khi sạc đầy và thời gian sạc 4 giờ sẽ đầy pin, Pin lithium bền bỉ.','2000000')
insert product values(3,N'Máy chấm công vân tay ','~/Content/upload/maychamcong3.jpg',
N'Máy chấm công vân tay Ronald Jack 5000T-C có khả năng quản lý tới 3000 dấu vân tay và password cho phép doanh nghiệp có thẻ quản lý về bảo mật tốt nhất có thể. Sử dụng chip xử lý mới nhất của Intel cũng giúp tới tay người dụng. Việc được kết nối không dây sẽ giúp cho việc lấy dữ liệu và truyền tải dữ liệu được tốt hơn. Để khi mất điện máy vẫn hoạt động chấm công liên tục các bạn có thể mua thêm pin lưu điện cho máy.Thời gian chấm công khi cúp điện từ 2 đến 4 giờ. Dung lượng Pin 12v/DC. Máy có UPS sẽ báo đèn  khi đang sạc 
& đèn xanh khi sạc đầy và thời gian sạc 4 giờ sẽ đầy pin, Pin lithium bền bỉ.','2000000')
--đầu đọc mã vạch
insert product values(4,N'Đầu đọc mã vạch li4287','~/Content/upload/daudocmavach.jpg',
N'Máy quét LI4278 nâng khả năng quét mã vạch 1D lên cấp độ tiếp theo, cho phép các nhân viên quét nhanh hơn và xa hơn vì họ có thể chụp gần như mọi mã vạch 1D',
'1000000')
insert product values(5,N'ĐẦU ĐỌC MÃ VẠCH HONEYWELL 1400G','~/Content/upload/daudocmavach1.jpg',
N'Hiện nay, mã vạch 2D ngày càng trở nên phổ biến trong nhiều ngành công nghiệp do một 
số quy định của chính phủ hoặc do những yêu cầu bắt buộc của nhà sản xuất. 
Đầu đọc mã vạch Honeywell 1400G thuộc những dòng máy quét mã vạch với công nghệ chụp ảnh tuyến tính có khả năng đọc được cả những mã vạch có chất lượng kém, thậm chí đọc được cả những mã vạch 2D trên những thiết bị di động, rất thông minh và tiện dụng.',
'1600000')
--đồng hồ vạn năng
insert product values(6,N'Đông hồ vạn năng Kiokissu','~/Content/upload/donghovannang.jpg',
N'Chỉ thị số.DCV: 600mV/6/60/600V 
ACV: 600mV/6/60/600V HZ: 10/100/1000KHz/10MHzDCA: 600/6000µA/60/600mA/6/10A  ACA: 600/6000µA/60/600mA/6/10A. Ω: 400Ω/4/40/400KΩ/4/40MΩ  Kiểm tra diot: 2.8V/0.4mA  Kiểm tra tụ: 40nF/400nF/4 µF/40 µF/400µF/4000µF
 Nhiệt độ: -50...300độ C (-58...572độ F) 
Nguồn : R6P (1.5Vx2)
 Kích thước : 161(L) × 82(W) × 50(D)mm',
'1000000')
insert product values(7,N'Đồng hồ vạn năng Kyoritsu 1009','~/Content/upload/donghovannang1.jpg',
N'Chỉ thị số.DCV: 600mV/6/60/600V 
ACV: 600mV/6/60/600V HZ: 10/100/1000KHz/10MHzDCA: 600/6000µA/60/600mA/6/10A 
ACA: 600/6000µA/60/600mA/6/10A. Ω: 400Ω/4/40/400KΩ/4/40MΩ  Kiểm tra diot: 2.8V/0.4mA 
Kiểm tra tụ: 40nF/400nF/4 µF/40 µF/400µF/4000µF
 Nhiệt độ: -50...300độ C (-58...572độ F) 
Nguồn : R6P (1.5Vx2)
 Kích thước : 161(L) × 82(W) × 50(D)mm',
'1500000')
insert product values(8,N'Đồng hồ vạn năng tự động Zoyi ZT 300AB','~/Content/upload/donghovannang2.jpg',
N'Chỉ thị số.DCV: 600mV/6/60/600V 
ACV: 600mV/6/60/600V HZ: 10/100/1000KHz/10MHzDCA: 600/6000µA/60/600mA/6/10A 
ACA: 600/6000µA/60/600mA/6/10A. Ω: 400Ω/4/40/400KΩ/4/40MΩ  Kiểm tra diot: 2.8V/0.4mA 
Kiểm tra tụ: 40nF/400nF/4 µF/40 µF/400µF/4000µF
 Nhiệt độ: -50...300độ C (-58...572độ F) 
Nguồn : R6P (1.5Vx2)
 Kích thước : 161(L) × 82(W) × 50(D)mm',
'1500000')
insert product values(9,N'Đồng hồ vạn năng Sanwa CD 800A (0,7%)','~/Content/upload/donghovannang3.jpg',
N'Thông số tham khảo thêm của đồng hồ Sanwa CD800A
DCV: 400m/4/40/400/600V - 0.1mV/± 0.7%
ACV: 4/40/400/600V - 0.001V/±1.6%
DCA: 40m/400mA - 0.01mA/±2.2%
ACA: 40m/400mA - 0.01mA/±2.8%
Điện trở Ω: 400/4k/40k/400k/4M/40MΩ - 0.1Ω/±1.5%
Tụ điện F: 50n/500n/5u/50u/100uF - 0.01nF/±5%
Tần số Hz: 5Hz ~ 100kHz - ± 0.5%
Kiểm tra diode, kiểm tra liên tục của mạch
Băng thông: 40 ~ 400Hz
Nguồn: R6Px2',
'1100000')
insert product values(10,N'Đồng hồ vạn năng số Zoyi ZT-M0','~/Content/upload/donghovannang4.jpg',
N'Điện áp DC: 0.1mV - 1000V
Điện áp AC: 0.1mV - 750V
Dòng điện DC: 0.1uA  -20A
Dòng điện AC: 0.1uA - 20A
Điện trở: 0.1Ω - 60MΩ
Tụ điện: 0.001nF - 99.99mF
Tần số: 0.001Hz - 9.999MHz
Chu kỳ: 0.1 - 99.9%
Nhiệt độ: -20 ~ 1000°C/-4 ~ 1832°F',
'1100000')

--ram 
insert product values(11,N'Ram PC DDR2 (PC2) 2Gb bus 800','~/Content/upload/ram1.jpg',
N'Loại Ram:
DDR2 (PC2) dùng cho máy bàn
Loại Bus:
800 (6400U)
Dung lượng
2Gb
Tình trạng:
Còn tốt 99%',
'100000')
insert product values(12,N'Ram Laptop DDR3 4Gb bus 1600','~/Content/upload/ram2.jpg',
N'Loại Ram:
DDR3 (PC3) 1.5V dùng cho laptop
Loại Bus:
1600 (12800s)
Dung lượng
4Gb
Tình trạng:
Còn tốt 99%',
'350000')
insert product values(13,N'RAM máy tính GEIL SUPER LUCE RGB  Màu Đen','~/Content/upload/ram3.jpg',
N'Hãng sản xuất: Geil
Dòng sản phẩm: Super Luce RGB Series
Loại bộ nhớ: DDR4
Dung lượng: 8GB (8GBx1)
Tốc độ hoạt động (BUS): 3000MHz
Độ trễ: CL15 -19
Điện thế:1.2v  1.35v
Trang bị LED: RGB (Hỗ trợ đồng bộ bo mạch chủ)
Hỗ trợ XMP: Có (Intel XMP 2.0)
Tản nhiệt: Có
Màu sắc: Đen',
'990000')
--ổ cứng
insert product values(14,N'Ổ Cứng HDD WD Blue™ 1TB/64MB/7200rpm/3.5 ','~/Content/upload/ocung1.jpg',
N'Thương hiệu	WD
Xuất xứ	Thái Lan / Mã Lai
Dung lượng ổ cứng	1TB
Kích cỡ ổ cứng (mm)	3.5"
Số vòng quay	7200rpm
SKU	1422464777349
Model	WD10EZEX',
'890000')
insert product values(15,N'Ổ Cứng Di Động WD My Passport - Model 2019','~/Content/upload/ocung2.jpg',
N'Thương hiệu	WD
Xuất xứ thương hiệu	Mỹ
Xuất xứ	Mỹ
SKU	9386902161867
Nhà sản xuất	Western
Model	2019',
'890000')
insert product values(16,N'Ổ cứng gắn trong HDD Western Digital BLUE 6TB','~/Content/upload/ocung3.jpg',
N'Thương hiệu	WD
Xuất xứ thương hiệu	Mỹ
Xuất xứ	Thái Lan / Trung Quốc / Malaysia
Dung lượng ổ cứng	6TB
SKU	8780373828150
Model	Ổ cứng gắn trong HDD Western Digital BLUE',
'3400000')
--màn hình
--màn hình
insert product values(17,N'Màn hình Lenovo D32q-20 - 31.5 Inch 2K 100% sRGB','~/Content/upload/manmaytinh2.jpg',
N'Màn hình chuyên thiết kế đồ họa độ phân giải 2K
Tấm nền IPS, độ chuẩn màu 100% sRGB
Hỗ trợ 1.07 tỉ màu
Kích thước màn:
31.5 inch
Độ phân giải:
2K
Tần số quét:
75Hz
Gam màu:
72% NTSC (~100% sRGB)
Độ sáng:
250 cd/m²',
'4900000')
insert product values(18,N'Màn Hình Philips 223V5LHSB2 21.5'' FHD','~/Content/upload/manmaytinh3.jpg',
N'Màn hình chuyên thiết kế đồ họa độ phân giải 2K
Tấm nền IPS, độ chuẩn màu 100% sRGB
Hỗ trợ 1.07 tỉ màu
Kích thước màn:
31.5 inch
Độ phân giải:
2K
Tần số quét:
75Hz
Gam màu:
72% NTSC (~100% sRGB)
Độ sáng:
250 cd/m²',
'2400000')
insert product values(19,N'Màn hình vi tính HP 22fw 21.5'' 3KS61AA','~/Content/upload/manmaytinh4.jpg',
N'Màn hình chuyên thiết kế đồ họa độ phân giải 2K
Tấm nền IPS, độ chuẩn màu 100% sRGB
Hỗ trợ 1.07 tỉ màu
Kích thước màn:
31.5 inch
Độ phân giải:
2K
Tần số quét:
75Hz
Gam màu:
72% NTSC (~100% sRGB)
Độ sáng:
250 cd/m²',
'3090000')