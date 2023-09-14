CREATE DATABASE QuanLyCuaHangSach
GO

USE QuanLyCuaHangSach
GO
SET DATEFORMAT DMY

CREATE TABLE NhanVien
(
	--MaNV INT IDENTITY NOT NULL,
	MaNV VARCHAR(10) NOT NULL,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh SMALLDATETIME NOT NULL,
	GioiTinh NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(255),
	SoDT VARCHAR(11),
	CONSTRAINT PK_NhanVien PRIMARY KEY (MaNV)
)

CREATE TABLE Quyen
(
	--MaQuyen INT IDENTITY NOT NULL,
	MaQuyen VARCHAR(10) NOT NULL,
	TenQuyen NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Quyen PRIMARY KEY (MaQuyen)
)

CREATE TABLE TaiKhoan
(
	--MaTK INT IDENTITY NOT NULL,
	TenTK VARCHAR(100) NOT NULL,
	MatKhau NVARCHAR(100) NOT NULL,
	MaNV VARCHAR(10) NOT NULL,
	MaQuyen VARCHAR(10) NOT NULL,
	CONSTRAINT PK_TaiKhoan PRIMARY KEY (TenTK)
)

CREATE TABLE KhachHang
(
	--MaKH INT IDENTITY NOT NULL,
	MaKH VARCHAR(10) NOT NULL,
	HoTen NVARCHAR(100) NOT NULL,
	NgaySinh SMALLDATETIME NOT NULL,
	GioiTinh NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(100),
	SoDT VARCHAR(11),
	CONSTRAINT PK_KhachHang PRIMARY KEY (MaKH)
)

CREATE TABLE LoaiSach
(
	--MaLoai INT IDENTITY NOT NULL,
	MaLoai VARCHAR(10) NOT NULL,
	TenLoai NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_LoaiSach PRIMARY KEY (MaLoai)
)

CREATE TABLE Sach
(
	--MaSach INT IDENTITY NOT NULL,
	MaSach VARCHAR(10) NOT NULL,
	MaLoai VARCHAR(10) NOT NULL,
	TenSach NVARCHAR(100) NOT NULL,
	Tacgia NVARCHAR(100) NOT NULL,
	--DonGia FLOAT NOT NULL,
	SoLuong INT NOT NULL,
	CONSTRAINT PK_Sach PRIMARY KEY (MaSach)
)

CREATE TABLE PhieuNhap
(
	--MaPN INT IDENTITY NOT NULL,
	MaPN VARCHAR(10) NOT NULL,
	ThoiDiemNhap SMALLDATETIME NOT NULL,
	GhiChu NVARCHAR(255),
	MaNV VARCHAR(10) NOT NULL,
	CONSTRAINT PK_PhieuNhap PRIMARY KEY (MaPN)
)

CREATE TABLE ChiTietPhieuNhap
(
	MaPN VARCHAR(10) NOT NULL,
	MaSach VARCHAR(10) NOT NULL,
	GiaNhap FLOAT NOT NULL,
	SoLuongNhap INT NOT NULL,
	TongTien FLOAT NOT NULL,
	CONSTRAINT PK_ChiTietPhieuNhap PRIMARY KEY (MaSach, MaPN)
)

CREATE TABLE HoaDon
(
	--MaHD INT IDENTITY NOT NULL,
	MaHD VARCHAR(10) NOT NULL,
	ThoiDiemLapHD SMALLDATETIME NOT NULL,
	MaKH VARCHAR(10) NOT NULL,
	MaNV VARCHAR(10) NOT NULL,
	CONSTRAINT PK_HoaDon PRIMARY KEY (MaHD)
)

CREATE TABLE ChiTietHoaDon
(
	--MaHD INT NOT NULL,
	MaHD VARCHAR(10) NOT NULL,
	MaSach VARCHAR(10) NOT NULL,
	GiaBan FLOAT NOT NULL,
	SoLuongBan INT NOT NULL,
	TongTien FLOAT NOT NULL,
	CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaSach, MaHD)
)

ALTER TABLE TaiKhoan ADD CONSTRAINT FK_TK_QUYEN FOREIGN KEY (MaQuyen) REFERENCES Quyen(MaQuyen);

ALTER TABLE TaiKhoan ADD CONSTRAINT FK_TK_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);

