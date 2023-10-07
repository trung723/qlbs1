CREATE DATABASE DoAnQLBS
GO
USE DoAnQLBS
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
INSERT INTO NhanVien VALUES ('NV01', N'Nguyễn Thành Trung', '1/1/2003', N'Nam', N'Hà Nội', '0123456789');
INSERT INTO NhanVien VALUES ('NV02', N'Nguyễn Tiến Hào', '1/1/2003', N'Nam', N'Hà Nội', '0132456789');
INSERT INTO NhanVien VALUES ('NV03', N'Trần Trí Quý', '1/1/2003', N'Nam', N'Tp Đà Nẵng', '0123476589');
INSERT INTO NhanVien VALUES ('NV04', N'Vũ Anh Tú', '1/1/2003', N'Nam', N'Tp Hải Phòng', '0123498819');
INSERT INTO NhanVien VALUES ('NV05', N'Bùi Thị Phương Mai', '2/8/2003', N'Nữ', N'Tp Hải Phòng', '0123498819');

select * from NhanVien;
--Bảng Quyền
INSERT INTO Quyen VALUES ('Q01', 'Admin');
INSERT INTO Quyen VALUES ('Q02', 'NVBanHang');
INSERT INTO Quyen VALUES ('Q03', 'NVKho');

--Bảng Tài khoản
INSERT INTO TaiKhoan VALUES ('Trung', '123456', 'NV01', 'Q01');
INSERT INTO TaiKhoan VALUES ('Hao', '123456', 'NV02', 'Q01');
INSERT INTO TaiKhoan VALUES ('Quy', '123456', 'NV03', 'Q02');
INSERT INTO TaiKhoan VALUES ('Tu', '123456', 'NV04', 'Q03');
INSERT INTO TaiKhoan VALUES ('Mai', '123456', 'NV05', 'Q03');
select * from TaiKhoan;

--Bảng Khách hàng
INSERT INTO KhachHang VALUES ('KH01', N'Phạm Nhật Vượng', '2/3/2003', N'Nam', N'Tp Hồ Chí Minh', '0123456789');
INSERT INTO KhachHang VALUES ('KH02', N'Nguyễn Thị Phương Thảo', '7/1/2001', N'Nữ', N'Tp Dà Nẵng', '0132456789');
INSERT INTO KhachHang VALUES ('KH03', N'Đoàn Ngọc Hải', '11/8/1989', N'Nam', N'Hà Nội', '0123476589');
INSERT INTO KhachHang VALUES ('KH04', N'Nguyễn Hồng Nhung', '11/3/1997', N'Nữ', N'Tp Hải Phòng', '0123498819');
INSERT INTO KhachHang VALUES ('KH05', N'Đàm Vĩnh Hưng', '11/8/1989', N'Nam', N'Hà Nội', '0123476589');
INSERT INTO KhachHang VALUES ('KH06', N'Lê Thị Diệu Linh', '5/12/1995', N'Nữ', N'Đà Nẵng', '0123678901');
INSERT INTO KhachHang VALUES ('KH07', N'Trần Văn Tú', '9/7/2000', N'Nam', N'Tp Hồ Chí Minh', '0123678902');
INSERT INTO KhachHang VALUES ('KH08', N'Nguyễn Thanh Tùng', '3/5/1993', N'Nam', N'Hà Nội', '0123678903');
INSERT INTO KhachHang VALUES ('KH09', N'Phạm Thị Mai', '6/9/1998', N'Nữ', N'Hải Phòng', '0123678904');
INSERT INTO KhachHang VALUES ('KH10', N'Lê Quang Vinh', '2/2/1990', N'Nam', N'Tp Hồ Chí Minh', '0123678905');
INSERT INTO KhachHang VALUES ('KH11', N'Nguyễn Minh Trí', '10/11/1987', N'Nam', N'Hà Nội', '0123678906');
INSERT INTO KhachHang VALUES ('KH12', N'Trần Thị Anh', '12/4/1992', N'Nữ', N'Hồ Chí Minh', '0123678907');
INSERT INTO KhachHang VALUES ('KH13', N'Đỗ Văn Dũng', '8/6/1996', N'Nam', N'Đà Nẵng', '0123678908');
INSERT INTO KhachHang VALUES ('KH14', N'Nguyễn Thị Thảo', '4/1/2001', N'Nữ', N'Hải Phòng', '0123678909');
INSERT INTO KhachHang VALUES ('KH15', N'Lê Văn Hùng', '7/3/1988', N'Nam', N'Hà Nội', '0123678910');

