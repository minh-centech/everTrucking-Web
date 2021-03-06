/*---------------
create table ctKeHoachVanTai
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	IDDanhMucChungTuTrangThai		bigint not null,
	So								nvarchar(35) not null,
	NgayLap							datetime not null,
	--
	IDDanhMucSale					bigint not null,
	IDDanhMucKhachHang				bigint not null,
	LoaiHinh						tinyint not null, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
	LoaiHang						tinyint not null, --Loại hàng: 1: FCL, 2: LCL
	IDDanhMucHangTau				bigint,
	IDDanhMucDiaDiemNangCont		bigint,
	NgayNangCont					datetime,
	IDDanhMucDiaDiemHaCont			bigint,
	NgayHaCont						datetime,
	SoLuongCont20					int,
	SoCont20						nvarchar(512),
	SoLuongCont40					int,
	SoCont40						nvarchar(512),
	SoLuongCont45					int,
	SoCont45						nvarchar(512),
	SoLuongContOpenTop				int,
	SoContOpenTop					nvarchar(512),
	SoLuongContFlatRack				int,
	SoContFlatRack					nvarchar(512),
	IDDanhMucDiaDiemDongHang		bigint,
	NgayDongHang					datetime,
	IDDanhMucDiaDiemTraHang			bigint,
	NgayTraHang						datetime,
	KhoiLuong						float,			--Nếu là hàng rời
	NguoiGiaoNhan					nvarchar(128),
	SoDienThoaiGiaoNhan				nvarchar(128),
	--
	GhiChu							nvarchar(max),
	Huy								bit,
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	IDDanhMucNguoiSuDungDelete		bigint,
	DeleteDate						datetime,
	constraint PK_ctKeHoachVanTai primary key (ID),
	constraint ctKeHoachVanTai_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctKeHoachVanTai foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctKeHoachVanTai foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint DanhMucChungTuTrangThai_ctKeHoachVanTai foreign key (IDDanhMucChungTuTrangThai) references DanhMucChungTuTrangThai(ID),
	constraint So_ctKeHoachVanTai unique (So),
	--
	constraint DanhMucSale_ctKeHoachVanTai foreign key (IDDanhMucSale) references DanhMucDoiTuong(ID),
	constraint DanhMucKhachHang_ctKeHoachVanTai foreign key (IDDanhMucKhachHang) references DanhMucKhachHang(ID),
	
	constraint IDDanhMucHangTau_ctKeHoachVanTai foreign key (IDDanhMucHangTau) references DanhMucDoiTuong(ID),
	constraint DiaDiemNangCont_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemNangCont) references DanhMucDiaDiemGiaoNhan(ID),
	constraint DiaDiemHaCont_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemHaCont) references DanhMucDiaDiemGiaoNhan(ID),
	constraint DiaDiemDongHang_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemDongHang) references DanhMucDiaDiemGiaoNhan(ID),
	constraint DiaDiemTraHang_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemTraHang) references DanhMucDiaDiemGiaoNhan(ID),
	
	--
	constraint UserCreate_ctKeHoachVanTai foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctKeHoachVanTai foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID),
	constraint UserDelete_ctKeHoachVanTai foreign key (IDDanhMucNguoiSuDungDelete) references DanhMucNguoiSuDung(ID)
)
create table ctKeHoachVanTaiChiTietSoContainer
(
	ID					bigint not null,
	IDDanhMucDonVi		bigint not null,
	IDDanhMucChungTu	bigint not null,
	IDChungTu			bigint not null,
	SoContainer			nvarchar(35) not null,
	constraint PK_ctKeHoachVanTaiChiTietSoContainer primary key (ID),
	constraint ctKeHoachVanTaiChiTietSoContainer_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctKeHoachVanTaiChiTietSoContainer foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctKeHoachVanTaiChiTietSoContainer foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint ChungTu_ctKeHoachVanTaiChiTietSoContainer foreign key (IDChungTu) references ctKeHoachVanTai(ID)
)
---------------*/
create procedure List_ctKeHoachVanTaiChiTietSoContainer
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint = null
as
begin
	set nocount on;
	--
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		a.So,
		a.NgayLap,
		--
		a.IDDanhMucSale,
		Sale.Ma MaDanhMucSale,
		a.IDDanhMucKhachHang,
		KhachHang.Ma MaDanhMucKhachHang,
		KhachHang.Ten TenDanhMucKhachHang,
		a.LoaiHinh, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
		case when a.LoaiHinh = 1 then N'Nhập' when a.LoaiHinh = 2 then N'Xuất' else N'Nội địa' end TenLoaiHinh,
		a.LoaiHang, --Loại hàng: 1: FCL, 2: LCL
		case when a.LoaiHang = 1 then N'FCL' else N'LCL' end TenLoaiHang,
		a.IDDanhMucHangTau,
		HangTau.Ma MaDanhMucHangTau,
		a.IDDanhMucDiaDiemNangCont,
		DiaDiemNangCont.Ma MaDanhMucDiaDiemNangCont,
		a.NgayNangCont,
		a.IDDanhMucDiaDiemHaCont,
		DiaDiemHaCont.Ma MaDanhMucDiaDiemHaCont,
		a.NgayHaCont,
		a.SoLuongCont20,
		a.SoCont20,
		a.SoLuongCont40,
		a.SoCont40,
		a.SoLuongCont45,
		a.SoCont45,
		a.SoLuongContOpenTop,
		a.SoContOpenTop,
		a.SoLuongContFlatRack,
		a.SoContFlatRack,
		a.IDDanhMucDiaDiemDongHang,
		DiaDiemDongHang.Ma MaDanhMucDiaDiemDongHang,
		a.NgayDongHang,
		a.IDDanhMucDiaDiemTraHang,
		DiaDiemTraHang.Ma MaDanhMucDiaDiemTraHang,
		a.NgayTraHang,
		a.KhoiLuong,			--Nếu là hàng rời
		a.NguoiGiaoNhan,
		a.SoDienThoaiGiaoNhan,
		--
		a.GhiChu,
		a.Huy,
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ma MaDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ma MaDanhMucNguoiSuDungEdit,
		a.EditDate,
		a.IDDanhMucNguoiSuDungDelete,
		UserDelete.Ma MaDanhMucNguoiSuDungDelete,
		a.DeleteDate
	from ctKeHoachVanTai a
		left join DanhMucDoiTuong Sale on a.IDDanhMucSale = Sale.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucDoiTuong HangTau on a.IDDanhMucHangTau = HangTau.ID

		left join DanhMucDiaDiemGiaoNhan DiaDiemNangCont on a.IDDanhMucDiaDiemNangCont = DiaDiemNangCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemHaCont on a.IDDanhMucDiaDiemHaCont = DiaDiemHaCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemDongHang on a.IDDanhMucDiaDiemDongHang = DiaDiemDongHang.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemTraHang on a.IDDanhMucDiaDiemTraHang = DiaDiemTraHang.ID

		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
		left join DanhMucNguoiSuDung UserDelete on a.IDDanhMucNguoiSuDungDelete = UserDelete.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.ID = @ID;

	select
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDChungTu,
		a.SoContainer
	from ctKeHoachVanTaiChiTietSoContainer a
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.IDChungTu = @ID;
end;
go
------------------
create procedure Insert_ctKeHoachVanTaiChiTietSoContainer
(
	@ID					bigint = null output,
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@IDChungTu			bigint,
	@SoContainer		nvarchar(35)
)
as
begin
	set nocount on;
	declare @Err int, @ErrMsg nvarchar(max);
	declare @NgayCapNhat datetime;
	select @NgayCapNhat = GETDATE()
	begin tran
	begin try
	--Đánh số chứng từ
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctKeHoachVanTaiChiTietSoContainer';
	--
	insert	into ctKeHoachVanTaiChiTietSoContainer
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		IDChungTu,
		SoContainer
	)
	values
	(
		@ID,
		@IDDanhMucDonVi,
		@IDDanhMucChungTu,
		@IDChungTu,
		@SoContainer
	);
	commit tran
	end try
	begin catch
		rollback
		select @ErrMsg = error_message();
		raiserror(@ErrMsg, 16, 1);
	end catch
	set @Err = @@Error;
	return @Err;
end
go
------------------
create procedure Update_ctKeHoachVanTaiChiTietSoContainer
(
	@ID					bigint,
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@IDChungTu			bigint,
	@SoContainer		nvarchar(35)
)
as
begin
	set nocount on;
	declare @Err int;
	begin tran
	begin try
	update ctKeHoachVanTaiChiTietSoContainer
		set
			SoContainer = @SoContainer
		where ID = @ID;
	commit tran
	end try
	begin catch
		rollback
		declare @ErrMsg nvarchar(max)
		select @ErrMsg = error_message()
		raiserror(@ErrMsg, 16, 1)
	end catch;
end
go
------------------
create procedure Delete_ctKeHoachVanTaiChiTietSoContainer
(
	@ID	bigint
)
as
begin
	set nocount on;
	declare @Err int;

	begin tran
	begin try
	delete from ctKeHoachVanTaiChiTietSoContainer where ID = @ID;
	delete from AutoID where ID = @ID;
	commit tran
	end try
	begin catch
		rollback
		declare @ErrMsg nvarchar(max)
		select @ErrMsg = error_message()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
