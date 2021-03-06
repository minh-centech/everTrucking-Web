alter procedure rptKeHoachVanTaiTongHop
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@TuNgay				date,
	@DenNgay			date,
	@IDDanhMucKhachHang	bigint = null,
	@LoaiHinh			tinyint = 0,
	@LoaiHang			tinyint = 0
as
begin
	--declare 
	--	@IDDanhMucDonVi		bigint = 1,
	--	@IDDanhMucChungTu	bigint = 151,
	--	@TuNgay				date = '2022-03-08',
	--	@DenNgay			date = '2022-03-31',
	--	@IDDanhMucKhachHang	bigint = null,
	--	@LoaiHinh			tinyint = 0,
	--	@LoaiHang			tinyint = 0;

	set nocount on;
	create table #report
	(
		RowID						int identity(1, 1),
		NgayLap						nvarchar(10),
		TenLoaiHinh					nvarchar(128),
		LoaiContainer				nvarchar(128),
		SoLuongContainer			int,
		SoContainer					nvarchar(128),
		TenDanhMucKhachHang			nvarchar(256),
		KhoiLuong					decimal(18, 4),
		TenDanhMucHangTau			nvarchar(256),
		GhiChu						nvarchar(512),
		TenDanhMucDiaDiemNangHa		nvarchar(512),
		TenDanhMucDiaDiemGiaoNhan	nvarchar(512)
	);
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
		a.KhoiLuong,			--Nếu là hàng rời
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
	into #ChungTu
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
		and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = isnull(@IDDanhMucKhachHang, -1)
		and case when @LoaiHinh <> 0 then a.LoaiHinh else -1 end = case when @LoaiHinh = 0 then -1 else @LoaiHinh end
		and case when @LoaiHang <> 0 then a.LoaiHang else -1 end = case when @LoaiHang = 0 then -1 else @LoaiHang end
		and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = isnull(@IDDanhMucKhachHang, -1)
	order by a.NgayLap;
	--
	--select * from #ChungTu;
	--
	declare @ID	bigint,
			@NgayLap nvarchar(10),
			@TenLoaiHinh nvarchar(128),
			@LoaiContainer nvarchar(128),
			@SoLuongContainer int,
			@SoContainer nvarchar(128),
			@KhoiLuong decimal(18, 4),
			@TenDanhMucKhachHang nvarchar(256),
			@TenDanhMucHangTau nvarchar(256),
			@GhiChu	nvarchar(512),
			@TenDanhMucDiaDiemGiaoNhan nvarchar(512),
			@TenDanhMucDiaDiemNangHa nvarchar(512);
			
	declare @splitChar nvarchar(1) = ';', 
			@TenDanhMucDiaDiemNangCont nvarchar(512),
			@TenDanhMucDiaDiemHaCont nvarchar(512);
	
	--select ID, TenLoaiHinh, TenDanhMucKhachHang, TenDanhMucHangTau, SoCont20, SoCont40, SoCont45, SoContOpenTop, SoContFlatRack, TenDanhMucDiaDiemNangCont, TenDanhMucDiaDiemHaCont, TenDanhMucDiaDiemGiaoNhan, TenDanhMucDiaDiemTraHang, KhoiLuong, GhiChu from #ChungTu;
	
	declare curChungTu cursor for select ID, NgayLap, TenLoaiHinh, MaDanhMucKhachHang, TenDanhMucHangTau, MaDanhMucLoaiContainer, SoLuongContainer, SoContainer, TenDanhMucDiaDiemNangCont, TenDanhMucDiaDiemHaCont, TenDanhMucDiaDiemGiaoNhan, KhoiLuong, GhiChu from #ChungTu order by LoaiHinh, LoaiHang;
	open curChungTu;
	fetch next from curChungTu into @ID, @NgayLap, @TenLoaiHinh, @TenDanhMucKhachHang, @TenDanhMucHangTau, @LoaiContainer, @SoLuongContainer, @SoContainer, @TenDanhMucDiaDiemNangCont, @TenDanhMucDiaDiemHaCont, @TenDanhMucDiaDiemGiaoNhan, @KhoiLuong, @GhiChu;
	while @@fetch_status = 0
	begin
		--select @SoCont20, @SoCont40, @SoCont45, @SoContFlatRack, @SoContOpenTop;
		--nếu chưa có số cont nào thì insert 1 dòng
		if isnull(@SoLuongContainer, 0) = 0
		begin
			--insert db
			insert into #report
			(
				NgayLap,
				TenLoaiHinh,
				LoaiContainer,
				SoLuongContainer,
				SoContainer,
				TenDanhMucKhachHang,
				KhoiLuong,
				TenDanhMucHangTau,
				GhiChu,
				TenDanhMucDiaDiemNangHa,
				TenDanhMucDiaDiemGiaoNhan
			)
			values
			(
				@NgayLap,
				@TenLoaiHinh,
				null,
				@SoLuongContainer,
				null,
				@TenDanhMucKhachHang,
				@KhoiLuong,
				@TenDanhMucHangTau,
				@GhiChu,
				isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
				isnull(@TenDanhMucDiaDiemGiaoNhan, '')
			);
		end
		else
		begin
			declare @iContainer int = 1, @iSoContainer nvarchar(128) = '';
			
			if right(@SoContainer, 1) <> ';' set @SoContainer = @SoContainer + ';'
			
			while @iContainer <= @SoLuongContainer
			begin
				set @iSoContainer = '';
				if ltrim(rtrim(@SoContainer)) <> ''
				begin
					set @iSoContainer = left(@SoContainer, charindex(@splitChar, @SoContainer, 1) - 1);
					set @SoContainer = substring(@SoContainer, charindex(@splitChar, @SoContainer, 1) + 1, len(@SoContainer) - charindex(@splitChar, @SoContainer, 1));	
				end;
				insert into #report
				(
					NgayLap,
					TenLoaiHinh,
					LoaiContainer,
					SoLuongContainer,
					SoContainer,
					TenDanhMucKhachHang,
					KhoiLuong,
					TenDanhMucHangTau,
					GhiChu,
					TenDanhMucDiaDiemNangHa,
					TenDanhMucDiaDiemGiaoNhan
				)
				values
				(
					@NgayLap,
					@TenLoaiHinh,
					@LoaiContainer,
					@SoLuongContainer,
					@iSoContainer,
					@TenDanhMucKhachHang,
					@KhoiLuong,
					@TenDanhMucHangTau,
					@GhiChu,
					isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
					isnull(@TenDanhMucDiaDiemGiaoNhan, '')
				);
				set @iContainer = @iContainer + 1;
			end;
		end;
		
		fetch next from curChungTu into @ID, @NgayLap, @TenLoaiHinh, @TenDanhMucKhachHang, @TenDanhMucHangTau, @LoaiContainer, @SoLuongContainer, @SoContainer, @TenDanhMucDiaDiemNangCont, @TenDanhMucDiaDiemHaCont, @TenDanhMucDiaDiemGiaoNhan, @KhoiLuong, @GhiChu;
	end;
	deallocate curChungTu;		
	--
	select row_number() over(order by RowID) STT, #report.*  from #report order by RowID;
	--
	drop table #ChungTu;
	drop table #report;
end;
go