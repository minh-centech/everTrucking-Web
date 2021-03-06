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
	IDDanhMucLoaiContainer			bigint,
	SoLuongContainer				int,
	SoContainer						nvarchar(512),
	KhoiLuong						float,
	IDDanhMucDiaDiemNangCont		bigint,
	NgayNangCont					datetime,
	IDDanhMucDiaDiemHaCont			bigint,
	NgayHaCont						datetime,
	IDDanhMucDiaDiemGiaoNhan		bigint,
	NgayGiaoNhan					datetime,
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
	constraint LoaiContainer_ctKeHoachVanTai foreign key (IDDanhMucLoaiContainer) references DanhMucDoiTuong(ID),
	constraint DiaDiemNangCont_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemNangCont) references DanhMucDiaDiemGiaoNhan(ID),
	constraint DiaDiemHaCont_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemHaCont) references DanhMucDiaDiemGiaoNhan(ID),
	constraint DiaDiemGiaoNhan_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemGiaoNhan) references DanhMucDiaDiemGiaoNhan(ID),
	--
	constraint UserCreate_ctKeHoachVanTai foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctKeHoachVanTai foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID),
	constraint UserDelete_ctKeHoachVanTai foreign key (IDDanhMucNguoiSuDungDelete) references DanhMucNguoiSuDung(ID)
)
---------------*/
alter procedure List_ctKeHoachVanTai_Display
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@TuNgay				date,
	@DenNgay			date,
	@IDDanhMucKhachHang	bigint = null,
	@LoaiHinh			tinyint = null,
	@LoaiHang			tinyint = null,
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
		convert(nvarchar(10), a.NgayLap, 103) NgayLap,
		--
		a.IDDanhMucSale,
		Sale.Ten TenDanhMucSale,
		a.IDDanhMucKhachHang,
		KhachHang.Ma MaDanhMucKhachHang,
		KhachHang.Ten TenDanhMucKhachHang,
		a.LoaiHinh, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
		case when a.LoaiHinh = 1 then N'Nhập' when a.LoaiHinh = 2 then N'Xuất' else N'Nội địa' end TenLoaiHinh,
		a.LoaiHang, --Loại hàng: 1: FCL, 2: LCL
		case when a.LoaiHang = 1 then N'FCL' else N'LCL' end TenLoaiHang,
		a.IDDanhMucHangTau,
		HangTau.Ma MaDanhMucHangTau,
		HangTau.Ten TenDanhMucHangTau,
		a.IDDanhMucLoaiContainer,
		LoaiContainer.Ma MaDanhMucLoaiContainer,
		a.SoLuongContainer,
		a.SoContainer,
		a.KhoiLuong,
		a.IDDanhMucDiaDiemNangCont,
		DiaDiemNangCont.Ma MaDanhMucDiaDiemNangCont,
		DiaDiemNangCont.Ten TenDanhMucDiaDiemNangCont,
		convert(nvarchar(10), a.NgayNangCont, 103) NgayNangCont,
		a.IDDanhMucDiaDiemHaCont,
		DiaDiemHaCont.Ma MaDanhMucDiaDiemHaCont,
		DiaDiemHaCont.Ten TenDanhMucDiaDiemHaCont,
		convert(nvarchar(10), a.NgayHaCont, 103) NgayHaCont,
		a.IDDanhMucDiaDiemGiaoNhan,
		DiaDiemGiaoNhan.Ma MaDanhMucDiaDiemGiaoNhan,
		DiaDiemGiaoNhan.Ten TenDanhMucDiaDiemGiaoNhan,
		convert(nvarchar(10), a.NgayGiaoNhan, 103) NgayGiaoNhan,
		a.NguoiGiaoNhan,
		a.SoDienThoaiGiaoNhan,
		--
		a.GhiChu,
		a.Huy,
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ten TenDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ten TenDanhMucNguoiSuDungEdit,
		a.EditDate,
		a.IDDanhMucNguoiSuDungDelete,
		UserDelete.Ten TenDanhMucNguoiSuDungDelete,
		a.DeleteDate
	from ctKeHoachVanTai a
		left join DanhMucDoiTuong Sale on a.IDDanhMucSale = Sale.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucDoiTuong HangTau on a.IDDanhMucHangTau = HangTau.ID
		left join DanhMucDoiTuong LoaiContainer on a.IDDanhMucLoaiContainer = LoaiContainer.ID

		left join DanhMucDiaDiemGiaoNhan DiaDiemNangCont on a.IDDanhMucDiaDiemNangCont = DiaDiemNangCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemHaCont on a.IDDanhMucDiaDiemHaCont = DiaDiemHaCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemGiaoNhan on a.IDDanhMucDiaDiemGiaoNhan = DiaDiemGiaoNhan.ID

		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
		left join DanhMucNguoiSuDung UserDelete on a.IDDanhMucNguoiSuDungDelete = UserDelete.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu
		and cast(a.NgayLap as date) >= @TuNgay
		and cast(a.NgayLap as date) <= @DenNgay
		and case when @ID is not null then a.ID else -1 end = isnull(@ID, -1)
		and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = isnull(@IDDanhMucKhachHang, -1)
		and case when @LoaiHinh <> 0 then a.LoaiHinh else -1 end = case when @LoaiHinh = 0 then -1 else @LoaiHinh end
		and case when @LoaiHang <> 0 then a.LoaiHang else -1 end = case when @LoaiHang = 0 then -1 else @LoaiHang end
		and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = isnull(@IDDanhMucKhachHang, -1)
	order by a.NgayLap;
