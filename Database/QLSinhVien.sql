
CREATE TABLE SinhVien (
MaSV nvarchar(8)  PRIMARY KEY,
TenSV nvarchar(150) NOT NULL,
DiaChi nvarchar(200),
NamSinh nvarchar(10))

CREATE TABLE LopHoc (
KYHIEU nvarchar(8)  PRIMARY KEY,
TENMONHOC nvarchar(150) NOT NULL,
THOIGIAN nvarchar(30))

CREATE TABLE GiaoVien  (
MAGV nvarchar(8)  PRIMARY KEY,
TENGV nvarchar(150) NOT NULL)

INSERT INTO SinhVien VALUES('10117181','Pham Van Dai','Hung Yen','1999/01/14');
INSERT INTO SinhVien VALUES('10117182','Nguyen Tuan Ngoc','Hung Yen','1999/05/20');
INSERT INTO SinhVien VALUES('10117183','Nguyen Van Hung','Hung Yen','1999/01/24');
INSERT INTO SinhVien VALUES('10117184','Nguyen Kiem Hieu','Hung Yen','1999/07/17');
INSERT INTO SinhVien VALUES('10117185','Nguyen Van Chuyen','Hung Yen','1999/08/20');
INSERT INTO SinhVien VALUES('10117186','Nguyen Van Nam','Hung Yen','2001/02/14');
INSERT INTO SinhVien VALUES('10117187','Nguyen Van A','Ha Noi','2000/02/14');

select * from SinhVien
delete from SinhVien

INSERT INTO LopHoc VALUES('LH01','Toan Cao Cap','2020/09/18');
INSERT INTO LopHoc VALUES('LH02','Lap trinh Android','2020/09/18');
INSERT INTO LopHoc VALUES('LH03','Lap trinh Java','2020/09/18');
INSERT INTO LopHoc VALUES('LH04','Tien Anh chuyen nghanh','2020/09/18');
INSERT INTO LopHoc VALUES('LH05','Lap trinh Web API','2020/09/18');

INSERT INTO GiaoVien VALUES('GV01','Nguyen Thi A');
INSERT INTO GiaoVien VALUES('GV02','Nguyen Thi B');
INSERT INTO GiaoVien VALUES('GV03','Nguyen Thi C');
INSERT INTO GiaoVien VALUES('GV04','Nguyen Thi D');
INSERT INTO GiaoVien VALUES('GV05','Nguyen Thi E');