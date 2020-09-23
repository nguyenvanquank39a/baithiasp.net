create database SinhVien
go

use SinhVien
go

create table TaiKhoan
(
	ID int identity(1,1) primary key,
	TenTaiKhoan varchar(50),
	MatKhau varchar(50)
)




create table ThongTin
(
	ID int identity(1,1),
	MaSv int primary key,
	HoTen nvarchar(100),
	NamSinh datetime,
	SoDienThoaiSV char(11),
	Lop nvarchar(70),
	Khoa nvarchar(70),
	HoTenChuTro nvarchar(100),
	DiaChiNoiCuTru nvarchar(100),
	NgayDangKy datetime,
	NgayHuy datetime

)