ALTER TABLE Sach ADD CONSTRAINT FK_SACH_LOAISACH FOREIGN KEY (MaLoai) REFERENCES LoaiSach(MaLoai);

ALTER TABLE PhieuNhap ADD CONSTRAINT FK_PN_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);

ALTER TABLE ChiTietPhieuNhap ADD CONSTRAINT FK_CTPN_PN FOREIGN KEY (MaPN) REFERENCES PhieuNhap(MaPN);

ALTER TABLE ChiTietPhieuNhap ADD CONSTRAINT FK_CTPN_SACH FOREIGN KEY (MaSach) REFERENCES Sach(MaSach);

ALTER TABLE HoaDon ADD CONSTRAINT FK_HD_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);

ALTER TABLE HoaDon ADD CONSTRAINT FK_HD_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH);

ALTER TABLE ChiTietHoaDon ADD CONSTRAINT FK_CTHD_KH FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD);

ALTER TABLE ChiTietHoaDon ADD CONSTRAINT FK_CTHD_SACH FOREIGN KEY (MaSach) REFERENCES Sach(MaSach);

GO

--------------------------------------THÊM DỮ LIỆU VÀO CÁC BẢNG TRONG DATABASE--------------------------------------
--Bảng Nhân Viên
INSERT INTO NhanVien VALUES ('NV01', N'Lê Huỳnh Nhật Tâm', '1/1/1999', N'Nam', N'Tp Hồ Chí Minh', '0123456789');
INSERT INTO NhanVien VALUES ('NV02', N'Đặng Thùy Trang', '1/1/2001', N'Nữ', N'Hà Nội', '0132456789');
INSERT INTO NhanVien VALUES ('NV03', N'Lê Đức Tiến', '1/1/1989', N'Nam', N'Tp Đà Nẵng', '0123476589');
INSERT INTO NhanVien VALUES ('NV04', N'Đinh Thanh Phong', '25/8/1999', N'Nam', N'Tp Hải Phòng', '0123498819');

--Bảng Quyền
INSERT INTO Quyen VALUES ('Q01', 'Admin');
INSERT INTO Quyen VALUES ('Q02', 'NVBanHang');
INSERT INTO Quyen VALUES ('Q03', 'NVKho');

--Bảng Tài khoản
INSERT INTO TaiKhoan VALUES ('tam', '123456', 'NV01', 'Q01');
INSERT INTO TaiKhoan VALUES ('trang', '123456', 'NV02', 'Q02');
INSERT INTO TaiKhoan VALUES ('tien', '123456', 'NV03', 'Q03');
INSERT INTO TaiKhoan VALUES ('phong', '123456', 'NV04', 'Q03');

--Bảng Khách hàng
INSERT INTO KhachHang VALUES ('KH01', N'Nguyễn Trọng Đức', '2/3/1989', N'Nam', N'Tp Hồ Chí Minh', '0123456789');
INSERT INTO KhachHang VALUES ('KH02', N'Lê Xuân Tuấn', '7/1/1987', N'Nam', N'Tp Dà Nẵng', '0132456789');
INSERT INTO KhachHang VALUES ('KH03', N'Võ Công Tuấn', '11/8/1989', N'Nam', N'Hà Nội', '0123476589');
INSERT INTO KhachHang VALUES ('KH04', N'Nguyễn Hồng Nhung', '28/3/1997', N'Nữ', N'Tp Hải Phòng', '0123498819');

--Bảng Hóa đơn
INSERT INTO HoaDon VALUES ('HD01', '5/2/2021', 'KH01', 'NV02');
INSERT INTO HoaDon VALUES ('HD02', '12/12/2021', 'KH02', 'NV02');
INSERT INTO HoaDon VALUES ('HD03', '28/2/2022', 'KH03', 'NV02');
INSERT INTO HoaDon VALUES ('HD04', '30/4/2022', 'KH04', 'NV02');

--Bảng Loại sách
INSERT INTO LoaiSach VALUES ('LS01', N'Truyện tranh');
INSERT INTO LoaiSach VALUES ('LS02', N'Sách văn học');
INSERT INTO LoaiSach VALUES ('LS03', N'Sách lịch sử');
INSERT INTO LoaiSach VALUES ('LS04', N'Khác');