end;
go
---------------
alter procedure List_ctKeHoachVanTai
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
		Sale.Ten TenDanhMucSale,
		a.IDDanhMucKhachHang,
		KhachHang.Ma MaDanhMucKhachHang,
		KhachHang.Ten TenDanhMucKhachHang,
		a.LoaiHinh, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
		case when a.LoaiHinh = 1 then N'Nhập' when a.LoaiHinh = 2 then N'Xuất' else N'Nội địa' end TenLoaiHinh,
		a.LoaiHang, --Loại hàng: 1: FCL, 2: LCL
		case when a.LoaiHang = 1 then N'FCL' else N'LCL' end TenLoaiHang,
		a.IDDanhMucHangTau,
		HangTau.Ma MaDanhMucHangTau,
		HangTau.Ten TenDanhMucHangTau,
		a.IDDanhMucLoaiContainer,
		LoaiContainer.Ma MaDanhMucLoaiContainer,
		a.SoLuongContainer,
		a.SoContainer,
		a.KhoiLuong,
		a.IDDanhMucDiaDiemNangCont,
		DiaDiemNangCont.Ma MaDanhMucDiaDiemNangCont,
		DiaDiemNangCont.Ten TenDanhMucDiaDiemNangCont,
		a.NgayNangCont,
		a.IDDanhMucDiaDiemHaCont,
		DiaDiemHaCont.Ma MaDanhMucDiaDiemHaCont,
		DiaDiemHaCont.Ten TenDanhMucDiaDiemHaCont,
		a.NgayHaCont,
		a.IDDanhMucDiaDiemGiaoNhan,
		DiaDiemGiaoNhan.Ma MaDanhMucDiaDiemGiaoNhan,
		DiaDiemGiaoNhan.Ten TenDanhMucDiaDiemGiaoNhan,
		a.NgayGiaoNhan,
		a.NguoiGiaoNhan,
		a.SoDienThoaiGiaoNhan,
		--
		a.GhiChu,
		a.Huy,
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ten TenDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ten TenDanhMucNguoiSuDungEdit,
		a.EditDate,
		a.IDDanhMucNguoiSuDungDelete,
		UserDelete.Ten TenDanhMucNguoiSuDungDelete,
		a.DeleteDate
	from ctKeHoachVanTai a
		left join DanhMucDoiTuong Sale on a.IDDanhMucSale = Sale.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucDoiTuong HangTau on a.IDDanhMucHangTau = HangTau.ID
		left join DanhMucDoiTuong LoaiContainer on a.IDDanhMucLoaiContainer = LoaiContainer.ID

		left join DanhMucDiaDiemGiaoNhan DiaDiemNangCont on a.IDDanhMucDiaDiemNangCont = DiaDiemNangCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemHaCont on a.IDDanhMucDiaDiemHaCont = DiaDiemHaCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemGiaoNhan on a.IDDanhMucDiaDiemGiaoNhan = DiaDiemGiaoNhan.ID

		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
		left join DanhMucNguoiSuDung UserDelete on a.IDDanhMucNguoiSuDungDelete = UserDelete.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.ID = @ID;
