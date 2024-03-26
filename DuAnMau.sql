create database DuAnMau;
go

use DuAnMau;

create table NhanVien(
	ID int,
	MaNV varchar(20) Primary key NOT NULL,
	Email varchar(50) NOT NULL,
	HoVaTen Nvarchar (50) NOT NULL,
	MatKhau Nvarchar(50) NOT NULL,
	VaiTro tinyint NOT NULL,
	TinhTrang tinyint NOT NULL,
	DiaChi Nvarchar(100) NOT NULL
);

create table Hang(
	MaHang int Primary key,
	MaNV varchar(20) NOT NULL,
	TenHang nvarchar(50) NOT NULL,
	SoLuong int NOT NULL,
	DonGiaNhap Float NOT NULL,
	DonGiaBan Float NOT NULL,
	HinhAnh varchar(400) NOT NULL,
	GhiChu nvarchar(20) NOT NULL
);

CREATE TABLE KhachHang (
    Dienthoai VARCHAR(15) primary key NOT NULL,
    TenKhach NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(100) NOT NULL,
    Phai NVARCHAR(5) NOT NULL,
    MaNV varchar(20) NOT NULL,
);

alter table Hang add constraint fk_Hang_NhanVien foreign key (MaNV) references NhanVien(MaNV);
alter table KhachHang add constraint fk_KhachHang_NhanVien foreign key (MaNV) references NhanVien(MaNV);

-- Thêm dữ liệu mẫu vào bảng NhanVien
INSERT INTO NhanVien (ID, MaNV, Email, HoVaTen, MatKhau, VaiTro, TinhTrang, DiaChi)
VALUES
    (1, 'NV001', 'nv001@example.com', N'Nguyễn Văn Anh', 'NV001', 0, 1, N'018 Nguyễn Trãi, Phường 9, Quận 5, TP.HCM'),
    (2, 'NV002', 'nv002@example.com', N'Trần Thị Bình', 'NV002', 0, 1, N'123 Lê Lợi, Phường 2, Quận 3, TP.HCM'),
    (3, 'NV003', 'nv003@example.com', N'Phạm Văn Cường', 'NV003', 0, 1, N'456 Nguyễn Huệ, Phường 7, Quận 1, TP.HCM'),
    (4, 'NV004', 'nv004@example.com', N'Lê Thị Dung', 'NV004', 0, 1, N'789 Đinh Công Tráng, Phường 11, Quận Bình Thạnh, TP.HCM'),
    (5, 'ADMIN', 'admin@example.com', N'Yunathan Guan', 'ADMIN', 1, 1, N'123 Ngô Đức Kế, Phường Bến Nghế, Quận 1, TP.HCM');
-- set mật khẩu thành chữ thường hết
UPDATE NhanVien
SET MatKhau = LOWER(MatKhau);

	-- Thêm dữ liệu mẫu vào bảng Hang cho Nhân Viên NV004