INSERT INTO KhachHang VALUES ('KH16', N'Trần Minh Tâm', '5/15/1993', N'Nam', N'Quảng Bình', '0123678911');
INSERT INTO KhachHang VALUES ('KH17', N'Nguyễn Thị Huệ', '9/8/1995', N'Nữ', N'Hồ Chí Minh', '0123678912');
INSERT INTO KhachHang VALUES ('KH18', N'Phạm Văn Trung', '3/20/1989', N'Nam', N'Nghệ An', '0123678913');
INSERT INTO KhachHang VALUES ('KH19', N'Lê Thị Loan', '11/22/1990', N'Nữ', N'Bắc Ninh', '0123678914');
INSERT INTO KhachHang VALUES ('KH20', N'Nguyễn Đức Anh', '1/10/1985', N'Nam', N'Hà Nội', '0123678915');
INSERT INTO KhachHang VALUES ('KH21', N'Vũ Thị Hương', '6/7/1998', N'Nữ', N'Quảng Ninh', '0123678916');
INSERT INTO KhachHang VALUES ('KH22', N'Đặng Văn Thanh', '4/18/1994', N'Nam', N'Bình Định', '0123678917');
INSERT INTO KhachHang VALUES ('KH23', N'Hoàng Văn Thắng', '2/9/1987', N'Nam', N'Thái Bình', '0123678918');
INSERT INTO KhachHang VALUES ('KH24', N'Phạm Thị Mai', '10/3/1992', N'Nữ', N'Hà Tĩnh', '0123678919');
INSERT INTO KhachHang VALUES ('KH25', N'Nguyễn Văn An', '12/12/1999', N'Nam', N'Hải Dương', '0123678920');

select*from KhachHang;
--Bảng Hóa đơn
INSERT INTO HoaDon VALUES ('HD01', '5/2/2021', 'KH01', 'NV02');
INSERT INTO HoaDon VALUES ('HD02', '12/12/2023', 'KH02', 'NV02');
INSERT INTO HoaDon VALUES ('HD03', '10/2/2023', 'KH03', 'NV02');
INSERT INTO HoaDon VALUES ('HD04', '3/4/2023', 'KH04', 'NV02');
INSERT INTO HoaDon VALUES ('HD05', '1/4/2023', 'KH01', 'NV01');

INSERT INTO HoaDon VALUES ('HD06', '5/5/2023', 'KH05', 'NV03');
INSERT INTO HoaDon VALUES ('HD07', '8/10/2023', 'KH06', 'NV04');
INSERT INTO HoaDon VALUES ('HD08', '11/6/2023', 'KH07', 'NV01');
INSERT INTO HoaDon VALUES ('HD09', '6/8/2023', 'KH08', 'NV02');
INSERT INTO HoaDon VALUES ('HD10', '7/1/2023', 'KH09', 'NV03');
INSERT INTO HoaDon VALUES ('HD11', '4/3/2023', 'KH10', 'NV04');
INSERT INTO HoaDon VALUES ('HD12', '2/5/2022', 'KH11', 'NV01');
INSERT INTO HoaDon VALUES ('HD13', '9/9/2023', 'KH12', 'NV02');
INSERT INTO HoaDon VALUES ('HD14', '12/12/2023', 'KH13', 'NV03');
INSERT INTO HoaDon VALUES ('HD15', '10/10/2023', 'KH14', 'NV04');

--Bảng Loại sách
INSERT INTO LoaiSach VALUES ('LS01', N'Truyện tranh');
INSERT INTO LoaiSach VALUES ('LS02', N'Sách văn học');
INSERT INTO LoaiSach VALUES ('LS03', N'Sách lịch sử');
INSERT INTO LoaiSach VALUES ('LS04', N'Khác');
INSERT INTO LoaiSach VALUES ('LS05', N'Sách khoa học');
INSERT INTO LoaiSach VALUES ('LS06', N'Sách kỹ năng sống');
INSERT INTO LoaiSach VALUES ('LS07', N'Sách thiếu nhi');
INSERT INTO LoaiSach VALUES ('LS08', N'Trinh thám');
INSERT INTO LoaiSach VALUES ('LS09', N'Kỹ thuật');
INSERT INTO LoaiSach VALUES ('LS10', N'Sách tự lập');
INSERT INTO LoaiSach VALUES ('LS11', N'Sách tổng hợp');
INSERT INTO LoaiSach VALUES ('LS12', N'Sách tâm lý');
INSERT INTO LoaiSach VALUES ('LS13', N'Sách tiểu sử');
INSERT INTO LoaiSach VALUES ('LS14', N'Sách kinh tế');