end;
go
------------------
alter procedure Insert_ctKeHoachVanTai
(
	@ID								bigint = null output,
	@IDDanhMucDonVi					bigint,
	@IDDanhMucChungTu				bigint,
	@IDDanhMucChungTuTrangThai		bigint,
	@So								nvarchar(35) = null output,
	@NgayLap						datetime,
	--
	@IDDanhMucSale					bigint,
	@IDDanhMucKhachHang				bigint,
	@LoaiHinh						tinyint, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
	@LoaiHang						tinyint, --Loại hàng: 1: FCL, 2: LCL
	@IDDanhMucHangTau				bigint = null,
	@IDDanhMucLoaiContainer			bigint = null,
	@SoLuongContainer				int = null,
	@SoContainer					nvarchar(512) = null,
	@KhoiLuong						float = null,
	@IDDanhMucDiaDiemNangCont		bigint = null,
	@NgayNangCont					datetime = null,
	@IDDanhMucDiaDiemHaCont			bigint = null,
	@NgayHaCont						datetime = null,
	@IDDanhMucDiaDiemGiaoNhan		bigint = null,
	@NgayGiaoNhan					datetime = null,
	@NguoiGiaoNhan					nvarchar(128) = null,
	@SoDienThoaiGiaoNhan			nvarchar(128) = null,
	@GhiChu							nvarchar(max) = null,
	--
	@IDDanhMucNguoiSuDungCreate		bigint
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
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctKeHoachVanTai';
	declare @KyHieu nvarchar(20), @ctCount int, @ThuTu nvarchar(5);
	select @KyHieu = KiHieu from DanhMucChungTu where ID = @IDDanhMucChungTu;
	select @ctCount = ISNULL(MAX(CAST(RIGHT(SO, 5) AS INT)), 0) + 1 from ctKeHoachVanTai; -- where cast(NgayLap as date) = cast(@NgayLap as date);
	set @ThuTu = RIGHT('00000'+ISNULL(cast(@ctCount as nvarchar(5)),''),5);
	--set @So = @KyHieu + CONVERT(VARCHAR(8), @NgayLap, 112) + '-' + @ThuTu;
	set @So = @KyHieu + @ThuTu;
	--
	insert	into ctKeHoachVanTai
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		IDDanhMucChungTuTrangThai,
		So,
		NgayLap,
		--
		IDDanhMucSale,
		IDDanhMucKhachHang,
		LoaiHinh,
		LoaiHang,
		IDDanhMucHangTau,
		IDDanhMucLoaiContainer,
		SoLuongContainer,
		SoContainer,
		KhoiLuong,
		IDDanhMucDiaDiemNangCont,
		NgayNangCont,
		IDDanhMucDiaDiemHaCont,
		NgayHaCont,
		IDDanhMucDiaDiemGiaoNhan,
		NgayGiaoNhan,
		NguoiGiaoNhan,
		SoDienThoaiGiaoNhan,
		GhiChu,
		--
		IDDanhMucNguoiSuDungCreate,
		CreateDate
	)
	values
	(
		@ID,
		@IDDanhMucDonVi,
		@IDDanhMucChungTu,
		@IDDanhMucChungTuTrangThai,
		@So,
		@NgayLap,
		--
		@IDDanhMucSale,
		@IDDanhMucKhachHang,
		@LoaiHinh,
		@LoaiHang,
		@IDDanhMucHangTau,
		@IDDanhMucLoaiContainer,
		@SoLuongContainer,
		@SoContainer,
		@KhoiLuong,
		@IDDanhMucDiaDiemNangCont,
		@NgayNangCont,
		@IDDanhMucDiaDiemHaCont,
		@NgayHaCont,
		@IDDanhMucDiaDiemGiaoNhan,
		@NgayGiaoNhan,
		@NguoiGiaoNhan,
		@SoDienThoaiGiaoNhan,
		@GhiChu,
		--
		@IDDanhMucNguoiSuDungCreate,
		@NgayCapNhat
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
alter procedure Update_ctKeHoachVanTai
(
	@ID								bigint,
	@IDDanhMucDonVi					bigint,
	@IDDanhMucChungTu				bigint,
	@IDDanhMucChungTuTrangThai		bigint,
	@So								nvarchar(35),
	@NgayLap						datetime,
	--
	@IDDanhMucSale					bigint,
	@IDDanhMucKhachHang				bigint,
	@LoaiHinh						tinyint, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
	@LoaiHang						tinyint, --Loại hàng: 1: FCL, 2: LCL
	@IDDanhMucHangTau				bigint = null,
	@IDDanhMucLoaiContainer			bigint = null,
	@SoLuongContainer				int = null,
	@SoContainer					nvarchar(512) = null,
	@KhoiLuong						float = null,
	@IDDanhMucDiaDiemNangCont		bigint = null,
	@NgayNangCont					datetime = null,
	@IDDanhMucDiaDiemHaCont			bigint = null,
	@NgayHaCont						datetime = null,
	@IDDanhMucDiaDiemGiaoNhan		bigint = null,
	@NgayGiaoNhan					datetime = null,
	@NguoiGiaoNhan					nvarchar(128) = null,
	@SoDienThoaiGiaoNhan			nvarchar(128) = null,
	@GhiChu							nvarchar(max) = null,
	--
	@IDDanhMucNguoiSuDungEdit		bigint
)
as
begin
	set nocount on;
	declare @Err int;
	declare @NgayCapNhat datetime;
	select @NgayCapNhat = GETDATE();

	declare @IDDanhMucNguoiSuDungCreate bigint;
	select @IDDanhMucNguoiSuDungCreate = IDDanhMucNguoiSuDungCreate from ctKeHoachVanTai where ID = @ID;
	if @IDDanhMucNguoiSuDungCreate <> @IDDanhMucNguoiSuDungEdit
	begin
		raiserror(N'Bạn không có quyền sửa đơn hàng của người khác!', 16, 1);
		return;
	end;
	begin
		begin tran
		begin try
		update ctKeHoachVanTai
			set
				IDDanhMucSale = @IDDanhMucSale,
				IDDanhMucKhachHang = @IDDanhMucKhachHang,
				LoaiHinh = @LoaiHinh,
				LoaiHang = @LoaiHang,
				IDDanhMucHangTau = @IDDanhMucHangTau,
				IDDanhMucLoaiContainer = @IDDanhMucLoaiContainer,
				SoLuongContainer = @SoLuongContainer, 
				SoContainer = @SoContainer,
				KhoiLuong = @KhoiLuong,
				IDDanhMucDiaDiemNangCont = @IDDanhMucDiaDiemNangCont,
				NgayNangCont = @NgayNangCont,
				IDDanhMucDiaDiemHaCont = @IDDanhMucDiaDiemHaCont,
				NgayHaCont = @NgayHaCont,
				IDDanhMucDiaDiemGiaoNhan = @IDDanhMucDiaDiemGiaoNhan,
				NgayGiaoNhan = @NgayGiaoNhan, 
				NguoiGiaoNhan = @NguoiGiaoNhan,
				SoDienThoaiGiaoNhan = @SoDienThoaiGiaoNhan,
				GhiChu = @GhiChu,
				--
				IDDanhMucNguoiSuDungEdit = @IDDanhMucNguoiSuDungEdit,
				EditDate = @NgayCapNhat
			where ID = @ID;
		commit tran
		end try
		begin catch
			rollback
			declare @ErrMsg nvarchar(max)
			select @ErrMsg = error_message()
			raiserror(@ErrMsg, 16, 1)
		end catch
	end;
end
go
------------------
alter procedure Delete_ctKeHoachVanTai
(
	@ID							bigint,
	@IDDanhMucNguoiSuDungDelete	bigint
)
as
begin
	set nocount on;
	declare @Err int;
	declare @NgayCapNhat datetime;
	select @NgayCapNhat = GETDATE();

	declare @IDDanhMucNguoiSuDungCreate bigint;
	select @IDDanhMucNguoiSuDungCreate = IDDanhMucNguoiSuDungCreate from ctKeHoachVanTai where ID = @ID;
	if @IDDanhMucNguoiSuDungCreate <> @IDDanhMucNguoiSuDungDelete
	begin
		raiserror(N'Bạn không có quyền xóa kế hoạch của người khác!', 16, 1);
		return;
	end
	else
	begin
		begin tran
		begin try
		--
		select 
			ID 
		into #ChungTuChiTiet
		from ctKeHoachVanTaiChiTietSoContainer where IDChungTu = @ID;
		delete from ctKeHoachVanTaiChiTietSoContainer where IDChungTu = @ID;
		delete from AutoID where ID in (select ID from #ChungTuChiTiet);
		drop table #ChungTuChiTiet;
		--
		delete from ctKeHoachVanTai where ID = @ID;
		delete from AutoID where ID = @ID;
		commit tran
		end try
		begin catch
			rollback
			declare @ErrMsg nvarchar(max)
			select @ErrMsg = error_message()
			raiserror(@ErrMsg, 16, 1)
		end catch
	end;
end
go
