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
	set nocount on;
	create table #report
	(
		RowID						int identity(1, 1),
		NgayLap						nvarchar(10),
		TenLoaiHinh					nvarchar(128),
		LoaiContainer				nvarchar(128),
		SoContainer					nvarchar(128),
		TenDanhMucKhachHang			nvarchar(256),
		KhoiLuong					decimal(18, 4),
		TenDanhMucHangTau			nvarchar(256),
		GhiChu						nvarchar(512),
		TenDanhMucDiaDiemNangHa		nvarchar(512),
		TenDanhMucDiaDiemDongTra	nvarchar(512)
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
		a.IDDanhMucDiaDiemNangCont,
		DiaDiemNangCont.Ma MaDanhMucDiaDiemNangCont,
		DiaDiemNangCont.Ten TenDanhMucDiaDiemNangCont,
		convert(nvarchar(10), a.NgayNangCont, 103) NgayNangCont,
		a.IDDanhMucDiaDiemHaCont,
		DiaDiemHaCont.Ma MaDanhMucDiaDiemHaCont,
		DiaDiemHaCont.Ten TenDanhMucDiaDiemHaCont,
		convert(nvarchar(10), a.NgayHaCont, 103) NgayHaCont,
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
		DiaDiemDongHang.Ten TenDanhMucDiaDiemDongHang,
		convert(nvarchar(10), a.NgayDongHang, 103) NgayDongHang,
		a.IDDanhMucDiaDiemTraHang,
		DiaDiemTraHang.Ma MaDanhMucDiaDiemTraHang,
		DiaDiemTraHang.Ten TenDanhMucDiaDiemTraHang,
		convert(nvarchar(10), a.NgayTraHang, 103) NgayTraHang,
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

		left join DanhMucDiaDiemGiaoNhan DiaDiemNangCont on a.IDDanhMucDiaDiemNangCont = DiaDiemNangCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemHaCont on a.IDDanhMucDiaDiemHaCont = DiaDiemHaCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemDongHang on a.IDDanhMucDiaDiemDongHang = DiaDiemDongHang.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemTraHang on a.IDDanhMucDiaDiemTraHang = DiaDiemTraHang.ID

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
			@SoContainer nvarchar(128),
			@TenDanhMucKhachHang nvarchar(256),
			@KhoiLuong decimal(18, 4),
			@TenDanhMucHangTau nvarchar(256),
			@GhiChu	nvarchar(512),
			@TenDanhMucDiaDiemDongTra nvarchar(512),
			@TenDanhMucDiaDiemNangHa nvarchar(512);
			
	declare @splitChar nvarchar(1) = ';', 
			@SoCont20 nvarchar(512), 
			@SoCont40 nvarchar(512), 
			@SoCont45 nvarchar(512), 
			@SoContOpenTop nvarchar(125), 
			@SoContFlatRack nvarchar(512), 
			@TenDanhMucDiaDiemNangCont nvarchar(512),
			@TenDanhMucDiaDiemHaCont nvarchar(512),
			@TenDanhMucDiaDiemDongHang nvarchar(512),
			@TenDanhMucDiaDiemTraHang nvarchar(512);
	
	--select ID, TenLoaiHinh, TenDanhMucKhachHang, TenDanhMucHangTau, SoCont20, SoCont40, SoCont45, SoContOpenTop, SoContFlatRack, TenDanhMucDiaDiemNangCont, TenDanhMucDiaDiemHaCont, TenDanhMucDiaDiemDongHang, TenDanhMucDiaDiemTraHang, KhoiLuong, GhiChu from #ChungTu;
	
	declare curChungTu cursor for select ID, NgayLap, TenLoaiHinh, TenDanhMucKhachHang, TenDanhMucHangTau, SoCont20, SoCont40, SoCont45, SoContOpenTop, SoContFlatRack, TenDanhMucDiaDiemNangCont, TenDanhMucDiaDiemHaCont, TenDanhMucDiaDiemDongHang, TenDanhMucDiaDiemTraHang, KhoiLuong, GhiChu from #ChungTu order by LoaiHinh, LoaiHang;
	open curChungTu;
	fetch next from curChungTu into @ID, @NgayLap, @TenLoaiHinh, @TenDanhMucKhachHang, @TenDanhMucHangTau, @SoCont20, @SoCont40, @SoCont45, @SoContOpenTop, @SoContFlatRack, @TenDanhMucDiaDiemNangCont, @TenDanhMucDiaDiemHaCont, @TenDanhMucDiaDiemDongHang, @TenDanhMucDiaDiemTraHang, @KhoiLuong, @GhiChu;
	while @@fetch_status = 0
	begin
		--select @SoCont20, @SoCont40, @SoCont45, @SoContFlatRack, @SoContOpenTop;
		--nếu chưa có số cont nào thì insert 1 dòng
		if (ltrim(rtrim(@SoCont20)) = '' or @SoCont20 is null) and (ltrim(rtrim(@SoCont40)) = '' or @SoCont40 is null) and (ltrim(rtrim(@SoCont45)) = '' or @SoCont45 is null) and (ltrim(rtrim(@SoContOpenTop)) = '' or @SoContOpenTop is null) and (ltrim(rtrim(@SoContFlatRack)) = '' or @SoContFlatRack is null)
		begin
			--insert db
			insert into #report
			(
				NgayLap,
				TenLoaiHinh,
				LoaiContainer,
				SoContainer,
				TenDanhMucKhachHang,
				KhoiLuong,
				TenDanhMucHangTau,
				GhiChu,
				TenDanhMucDiaDiemNangHa,
				TenDanhMucDiaDiemDongTra
			)
			values
			(
				@NgayLap,
				@TenLoaiHinh,
				null,
				null,
				@TenDanhMucKhachHang,
				@KhoiLuong,
				@TenDanhMucHangTau,
				@GhiChu,
				isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
				isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
			);
		end;
		--tách số container 20
		if ltrim(rtrim(@SoCont20)) <> ''
		begin
			if charindex(@splitChar, @SoCont20, 1) > 0
			begin
				while charindex(@splitChar, @SoCont20, 1) > 0
				begin
					set @SoContainer = left(@SoCont20, charindex(@splitChar, @SoCont20, 1) - 1);
					set @SoCont20 = substring(@SoCont20, charindex(@splitChar, @SoCont20, 1) + 1, len(@SoCont20) - charindex(@splitChar, @SoCont20, 1));
					--insert db
					insert into #report
					(
						NgayLap,
						TenLoaiHinh,
						LoaiContainer,
						SoContainer,
						TenDanhMucKhachHang,
						KhoiLuong,
						TenDanhMucHangTau,
						GhiChu,
						TenDanhMucDiaDiemNangHa,
						TenDanhMucDiaDiemDongTra
					)
					values
					(
						@NgayLap,
						@TenLoaiHinh,
						N'20',
						@SoContainer,
						@TenDanhMucKhachHang,
						@KhoiLuong,
						@TenDanhMucHangTau,
						@GhiChu,
						isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
						isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
					);
					
				end;
			end
			else
			begin
				set @SoContainer = @SoCont20;
				set @SoCont20 = ';';
				--insert db
				insert into #report
				(
					NgayLap,
					TenLoaiHinh,
					LoaiContainer,
					SoContainer,
					TenDanhMucKhachHang,
					KhoiLuong,
					TenDanhMucHangTau,
					GhiChu,
					TenDanhMucDiaDiemNangHa,
					TenDanhMucDiaDiemDongTra
				)
				values
				(
					@NgayLap,
					@TenLoaiHinh,
					N'20',
					@SoContainer,
					@TenDanhMucKhachHang,
					@KhoiLuong,
					@TenDanhMucHangTau,
					@GhiChu,
					isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
					isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
				);
			end;
		end;
		--tách số container 40
		if ltrim(rtrim(@SoCont40)) <> ''
		begin
			if charindex(@splitChar, @SoCont40, 1) > 0
			begin
				while charindex(@splitChar, @SoCont40, 1) > 0
				begin
					set @SoContainer = left(@SoCont40, charindex(@splitChar, @SoCont40, 1) - 1);
					set @SoCont40 = substring(@SoCont40, charindex(@splitChar, @SoCont40, 1) + 1, len(@SoCont40) - charindex(@splitChar, @SoCont40, 1));
					--insert db
					insert into #report
					(
						NgayLap,
						TenLoaiHinh,
						LoaiContainer,
						SoContainer,
						TenDanhMucKhachHang,
						KhoiLuong,
						TenDanhMucHangTau,
						GhiChu,
						TenDanhMucDiaDiemNangHa,
						TenDanhMucDiaDiemDongTra
					)
					values
					(
						@NgayLap,
						@TenLoaiHinh,
						N'40',
						@SoContainer,
						@TenDanhMucKhachHang,
						@KhoiLuong,
						@TenDanhMucHangTau,
						@GhiChu,
						isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
						isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
					);
					
				end;
			end
			else
			begin
				set @SoContainer = @SoCont40;
				set @SoCont40 = '';
				--insert db
				insert into #report
				(
					NgayLap,
					TenLoaiHinh,
					LoaiContainer,
					SoContainer,
					TenDanhMucKhachHang,
					KhoiLuong,
					TenDanhMucHangTau,
					GhiChu,
					TenDanhMucDiaDiemNangHa,
					TenDanhMucDiaDiemDongTra
				)
				values
				(
					@NgayLap,
					@TenLoaiHinh,
					N'40',
					@SoContainer,
					@TenDanhMucKhachHang,
					@KhoiLuong,
					@TenDanhMucHangTau,
					@GhiChu,
					isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
					isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
				);
			end;
		end;
		--tách số container 45
		if ltrim(rtrim(@SoCont45)) <> ''
		begin
			if charindex(@splitChar, @SoCont45, 1) > 0
			begin
				while charindex(@splitChar, @SoCont45, 1) > 0
				begin
					set @SoContainer = left(@SoCont45, charindex(@splitChar, @SoCont45, 1) - 1);
					set @SoCont45 = substring(@SoCont45, charindex(@splitChar, @SoCont45, 1) + 1, len(@SoCont45) - charindex(@splitChar, @SoCont45, 1));
					--insert db
					insert into #report
					(
						NgayLap,
						TenLoaiHinh,
						LoaiContainer,
						SoContainer,
						TenDanhMucKhachHang,
						KhoiLuong,
						TenDanhMucHangTau,
						GhiChu,
						TenDanhMucDiaDiemNangHa,
						TenDanhMucDiaDiemDongTra
					)
					values
					(
						@NgayLap,
						@TenLoaiHinh,
						N'45',
						@SoContainer,
						@TenDanhMucKhachHang,
						@KhoiLuong,
						@TenDanhMucHangTau,
						@GhiChu,
						isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
						isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
					);
					
				end;
			end
			else
			begin
				set @SoContainer = @SoCont45;
				set @SoCont45 = '';
				--insert db
				insert into #report
				(
					NgayLap,
					TenLoaiHinh,
					LoaiContainer,
					SoContainer,
					TenDanhMucKhachHang,
					KhoiLuong,
					TenDanhMucHangTau,
					GhiChu,
					TenDanhMucDiaDiemNangHa,
					TenDanhMucDiaDiemDongTra
				)
				values
				(
					@NgayLap,
					@TenLoaiHinh,
					N'45',
					@SoContainer,
					@TenDanhMucKhachHang,
					@KhoiLuong,
					@TenDanhMucHangTau,
					@GhiChu,
					isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
					isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
				);
			end;
		end;
		--tách số container open top
		if ltrim(rtrim(@SoContOpenTop)) <> ''
		begin
			if charindex(@splitChar, @SoContOpenTop, 1) > 0
			begin
				while charindex(@splitChar, @SoContOpenTop, 1) > 0
				begin
					set @SoContainer = left(@SoContOpenTop, charindex(@splitChar, @SoContOpenTop, 1) - 1);
					set @SoContOpenTop = substring(@SoContOpenTop, charindex(@splitChar, @SoContOpenTop, 1) + 1, len(@SoContOpenTop) - charindex(@splitChar, @SoContOpenTop, 1));
					--insert db
					insert into #report
					(
						NgayLap,
						TenLoaiHinh,
						LoaiContainer,
						SoContainer,
						TenDanhMucKhachHang,
						KhoiLuong,
						TenDanhMucHangTau,
						GhiChu,
						TenDanhMucDiaDiemNangHa,
						TenDanhMucDiaDiemDongTra
					)
					values
					(
						@NgayLap,
						@TenLoaiHinh,
						N'OT',
						@SoContainer,
						@TenDanhMucKhachHang,
						@KhoiLuong,
						@TenDanhMucHangTau,
						@GhiChu,
						isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
						isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
					);
					
				end;
			end
			else
			begin
				set @SoContainer = @SoContOpenTop;
				set @SoContOpenTop = '';
				--insert db
				insert into #report
				(
					NgayLap,
					TenLoaiHinh,
					LoaiContainer,
					SoContainer,
					TenDanhMucKhachHang,
					KhoiLuong,
					TenDanhMucHangTau,
					GhiChu,
					TenDanhMucDiaDiemNangHa,
					TenDanhMucDiaDiemDongTra
				)
				values
				(
					@NgayLap,
					@TenLoaiHinh,
					N'OT',
					@SoContainer,
					@TenDanhMucKhachHang,
					@KhoiLuong,
					@TenDanhMucHangTau,
					@GhiChu,
					isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
					isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
				);
			end;
		end;
		--tách số container flat rrack
		if ltrim(rtrim(@SoContFlatRack)) <> ''
		begin
			if charindex(@splitChar, @SoContFlatRack, 1) > 0
			begin
				while charindex(@splitChar, @SoContFlatRack, 1) > 0
				begin
					set @SoContainer = left(@SoContFlatRack, charindex(@splitChar, @SoContFlatRack, 1) - 1);
					set @SoContFlatRack = substring(@SoContFlatRack, charindex(@splitChar, @SoContFlatRack, 1) + 1, len(@SoContFlatRack) - charindex(@splitChar, @SoContFlatRack, 1));
					--insert db
					insert into #report
					(
						NgayLap,
						TenLoaiHinh,
						LoaiContainer,
						SoContainer,
						TenDanhMucKhachHang,
						KhoiLuong,
						TenDanhMucHangTau,
						GhiChu,
						TenDanhMucDiaDiemNangHa,
						TenDanhMucDiaDiemDongTra
					)
					values
					(
						@NgayLap,
						@TenLoaiHinh,
						N'FR',
						@SoContainer,
						@TenDanhMucKhachHang,
						@KhoiLuong,
						@TenDanhMucHangTau,
						@GhiChu,
						isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
						isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
					);
					
				end;
			end
			else
			begin
				set @SoContainer = @SoContFlatRack;
				set @SoContFlatRack = '';
				--insert db
				insert into #report
				(
					NgayLap,
					TenLoaiHinh,
					LoaiContainer,
					SoContainer,
					TenDanhMucKhachHang,
					KhoiLuong,
					TenDanhMucHangTau,
					GhiChu,
					TenDanhMucDiaDiemNangHa,
					TenDanhMucDiaDiemDongTra
				)
				values
				(
					@NgayLap,
					@TenLoaiHinh,
					N'FR',
					@SoContainer,
					@TenDanhMucKhachHang,
					@KhoiLuong,
					@TenDanhMucHangTau,
					@GhiChu,
					isnull(@TenDanhMucDiaDiemNangCont, '') + case when @TenDanhMucDiaDiemHaCont is not null then '/' + @TenDanhMucDiaDiemHaCont else '' end,
					isnull(@TenDanhMucDiaDiemDongHang, '') + case when @TenDanhMucDiaDiemTraHang is not null then '/' + @TenDanhMucDiaDiemTraHang else '' end
				);
			end;
		end;
		fetch next from curChungTu into @ID, @NgayLap, @TenLoaiHinh, @TenDanhMucKhachHang, @TenDanhMucHangTau, @SoCont20, @SoCont40, @SoCont45, @SoContOpenTop, @SoContFlatRack, @TenDanhMucDiaDiemNangCont, @TenDanhMucDiaDiemHaCont, @TenDanhMucDiaDiemDongHang, @TenDanhMucDiaDiemTraHang, @KhoiLuong, @GhiChu;
	end;
	deallocate curChungTu;		
	--
	select row_number() over(order by RowID) STT, #report.*  from #report order by RowID;
	--
	drop table #ChungTu;
	drop table #report;
end;
go