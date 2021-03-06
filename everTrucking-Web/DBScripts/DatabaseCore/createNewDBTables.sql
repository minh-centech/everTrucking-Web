/*
create table AutoID
(
	ID				bigint identity(1, 1) not null,
	TenBangDuLieu	nvarchar(128) not null,
	constraint PK_AutoID primary key (ID)
)
go
--------------------
create table DanhMucDonVi
(
	ID			bigint			not null,
	Ma			nvarchar(128)	not null,
	Ten			nvarchar(255)	not null,
	CreateDate	datetime		not null,
	EditDate	datetime,
	constraint	PK_DanhMucDonVi primary key (ID),
	constraint	DanhMucDonVi_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucDonVi unique(Ma)
)
go
--------------------
create table DanhMucChungTu
(
	ID			bigint			not null,
	Ma			nvarchar(128)	not null,
	Ten			nvarchar(255)	not null,
	KiHieu		nvarchar(20)	not null,
	LoaiManHinh	nvarchar(128)	not null,
	CreateDate	datetime		not null,
	EditDate	datetime,
	constraint	PK_DanhMucChungTu primary key (ID),
	constraint	DanhMucChungTu_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucChungTu unique(Ma)
)
go
create table DanhMucChungTuTrangThai
(
	ID					bigint			not null,
	IDDanhMucChungTu	bigint			not null,
	Ma					nvarchar(128)	not null,
	Ten					nvarchar(255)	not null,
	HachToan			bit,
	Sua					bit,
	Xoa					bit,
	CreateDate			datetime		not null,
	EditDate			datetime,
	constraint	PK_DanhMucChungTuTrangThai primary key (ID),
	constraint	DanhMucChungTuTrangThai_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucChungTuTrangThai_DanhMucChungTu foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint	Ma_DanhMucChungTuTrangThai unique(Ma)
)
go
create table DanhMucChungTuIn
(
	ID					bigint			not null,
	IDDanhMucChungTu	bigint			not null,
	Ma					nvarchar(128)	not null,
	Ten					nvarchar(255)	not null,
	ListProcedureName	nvarchar(255)	not null,
	FileMauIn			nvarchar(255)	not null,
	SoLien				tinyint			not null,
	PrintPreview		bit,
	CreateDate			datetime		not null,
	EditDate			datetime,
	constraint	PK_DanhMucChungTuIn primary key (ID),
	constraint	DanhMucChungTuIn_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucChungTuIn_DanhMucChungTu foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint	Ma_DanhMucChungTuIn unique(Ma)
)
go
create table DanhMucChungTuQuyTrinh
(
	ID							bigint		not null,
	IDDanhMucChungTu			bigint		not null,
	IDDanhMucChungTuQuyTrinh	bigint		not null,
	CreateDate					datetime	not null,
	EditDate					datetime,
	constraint	PK_DanhMucChungTuQuyTrinh primary key (ID),
	constraint	DanhMucChungTuQuyTrinh_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucChungTuQuyTrinh_DanhMucChungTu foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint	DanhMucChungTuQuyTrinh_DanhMucChungTuQuyTrinh foreign key (IDDanhMucChungTuQuyTrinh) references DanhMucChungTu(ID)
)
go
--------------------
create table DanhMucNhomBaoCao
(
	ID			bigint			not null,
	Ma			nvarchar(128)	not null,
	Ten			nvarchar(255)	not null,
	CreateDate	datetime		not null,
	EditDate	datetime,
	constraint	PK_DanhMucNhomBaoCao primary key (ID),
	constraint	DanhMucNhomBaoCao_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucNhomBaoCao unique(Ma)
)
go
create table DanhMucBaoCao
(
	ID							bigint			not null,
	Ma							nvarchar(128)	not null,
	Ten							nvarchar(255)	not null,
	ReportProcedureName			nvarchar(255)	not null,
	FixedColumnList				nvarchar(255),
	KhoGiay						smallint		not null,
	HuongIn						smallint		not null,
	ChucDanhKy					nvarchar(255),
	DienGiaiKy					nvarchar(255),
	TenNguoiKy					nvarchar(255),
	ThamChieuChungTu			bit,
	IDDanhMucBaoCaoThamChieu	bigint,
	IDDanhMucNhomBaoCao			bigint			not null,
	FileExcelMau				nvarchar(max), --File Excel export
	SheetExcelMau				nvarchar(255), --Sheet Excel export
	SoDongBatDau				int, -- Số dòng bắt đầu export trong file excel
	CreateDate					datetime		not null,
	EditDate					datetime,
	constraint	PK_DanhMucBaoCao primary key (ID),
	constraint	DanhMucBaoCao_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucBaoCao unique(Ma),
	constraint	DanhMucBaoCaoThamChieu_DanhMucBaoCao foreign key (IDDanhMucBaoCaoThamChieu) references DanhMucBaoCao(ID),
	constraint	DanhMucNhomBaoCao_DanhMucBaoCao foreign key (IDDanhMucNhomBaoCao) references DanhMucNhomBaoCao(ID)
)
go
create table DanhMucBaoCaoCot
(
	ID				bigint			not null,
	IDDanhMucBaoCao	bigint			not null,
	Ma				nvarchar(128)	not null,
	Ten				nvarchar(255)	not null,
	ColumnWidth		float			not null,
	HeaderHeight	float,
	TenNhomCot		nvarchar(255),
	ThuTu			tinyint,
	TenCotExcel		nvarchar(2),
	KieuDuLieu		tinyint not null, --Kiểu dữ liệu cột: 1: Text, 2: Ngày tháng, 3: Số nguyên, 4: Số thực, 5: Check
	CreateDate		datetime		not null,
	EditDate		datetime,
	constraint	PK_DanhMucBaoCaoCot primary key (ID),
	constraint	DanhMucBaoCaoCot_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucBaoCaoCot_DanhMucBaoCao foreign key (IDDanhMucBaoCao) references DanhMucBaoCao(ID),
)
go
--------------------
create table DanhMucLoaiDoiTuong
(
	ID				bigint			not null,
	Ma				nvarchar(128)	not null,
	Ten				nvarchar(255)	not null,
	TenBangDuLieu	nvarchar(128)	not null,
	CreateDate		datetime		not null,
	EditDate		datetime,
	constraint		PK_DanhMucLoaiDoiTuong primary key (ID),
	constraint		DanhMucLoaiDoiTuong_AutoID foreign key (ID) references AutoID(ID),
	constraint		Ma_DanhMucLoaiDoiTuong unique(Ma)
)
go
--------------------
create table DanhMucPhanQuyen
(
	ID			bigint			not null,
	Ma			nvarchar(128)	not null,
	Ten			nvarchar(255)	not null,
	CreateDate	datetime		not null,
	EditDate	datetime,
	constraint	PK_DanhMucPhanQuyen primary key (ID),
	constraint	DanhMucPhanQuyen_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucPhanQuyen unique(Ma)
)
go
create table DanhMucPhanQuyenDonVi
(
	ID					bigint		not null,
	IDDanhMucPhanQuyen	bigint		not null,
	IDDanhMucDonVi		bigint		not null,
	Xem					bit,
	CreateDate			datetime	not null,
	EditDate			datetime,
	constraint	PK_DanhMucPhanQuyenDonVi primary key (ID),
	constraint	DanhMucPhanQuyenDonVi_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucPhanQuyen_DanhMucPhanQuyenDonVi foreign key (IDDanhMucPhanQuyen) references DanhMucPhanQuyen(ID),
	constraint	DanhMucDonVi_DanhMucPhanQuyenDonVi foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID)
)
go
create table DanhMucPhanQuyenLoaiDoiTuong
(
	ID						bigint		not null,
	IDDanhMucPhanQuyen		bigint		not null,
	IDDanhMucLoaiDoiTuong	bigint		not null,
	Xem						bit,
	Them					bit,
	Sua						bit,
	Xoa						bit,
	CreateDate				datetime	not null,
	EditDate				datetime,
	constraint	PK_DanhMucPhanQuyenLoaiDoiTuong primary key (ID),
	constraint	DanhMucPhanQuyenLoaiDoiTuong_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucPhanQuyen_DanhMucPhanQuyenLoaiDoiTuong foreign key (IDDanhMucPhanQuyen) references DanhMucPhanQuyen(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucPhanQuyenLoaiDoiTuong foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID)
)
go
create table DanhMucPhanQuyenChungTu
(
	ID					bigint		not null,
	IDDanhMucPhanQuyen	bigint		not null,
	IDDanhMucChungTu	bigint		not null,
	Xem					bit,
	Them				bit,
	Sua					bit,
	Xoa					bit,
	CreateDate			datetime	not null,
	EditDate			datetime,
	constraint	PK_DanhMucPhanQuyenChungTu primary key (ID),
	constraint	DanhMucPhanQuyenChungTu_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucPhanQuyen_DanhMucPhanQuyenChungTu foreign key (IDDanhMucPhanQuyen) references DanhMucPhanQuyen(ID),
	constraint	DanhMucChungTu_DanhMucPhanQuyenChungTu foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID)
)
go
create table DanhMucPhanQuyenBaoCao
(
	ID					bigint		not null,
	IDDanhMucPhanQuyen	bigint		not null,
	IDDanhMucBaoCao		bigint		not null,
	Xem					bit,
	CreateDate			datetime	not null,
	EditDate			datetime,
	constraint	PK_DanhMucPhanQuyenBaoCao primary key (ID),
	constraint	DanhMucPhanQuyenBaoCao_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucPhanQuyen_DanhMucPhanQuyenBaoCao foreign key (IDDanhMucPhanQuyen) references DanhMucPhanQuyen(ID),
	constraint	DanhMucBaoCao_DanhMucPhanQuyenBaoCao foreign key (IDDanhMucBaoCao) references DanhMucBaoCao(ID)
)
go
--------------------
create table DanhMucNguoiSuDung
(
	ID					bigint			not null,
	IDDanhMucPhanQuyen	bigint			not null,
	Ma					nvarchar(128)	not null,
	Ten					nvarchar(255)	not null,
	Password			nvarchar(128)	not null,
	isAdmin				bit,
	CreateDate			datetime		not null,
	EditDate			datetime,
	constraint	PK_DanhMucNguoiSuDung primary key (ID),
	constraint	DanhMucNguoiSuDung_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucNguoiSuDung unique(Ma),
	constraint	DanhMucPhanQuyen_DanhMucNguoiSuDung foreign key (IDDanhMucPhanQuyen) references DanhMucPhanQuyen(ID)
)
go
--------------------
create table NhatKyDuLieu
(
	ID						bigint identity(1, 1) not null,
	Ngay					date not null,
	Gio						time not null,
	IDDanhMucNguoiSuDung	bigint,
	MaDanhMucNguoiSuDung	nvarchar(128) not null,
	TenDanhMucNguoiSuDung	nvarchar(255) not null,
	AutoID					bigint not null,	--ID bản ghi sửa
	AutoIDChungTu			bigint,				--ID chứng từ 
	AutoIDChungTuChiTiet	bigint,				--ID chứng từ chi tiết
	ThaoTac					nvarchar(128) not null, 
	TenBangDuLieu			nvarchar(255) not null,
	DuLieu					nvarchar(max) not null,
	DuLieuGoc				nvarchar(max),
	constraint	PK_NhatKyDuLieu primary key (ID),
	constraint	DanhMucNguoiSuDung_NhatKyDuLieu foreign key (IDDanhMucNguoiSuDung) references DanhMucNguoiSuDung(ID)
)
go
--------------------
create table DanhMucDoiTuong
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	Ma							nvarchar(128)	not null,
	Ten							nvarchar(255)	not null,
	GhiChu						nvarchar(max),
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucDoiTuong primary key (ID),
	constraint	DanhMucDoiTuong_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucDonVi_DanhMucDoiTuong foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucDoiTuong foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	constraint	DanhMucNguoiSuDungCreate_DanhMucDoiTuong foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucDoiTuong foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
--------------------
create table DanhMucMenu
(
	ID				bigint			not null,
	Ma				nvarchar(128)	not null,
	Ten				nvarchar(255)	not null,
	ThuTuHienThi	int,
	CreateDate		datetime		not null,
	EditDate		datetime,
	constraint		PK_DanhMucMenu primary key (ID),
	constraint		DanhMucMenu_AutoID foreign key (ID) references AutoID(ID),
	constraint		Ma_DanhMucMenu unique(Ma)
)
go
create table DanhMucMenuLoaiDoiTuong
(
	ID						bigint			not null,
	IDDanhMucMenu			bigint			not null,
	IDDanhMucLoaiDoiTuong	bigint			not null,
	NoiDungHienThi			nvarchar(255)	not null,
	PhanCachNhom			bit,
	ThuTuHienThi			int,
	CreateDate				datetime		not null,
	EditDate				datetime,
	constraint	PK_DanhMucMenuLoaiDoiTuong primary key (ID),
	constraint	DanhMucMenuLoaiDoiTuong_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucMenu_DanhMucMenuLoaiDoiTuong foreign key (IDDanhMucMenu) references DanhMucMenu(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucMenuLoaiDoiTuong foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID)
)
go
create table DanhMucMenuChungTu
(
	ID					bigint			not null,
	IDDanhMucMenu		bigint			not null,
	IDDanhMucChungTu	bigint			not null,
	NoiDungHienThi		nvarchar(255)	not null,
	PhanCachNhom		bit,
	ThuTuHienThi		int,
	CreateDate			datetime		not null,
	EditDate			datetime,
	constraint	PK_DanhMucMenuChungTu primary key (ID),
	constraint	DanhMucMenuChungTu_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucMenu_DanhMucMenuChungTu foreign key (IDDanhMucMenu) references DanhMucMenu(ID),
	constraint	DanhMucChungTu_DanhMucMenuChungTu foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID)
)
go
create table DanhMucMenuBaoCao
(
	ID					bigint			not null,
	IDDanhMucMenu		bigint			not null,
	IDDanhMucBaoCao		bigint			not null,
	NoiDungHienThi		nvarchar(255)	not null,
	PhanCachNhom		bit,
	ThuTuHienThi		int,
	CreateDate			datetime		not null,
	EditDate			datetime,
	constraint	PK_DanhMucMenuBaoCao primary key (ID),
	constraint	DanhMucMenuBaoCao_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucMenu_DanhMucMenuBaoCao foreign key (IDDanhMucMenu) references DanhMucMenu(ID),
	constraint	DanhMucBaoCao_DanhMucMenuBaoCao foreign key (IDDanhMucBaoCao) references DanhMucBaoCao(ID)
)
go
--------------------
create table DanhMucTuDien
(
	ID			bigint			not null,
	Ma			nvarchar(128)	not null,
	Ten			nvarchar(255)	not null,
	CreateDate	datetime		not null,
	EditDate	datetime,
	constraint	PK_DanhMucTuDien primary key (ID),
	constraint	DanhMucTuDien_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucTuDien unique(Ma)
)
go
--------------------
create table DanhMucThamSoHeThong
(
	ID				bigint			not null,
	IDDanhMucDonVi	bigint			not null,
	Ma				nvarchar(128)	not null,
	Ten				nvarchar(255)	not null,
	GiaTri			nvarchar(max)	not null,
	GhiChu			nvarchar(255),
	CreateDate		datetime		not null,
	EditDate		datetime,
	constraint	PK_DanhMucThamSoHeThong primary key (ID),
	constraint	DanhMucThamSoHeThong_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucDonVi_DanhMucThamSoHeThong foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	Ma_DanhMucThamSoHeThong unique(Ma)
)
go
--------------------
--------------------
--------------------
--------------------
--------------------
--------------------
--------------------
--------------------
--------------------
--------------------
--------------------
*/