INSERT INTO LoaiSach VALUES ('LS15', N'Sách khoa học tự nhiên');
INSERT INTO LoaiSach VALUES ('LS16', N'Sách khoa học xã hội');
INSERT INTO LoaiSach VALUES ('LS17', N'Sách văn học nước ngoài');
INSERT INTO LoaiSach VALUES ('LS18', N'Sách văn học Việt Nam');
INSERT INTO LoaiSach VALUES ('LS19', N'Sách kỹ năng lãnh đạo');
INSERT INTO LoaiSach VALUES ('LS20', N'Sách kỹ năng quản lý');
INSERT INTO LoaiSach VALUES ('LS21', N'Sách nghệ thuật');
INSERT INTO LoaiSach VALUES ('LS22', N'Sách tự lập kinh doanh');
INSERT INTO LoaiSach VALUES ('LS23', N'Sách lịch sử Việt Nam');
INSERT INTO LoaiSach VALUES ('LS24', N'Sách lịch sử thế giới');

--Bảng Sách
INSERT INTO Sach VALUES ('S01', 'LS01', N'Thám tử lừng danh Conan', N'Aoyama', 30);
INSERT INTO Sach VALUES ('S02', 'LS02', N'Đại Việt sử ký toàn thư', N'Sử quán triều Hậu Lê', 7);
INSERT INTO Sach VALUES ('S03', 'LS03', N'Bố già', N'Mario Puzo', 25);
INSERT INTO Sach VALUES ('S04', 'LS04', N'Vật lý 10', N'Bộ Giáo Dục Và Đào Tạo', 25);

INSERT INTO Sach VALUES ('S05', 'LS02', N'Tiếng gọi nơi hoang dã', N'Jack London', 15);
INSERT INTO Sach VALUES ('S06', 'LS05', N'Cơ sở dữ liệu học', N'Abraham Silberschatz', 20);
INSERT INTO Sach VALUES ('S07', 'LS06', N'7 thói quen của người hiệu quả', N'Stephen R. Covey', 40);
INSERT INTO Sach VALUES ('S08', 'LS08', N'Bản giao hưởng mất tích', N'Dan Brown', 18);
INSERT INTO Sach VALUES ('S09', 'LS09', N'JavaScript: The Good Parts', N'Douglas Crockford', 30);
INSERT INTO Sach VALUES ('S10', 'LS03', N'Thế kỷ 20 - Cuộc chiến thế giới thứ hai', N'Winston S. Churchill', 12);
INSERT INTO Sach VALUES ('S11', 'LS10', N'Bí quyết tự lập và thành công', N'Napoleon Hill', 35);
INSERT INTO Sach VALUES ('S12', 'LS07', N'Doraemon', N'Fujiko F. Fujio', 22);
INSERT INTO Sach VALUES ('S13', 'LS11', N'Đắc nhân tâm', N'Dale Carnegie', 28);
INSERT INTO Sach VALUES ('S14', 'LS14', N'Kinh tế học hài hước', N'N. Gregory Mankiw', 17);
-- Inserting 10 more books into Sach table
INSERT INTO Sach VALUES ('S15', 'LS02', N'Tiểu thuyết Moby Dick', N'Herman Melville', 10);
INSERT INTO Sach VALUES ('S16', 'LS05', N'Bí mật của Elon Musk', N'Ashlee Vance', 5);
INSERT INTO Sach VALUES ('S17', 'LS06', N'Cuộc sống đơn giản', N'Jean-Louis Servan-Schreiber', 20);
INSERT INTO Sach VALUES ('S18', 'LS08', N'Pháp sư Sherlock Holmes', N'Arthur Conan Doyle', 12);
INSERT INTO Sach VALUES ('S19', 'LS09', N'Lập trình Python cơ bản', N'Eric Matthes', 18);
INSERT INTO Sach VALUES ('S20', 'LS03', N'Chiến tranh thế giới thứ nhất', N'John Keegan', 8);
INSERT INTO Sach VALUES ('S21', 'LS10', N'Định hình tương lai của bạn', N'Brian Tracy', 15);
INSERT INTO Sach VALUES ('S22', 'LS07', N'Harry Potter và Hòn đá Phù thủy', N'J.K. Rowling', 25);
INSERT INTO Sach VALUES ('S23', 'LS11', N'Bí quyết thành công trong công việc', N'Stephen R. Covey', 30);
INSERT INTO Sach VALUES ('S24', 'LS14', N'Chủ nghĩa tài chính cá nhân', N'Robert T. Kiyosaki', 15);