--Bảng Sách
INSERT INTO Sach VALUES ('S01', 'LS01', N'Thám tử lừng danh Conan', N'Aoyama', 30);
INSERT INTO Sach VALUES ('S02', 'LS02', N'Đại Việt sử ký toàn thư', N'Sử quán triều Hậu Lê', 7);
INSERT INTO Sach VALUES ('S03', 'LS03', N'Bố già', N'Mario Puzo', 25);
INSERT INTO Sach VALUES ('S04', 'LS04', N'Vật lý 10', N'Bộ Giáo Dục Và Đào Tạo', 25);

--Bảng Phiếu Nhập
INSERT INTO PhieuNhap VALUES ('PN01', '15/12/2021', N'Nhập truyện tranh', 'NV04');
INSERT INTO PhieuNhap VALUES ('PN02', '20/12/2021', N'Sách Văn học', 'NV03');
INSERT INTO PhieuNhap VALUES ('PN03', '25/3/2022', N'Sách lịch sử', 'NV04');
INSERT INTO PhieuNhap VALUES ('PN04', '2/4/2022', N'Nhập truyện tranh', 'NV04');

--Bảng Chi tiết hóa đơn
--HD1
INSERT INTO ChiTietHoaDon VALUES ('HD01', 'S01', 18000, 1, 18000);
INSERT INTO ChiTietHoaDon VALUES ('HD01', 'S02', 389000, 1, 389000);
--HD2
INSERT INTO ChiTietHoaDon VALUES ('HD02', 'S04',15000, 3, 45000);
--HD3
INSERT INTO ChiTietHoaDon VALUES ('HD03', 'S01', 18000, 2, 36000);
INSERT INTO ChiTietHoaDon VALUES ('HD03', 'S02', 389000, 1, 389000);
INSERT INTO ChiTietHoaDon VALUES ('HD03', 'S03', 180000, 1, 180000);
--HD4
INSERT INTO ChiTietHoaDon VALUES ('HD04', 'S01', 18000, 1, 18000);
INSERT INTO ChiTietHoaDon VALUES ('HD04', 'S04', 15000, 1, 15000);

