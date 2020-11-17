
CREATE TABLE Sach(
MaSach nvarchar(10)  PRIMARY KEY,
TenSach nvarchar(150) NOT NULL,
MaTG nvarchar(10),
MaTL nvarchar(50),
MaNXB nvarchar(50),
NamXB nvarchar(10))

CREATE TABLE TacGia(
MaTG nvarchar(10) PRIMARY KEY,
TenTG nvarchar(150) not null,
SDT nvarchar(10))

CREATE TABLE NXB(
MaNXB nvarchar(50) PRIMARY KEY,
TenNXB nvarchar(30) not null,
GioiTinh nvarchar(10),
DiaChi  nvarchar(150),
Email nvarchar(150))

ALTER TABLE Sach ADD CONSTRAINT fk_sach_tacgia FOREIGN KEY (MaTG) REFERENCES TacGia (MaTG);
ALTER TABLE Sach ADD CONSTRAINT fk_sach_nxb FOREIGN KEY (MaNXB) REFERENCES NXB (MaNXB);

INSERT INTO Sach VALUES('MS01','Android','TG01','TL01','NXB01','2018/09/26');
INSERT INTO Sach VALUES('MS02','Java','TG02','TL02','NXB02','2013/09/26');
INSERT INTO Sach VALUES('MS03','PHP','TG03','TL03','NXB03','2014/09/26');
INSERT INTO Sach VALUES('MS04','Asp.net','TG04','TL04','NXB04','2015/09/26');
INSERT INTO Sach VALUES('MS05','React Native','TG05','TL05','NXB05','2016/09/26');
INSERT INTO Sach VALUES('MS06','PHP','TG05','TL05','NXB05','2020/09/26');

SELECT *FROM SACH
DELETE FROM Sach

INSERT INTO TacGia VALUES('TG01','Nguyen Van Chuyen','0973090222');
INSERT INTO TacGia VALUES('TG02','Nguyen Van Hung','0973090333');
INSERT INTO TacGia VALUES('TG03','Nguyen Van Hieu','0973090444');
INSERT INTO TacGia VALUES('TG04','To Van Hung','0973090555');
INSERT INTO TacGia VALUES('TG05','Nguyen Ngoc Anh','0973090666');

INSERT INTO NXB VALUES('NXB01','Nguyen Tuan Anh','Nam','Hung Yen','tuanhanh@gmail.com');
INSERT INTO NXB VALUES('NXB02','Pham Van Dai','Nam','Hung Yen','phamdai@gmail.com');
INSERT INTO NXB VALUES('NXB03','Nguyen Duy Anh','Nam','Hung Yen','duyanh@gmail.com');
INSERT INTO NXB VALUES('NXB04','Nguyen Van Nam','Nam','Hung Yen','nguyenam@gmail.com');
INSERT INTO NXB VALUES('NXB05','Pham Van Nam','Nam','Hung Yen','phamnam@gmail.com');
INSERT INTO NXB VALUES('NXB05','Nguyen Thi Hang','Nam','Hung Yen','phamnam@gmail.com');

DROP TABLE Sach
DROP TABLE TacGia
DROP TABLE NXB