INSERT INTO Sach VALUES ('S25', 'LS09', N'Những bí quyết thành công trong marketing', N'Philip Kotler', 20);
INSERT INTO Sach VALUES ('S26', 'LS06', N'Thế giới bên ngoài kỹ năng sống', N'Timothy Ferriss', 25);
INSERT INTO Sach VALUES ('S27', 'LS13', N'Tiểu sử Steve Jobs', N'Walter Isaacson', 18);
INSERT INTO Sach VALUES ('S28', 'LS21', N'Nghệ thuật phỏng vấn tuyển dụng', N'James Reed', 22);
INSERT INTO Sach VALUES ('S29', 'LS17', N'Pride and Prejudice', N'Jane Austen', 15);
INSERT INTO Sach VALUES ('S30', 'LS18', N'Tiếng Gọi Của Núi', N'Truong Chi', 12);
INSERT INTO Sach VALUES ('S31', 'LS19', N'Quốc Gia Nước Mỹ: Nguồn gốc, Tiến trình, Tương Lai', N'George Brown Tindall, David Emory Shi', 20);
INSERT INTO Sach VALUES ('S32', 'LS22', N'Thái độ quyết định thành công', N'Jeff Keller', 18);
INSERT INTO Sach VALUES ('S33', 'LS23', N'Lịch sử Việt Nam qua các thời kỳ', N'Phan Huy Lê', 25);
INSERT INTO Sach VALUES ('S34', 'LS24', N'Lịch sử thế giới từ nguồn gốc đến hiện đại', N'Peter Stearns, Michael Adas, Stuart Schwartz, Marc Jason Gilbert', 30);