--Bảng Chi tiết phiếu nhập
INSERT INTO ChiTietPhieuNhap VALUES ('PN01', 'S01', 15000, 10, 150000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN01', 'S02', 350000, 5, 1750000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN01', 'S03', 150000, 10, 1500000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN01', 'S04', 10000, 10, 100000);

INSERT INTO ChiTietPhieuNhap VALUES ('PN02', 'S01', 15000, 5, 75000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN02', 'S02', 350000, 2, 700000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN02', 'S03', 150000, 5, 750000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN02', 'S04', 10000, 10, 100000);

INSERT INTO ChiTietPhieuNhap VALUES ('PN03', 'S01', 15000, 8, 120000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN03', 'S03', 150000, 10, 150000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN03', 'S04', 10000, 5, 50000);

INSERT INTO ChiTietPhieuNhap VALUES ('PN04', 'S01', 15000, 7, 105000);

GO



--------------------------------------TẠO CÁC STORE PROCEDURES THÊM, XÓA, SỬA VÀ LẤY RA CÁC DANH SÁCH--------------------------------------

-----------------------------Bảng LoaiSach-----------------------------
 --Danh sách thể loại sách 
 CREATE PROC SP_DanhSachTheLoai
 AS
 BEGIN
	SELECT * FROM LoaiSach
 END
 GO

 --Thêm 1 thể loại sách mới
 CREATE PROC SP_ThemTheLoai
 @TenLoai NVARCHAR(100)
 AS
 BEGIN
	INSERT INTO LoaiSach VALUES(@TenLoai)
 END
 GO

-----------------------------Bảng Sach-----------------------------
 --Thêm n quyển sách mới 
 CREATE PROC SP_ThemSach
 @MaLoai INT ,
 @TenSach NVARCHAR(100),
 @TacGia NVARCHAR(100),
 @DonGia FLOAT,
 @SoLuong INT
 AS
 BEGIN
	INSERT INTO Sach VALUES(@MaLoai, @TenSach, @TacGia, @DonGia, @SoLuong)
 END
 GO

 --Bán n cuốn sách có mã sách
 CREATE PROC SP_BanSach
 @MaSach INT, 
 @n INT
 AS
 BEGIN 
	IF EXISTS (SELECT * FROM Sach WHERE MaSach=@MaSach AND SoLuong-@n>=0)
	BEGIN
		UPDATE Sach SET SoLuong=SoLuong-@n WHERE MaSach=@MaSach
	END
	ELSE
	BEGIN
		RETURN
	END
 END
 GO

 --Xóa 1 đầu sách có mã sách @MaSach
 CREATE PROC SP_XoaSach
 @MaSach int
 AS
 BEGIN
	DELETE FROM Sach WHERE MaSach=@MaSach
 END
 GO

 --Load danh sách tất cả sách 
 CREATE PROC SP_TatCaSach
 AS
 BEGIN
	SELECT * FROM Sach
 END
 GO

 --Tìm sách có thể loại là @MaTheLoai
 CREATE PROC SP_TimSachTheoTheLoai
 @MaTheLoai int
 AS
 BEGIN
	SELECT * FROM Sach WHERE MaLoai=@MaTheLoai
 END
 GO

 --Tìm sách theo tác giả
 CREATE PROC SP_TimSachTheoTacGia
 @TacGia NVARCHAR(100)
 AS 
 BEGIN
	SELECT * FROM Sach WHERE TacGia=@TacGia
 END
 GO

 --Tìm sách theo tên sách
 CREATE PROC SP_TimSachTheoTen
 @TenSach NVARCHAR(100)
 AS 
 BEGIN
	SELECT * FROM Sach WHERE TenSach=@TenSach
 END
 GO

 --Tìm sách theo mã sách
 CREATE PROC SP_TimSachTheoMaSach
 @MaSach NVARCHAR(100)
 AS 
 BEGIN
	SELECT * FROM Sach WHERE MaSach=@MaSach
 END
 GO

-----------------------------Bảng HoaDon-----------------------------
 --Load tất cả hóa đơn
 CREATE PROC SP_TatCaHoaDon
 AS
 BEGIN
	SELECT * FROM HoaDon
 END
 GO

 --Xóa 1 hóa đơn
 CREATE PROC SP_XoaHoaDon
 @MaHD int
 AS
 BEGIN
	DELETE FROM HoaDon WHERE MaHD=@MaHD
 END
 GO

 --Tìm hoá đơn theo @MaHD
 CREATE PROC SP_TimHoaDonTheoMaHD
 @MaHD INT
 AS
 BEGIN
	SELECT * FROM HoaDon WHERE MaHD=@MaHD
 END
 GO

-----------------------------Bảng PhieuNhap -----------------------------
 --Load tất cả phiếu nhập
 CREATE PROC SP_TatCaPhieuNhap
 AS
 BEGIN
	SELECT * FROM PhieuNhap
 END
 GO

 --Tìm phiếu nhập theo @MaPN
 CREATE PROC SP_TimPhieuNhapTheoMaPN
 @MaPN INT
 AS
 BEGIN
	SELECT * FROM PhieuNhap WHERE MaPN=@MaPN
 END
 GO

-----------------------------Bảng NhanVien-----------------------------
 --Load tất cả nhân viên
 CREATE PROC SP_TatCaNhanVien
 AS
 BEGIN
	SELECT * FROM NhanVien
 END
 GO

 --Thêm 1 nhân viên
 CREATE PROC SP_ThemNhanVien
 @HoTen NVARCHAR(100) ,
 @NgaySinh NVARCHAR(100),
 @GioiTinh NVARCHAR(100),
 @DiaChi NVARCHAR(255),
 @SoDT VARCHAR(11)
 AS 
 BEGIN
	INSERT INTO NhanVien VALUES(@HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDT)
 END
 GO

 --Tìm nhân viên theo @MaNV
 CREATE PROC SP_TimNhanVienTheoMaNV
 @MaNV INT
 AS
 BEGIN
	SELECT * FROM NhanVien WHERE MaNV=@MaNV
 END
 GO

 --Tìm nhân viên theo @HoTen
 CREATE PROC SP_TimNhanVienTheoHoTen
 @HoTen INT
 AS
 BEGIN
	SELECT * FROM NhanVien WHERE HoTen=@HoTen
 END
 GO


-----------------------------Bảng KhachHang -----------------------------
 --Load tất cả khách hàng
 CREATE PROC SP_TatCaKhachHang
 AS
 BEGIN
	SELECT * FROM KhachHang
 END
 GO

 --Thêm 1 khách hàng
 CREATE PROC SP_ThemKhachHang
 @HoTen NVARCHAR(100) ,
 @NgaySinh NVARCHAR(100),
 @GioiTinh NVARCHAR(100),
 @DiaChi NVARCHAR(255),
 @SoDT VARCHAR(11)
 AS 
 BEGIN
	INSERT INTO KhachHang VALUES(@HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDT)
 END
 GO

 --Tìm khách hàng theo @MaKH
 CREATE PROC SP_TimKhachHangTheoMaKH
 @MaKH INT
 AS
 BEGIN
	SELECT * FROM KhachHang WHERE MaKH=@MaKH
 END
 GO

 --Tìm khách hàng theo @HoTen
 CREATE PROC SP_TimKhachHangTheoHoTen
 @HoTen INT
 AS
 BEGIN
	SELECT * FROM KhachHang WHERE HoTen=@HoTen
 END
 GO

-----------------------------Bảng TaiKhoan -----------------------------
 --Thêm tài khoản
 CREATE PROC SP_ThemTaiKhoan
 @MaNV INT,
 @TenTK VARCHAR(100),
 @MatKhau NVARCHAR(100),
 @MaQuyen INT
 AS
 BEGIN
	INSERT INTO TaiKhoan VALUES(@MaNV, @TenTK, @MatKhau, @MaQuyen)
 END
 GO

 --Xóa tài khoản 
 CREATE PROC SP_XoaTaiKhoan
 @TenTK VARCHAR(100)
 AS
 BEGIN
	DELETE FROM TaiKhoan WHERE TenTK=@TenTK
 END
 GO

 --Tìm tài khoản theo @TenTK
 CREATE PROC SP_TimTaiKhoanTheoTenTK
 @TenTK VARCHAR(100)
 AS
 BEGIN
	SELECT * FROM TaiKhoan WHERE TenTK = @TenTK
 END
 GO

 --Sua thong tin tai khoan
 CREATE PROC SP_SuaTaiKhoan
 @TenTK VARCHAR(100),
 @MaNV INT,
 @MatKhau NVARCHAR(100),
 @MaQuyen INT
 AS 
 BEGIN 
	 UPDATE TaiKhoan
	 SET TenTK = @TenTK, MaNV =  @MaNV,MatKhau = @MatKhau, MaQuyen = @MaQuyen 
	 WHERE TenTK = @TenTK
 END
 GO

 --Lấy ra danh sách tài khoản theo quyền đăng nhập
 CREATE PROC SP_Login
 @user VARCHAR(100),
 @pass NVARCHAR(100)
 AS
 BEGIN
	SELECT TK.TenTK, TK.MatKhau, Q.TenQuyen
	FROM TaiKhoan TK INNER JOIN Quyen Q
	ON TK.MaQuyen = Q.MaQuyen
	WHERE TenTK = @user AND MatKhau = @pass
 END

 EXEC SP_Login @user="admin", @pass ="123456"

 --Lấy ra quyền của @taikhoan
 CREATE PROC SP_KtraQuyen
 @TenTK VARCHAR(100)
 AS
 BEGIN 
	SELECT Q.TenQuyen 
	FROM TaiKhoan T INNER JOIN Quyen Q
	ON T.MaQuyen = Q.MaQuyen
	WHERE T.TenTK = @TenTK
 END
 GO

-----------------------------Bảng ChiTietHoaDon-----------------------------
 --Thêm chi tiết hóa đơn theo MaHD
 /*CREATE PROC SP_ThemCTHD
 @MaSach INT,
 @MaHD INT,
 @DonGia FLOAT,
 @SoLuong INT,
 @TongTien FLOAT
 AS
 BEGIN
	INSERT INTO ChiTietHoaDon VALUES 
 END
 GO*/

 --Xóa chi tiết hóa đơn

-----------------------------Bảng ChiTietPhieuNhap-----------------------------
 --Thêm chi tiết phiếu nhập


 --Xóa chi tiết phiếu nhập