INSERT INTO Hang (MaHang, MaNV, TenHang, SoLuong, DonGiaNhap, DonGiaBan, HinhAnh, GhiChu)
VALUES
    (1, 'NV004', N'Cupcake Red Velvet Strawberries', 100, 10.0, 15.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh1.jpg', N'Cupcake'),
    (2, 'NV004', N'Cupcake Strawberries', 50, 15.0, 20.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh2.jpg', N'Cupcake'),
    (3, 'NV004', N'Cupcake Strawberries and Lemon', 75, 12.0, 18.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh3.jpg', N'Cupcake'),
    (4, 'NV004', N'Cupcake Dreaming', 60, 20.0, 30.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh4.jpg', N'Cupcake'),
    (5, 'NV004', N'Cupcake Black Magic', 200, 5.0, 10.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh5.jpg', N'Cupcake'),
    (6, 'NV004', N'Cupcake Rosé', 150, 8.0, 12.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh6.jpg', N'Cupcake'),
    (7, 'NV004', N'Cupcake Coffee Awake All Night', 90, 18.0, 25.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh7.jpg', N'Cupcake'),
    (8, 'NV004', N'Tart Black And Red', 120, 13.0, 22.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh8.jpg', N'Tart'),
    (9, 'NV004', N'Tart The Jungle Of Fruits', 80, 22.0, 35.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh9.jpg', N'Tart'),
    (10, 'NV004', N'Tart HongKong', 105, 10.0, 25.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh10.jpg', N'Tart egg '),
	(11, 'NV004', N'Tart VietNam', 85, 10.0, 25.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh9.jpg', N'Tart egg'),
    (12, 'NV004', N'Tart Lemon', 123, 12.0, 28.0, 'E:\FPT\DuAnMauDotNet\Code\PS28709_QuanBichVan\Hinh\hinh10.jpg', N'Tart egg');

	-- Thêm dữ liệu mẫu vào bảng KhachHang với 10 khách hàng có tên và địa chỉ cụ thể
INSERT INTO KhachHang (Dienthoai, TenKhach, DiaChi, Phai, MaNV)
VALUES
    ('0123456789', N'Nguyễn Văn A', N'232 Nguyễn Trãi, Phường 7, Quận 5, TP HCM', N'Nam', 'NV001'),
    ('0987654321', N'Nguyễn Thị Hường', N'233 Hậu Giang, Phường 7, Quận 6, TP HCM', N'Nữ', 'NV002'),
    ('0369852147', N'Lê Văn Cường', N'18 Nguyễn Trãi, Phường 3, Quận 5, TP HCM', N'Nam', 'NV003'),
    ('0905345678', N'Lê Thị Ngọc', N'12 Đinh Công Tráng, Phường 7, Quận Bình Thạnh TP HCM', N'Nữ', 'NV001'),
    ('0777888999', N'Phạm Văn Nam', N'236 Nguyễn Trãi, Phường 3, Quận 5, TP HCM', N'Nam', 'NV002'),
    ('0901234567', N'Phạm Thị Lan', N'34 Quang Trung, Phường 12, Quận Gò Vấp, TP HCM', N'Nữ', 'NV003'),
    ('0954321890', N'Hoàng Thị Dung', N'45 Nguyễn Trãi, Phường 2, Quận 5, TP HCM', N'Nữ', 'NV001'),
    ('0765432198', N'Hoàng Văn Tú', N'222 Cao Lỗ, P7, Q8, TP HCM', N'Nam', 'NV002'),
    ('0923487651', N'Đỗ Thị Thu', N'485 Phạm Hùng, P3, Q8, TP HCM', N'Nữ', 'NV003'),
    ('0856432109', N'Đỗ Văn Quân', N'241 Phạm Thế Hiển, P10, Q8, TP HCM', N'Nam', 'NV001'),
    ('0987666321', N'Nguyễn Thị Thảo', N'48 Lê Lợi, Phường 4, Quận 3, TP HCM', N'Nữ', 'NV002'),
    ('0366782147', N'Nguyễn Đình Anh', N'22 Hoàng Văn Thái, Phường Tân Phú, Quận 7, TP HCM', N'Nam', 'NV003'),
    ('0909545678', N'Nguyễn Văn Bình', N'15 Phạm Hùng, Phường 2, Quận 8, TP HCM', N'Nam', 'NV001'),
    ('0770880999', N'Lê Thị Mai', N'321 Lê Văn Lương, Phường 5, Quận 7, TP HCM', N'Nữ', 'NV002'),
    ('0901212567', N'Lê Đình Quý', N'87 Nguyễn Công Trứ, Phường 6, Quận 3, TP HCM', N'Nam', 'NV003'),
    ('0954545490', N'Phạm Thị Hoa', N'123 Phan Văn Khỏe, Phường Tân Định, Quận 1, TP HCM', N'Nữ', 'NV001'),
    ('0765430657', N'Phạm Văn Hùng', N'56 Cao Thắng, Phường 3, Quận 3, TP HCM', N'Nam', 'NV002'),
    ('0906487651', N'Hoàng Thị Mai', N'69 Bùi Thị Xuân, Phường 1, Quận Tân Bình, TP HCM', N'Nữ', 'NV003'),
    ('0850892109', N'Lê Văn Tài', N'32 Phan Kế Bính, Phường Đa Kao, Quận 1, TP HCM', N'Nam', 'NV001'),
    ('0903456789', N'Phạm Thị Thanh', N'57 Đinh Công Tráng, Phường Tân Định, Quận 1, TP HCM', N'Nữ', 'NV001');


	select * from KhachHang;