select * from sach;
--Bảng Phiếu Nhập
INSERT INTO PhieuNhap VALUES ('PN01', '5/2/2023', N'Nhập truyện tranh', 'NV04');
INSERT INTO PhieuNhap VALUES ('PN02', '2/3/2023', N'Sách Văn học', 'NV03');
INSERT INTO PhieuNhap VALUES ('PN03', '5/3/2023', N'Sách lịch sử', 'NV04');
INSERT INTO PhieuNhap VALUES ('PN04', '2/4/2023', N'Nhập truyện tranh', 'NV04');
INSERT INTO PhieuNhap VALUES ('PN05', '2/4/2023', N'Nhập truyện tranh', 'NV01');
-- Inserting 10 more entries into PhieuNhap table
INSERT INTO PhieuNhap VALUES ('PN06', '5/5/2023', N'Sách khoa học', 'NV02');
INSERT INTO PhieuNhap VALUES ('PN07', '6/5/2023', N'Sách kỹ năng sống', 'NV03');
INSERT INTO PhieuNhap VALUES ('PN08', '7/6/2023', N'Trinh thám', 'NV01');
INSERT INTO PhieuNhap VALUES ('PN09', '8/6/2023', N'Kỹ thuật', 'NV02');
INSERT INTO PhieuNhap VALUES ('PN10', '9/7/2023', N'Sách tự lập', 'NV04');
INSERT INTO PhieuNhap VALUES ('PN11', '10/7/2023', N'Sách tổng hợp', 'NV03');
INSERT INTO PhieuNhap VALUES ('PN12', '11/8/2023', N'Sách tâm lý', 'NV01');
INSERT INTO PhieuNhap VALUES ('PN13', '12/8/2023', N'Sách tiểu sử', 'NV02');
INSERT INTO PhieuNhap VALUES ('PN14', '13//2023', N'Sách kinh tế', 'NV03');
INSERT INTO PhieuNhap VALUES ('PN15', '14/9/2023', N'Khác', 'NV04');

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
-- HD5
INSERT INTO ChiTietHoaDon VALUES ('HD05', 'S05', 25000, 2, 50000);
INSERT INTO ChiTietHoaDon VALUES ('HD05', 'S06', 120000, 1, 120000);
-- HD6
INSERT INTO ChiTietHoaDon VALUES ('HD06', 'S03', 180000, 3, 540000);
-- HD7
INSERT INTO ChiTietHoaDon VALUES ('HD07', 'S02', 389000, 1, 389000);
INSERT INTO ChiTietHoaDon VALUES ('HD07', 'S04', 15000, 2, 30000);
-- HD8
INSERT INTO ChiTietHoaDon VALUES ('HD08', 'S06', 120000, 2, 240000);
-- HD9
INSERT INTO ChiTietHoaDon VALUES ('HD09', 'S01', 18000, 3, 54000);
INSERT INTO ChiTietHoaDon VALUES ('HD09', 'S02', 389000, 1, 389000);
INSERT INTO ChiTietHoaDon VALUES ('HD09', 'S05', 25000, 1, 25000);

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
INSERT INTO ChiTietPhieuNhap VALUES ('PN05', 'S01', 15000, 7, 105000);
-- PN06
INSERT INTO ChiTietPhieuNhap VALUES ('PN06', 'S02', 350000, 4, 1400000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN06', 'S03', 150000, 6, 900000);

-- PN07
INSERT INTO ChiTietPhieuNhap VALUES ('PN07', 'S01', 15000, 6, 90000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN07', 'S04', 10000, 8, 80000);

-- PN08
INSERT INTO ChiTietPhieuNhap VALUES ('PN08', 'S02', 350000, 7, 2450000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN08', 'S03', 150000, 8, 1200000);

-- PN09
INSERT INTO ChiTietPhieuNhap VALUES ('PN09', 'S01', 15000, 9, 135000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN09', 'S04', 10000, 6, 60000);

-- PN10
INSERT INTO ChiTietPhieuNhap VALUES ('PN10', 'S02', 350000, 10, 3500000);
INSERT INTO ChiTietPhieuNhap VALUES ('PN10', 'S03', 150000, 7, 1050000);

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
 --Sua
 CREATE PROC SP_ThemTheLoai
    @MaLoai VARCHAR(10),
    @TenLoai NVARCHAR(100)
AS
BEGIN
    INSERT INTO LoaiSach (MaLoai, TenLoai)
    VALUES (@MaLoai, @TenLoai);
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
 --Sua
 CREATE PROC SP_ThemNhanVien
    @HoTen NVARCHAR(100),
    @NgaySinh SMALLDATETIME,
    @GioiTinh NVARCHAR(100),
    @DiaChi NVARCHAR(255),
    @SoDT VARCHAR(11)
AS
BEGIN
    INSERT INTO NhanVien (HoTen, NgaySinh, GioiTinh, DiaChi, SoDT)
    VALUES (@HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDT);
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
 --Sua
 CREATE PROC SP_ThemKhachHang
    @HoTen NVARCHAR(100),
    @NgaySinh SMALLDATETIME,
    @GioiTinh NVARCHAR(100),
    @DiaChi NVARCHAR(255),
    @SoDT VARCHAR(11)
AS
BEGIN
    INSERT INTO KhachHang (HoTen, NgaySinh, GioiTinh, DiaChi, SoDT)
    VALUES (@HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDT);
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
 CREATE PROC SP_ThemCTHD
    @MaSach VARCHAR(10),
    @MaHD VARCHAR(10),
    @DonGia FLOAT,
    @SoLuong INT,
    @TongTien FLOAT
AS
BEGIN
    INSERT INTO ChiTietHoaDon (MaHD, MaSach, GiaBan, SoLuongBan, TongTien)
    VALUES (@MaHD, @MaSach, @DonGia, @SoLuong, @TongTien);
END
GO

 --Xóa chi tiết hóa đơn
 CREATE PROC SP_XoaCTHD
    @MaSach VARCHAR(10),
    @MaHD VARCHAR(10)
AS
BEGIN
    DELETE FROM ChiTietHoaDon
    WHERE MaSach = @MaSach AND MaHD = @MaHD;
END
GO

-----------------------------Bảng ChiTietPhieuNhap-----------------------------
 --Thêm chi tiết phiếu nhập
 CREATE PROC SP_ThemChiTietPhieuNhap
    @MaPN VARCHAR(10),
    @MaSach VARCHAR(10),
    @GiaNhap FLOAT,
    @SoLuongNhap INT,
    @TongTien FLOAT
AS
BEGIN
    INSERT INTO ChiTietPhieuNhap (MaPN, MaSach, GiaNhap, SoLuongNhap, TongTien)
    VALUES (@MaPN, @MaSach, @GiaNhap, @SoLuongNhap, @TongTien);
END
GO

 --Xóa chi tiết phiếu nhập
 CREATE PROC SP_XoaChiTietPhieuNhap
    @MaSach VARCHAR(10),
    @MaPN VARCHAR(10)
AS
BEGIN
    DELETE FROM ChiTietPhieuNhap
    WHERE MaSach = @MaSach AND MaPN = @MaPN;
END
GO
