/*
create table ctChiPhiVanTaiBoSung
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	--
	IDChungTu						bigint not null, --ID đơn hàng
	SoLuongNhienLieu				float,
	SoTienVeCauDuong				float,
	SoTienLuatAnCa					float,
	SoTienKetHopVeCauDuongLuatAnCa	float,
	SoTienLuuCaKhac					float, 
	SoTienLuatDuongCam				float,
	SoTienTongLuuCaKhacLuatDuongCam	float,
	SoTienLuongChuyen				float,
	SoTienLuongChuNhat				float,
	SoTienCuocThueXeNgoai			float,
	NgayBoSung						date,
	--
	GhiChu							nvarchar(max),
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	constraint PK_ctChiPhiVanTaiBoSung primary key (ID),
	constraint ctChiPhiVanTaiBoSung_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctChiPhiVanTaiBoSung foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctChiPhiVanTaiBoSung foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint ChungTu_ctChiPhiVanTaiBoSung foreign key (IDChungTu) references ctDonHang(ID),
	--
	constraint UserCreate_ctChiPhiVanTaiBoSung foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctChiPhiVanTaiBoSung foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
---------------
alter procedure List_ctChiPhiVanTaiBoSung_Display
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	@TuNgay						date = null,
	@DenNgay					date = null,
	@ID							bigint = null,
	@IDDanhMucNhomHangVanChuyen	bigint = null
as
begin
	set nocount on;
	--
	if @TuNgay is null set @TuNgay = '2020-01-01';
	if @DenNgay is null set @DenNgay = '2030-01-01';
	--
	create table #ChungTu
	(
		ID							bigint,
		IDDanhMucDonVi				bigint,
		IDDanhMucChungTu			bigint,
		IDDanhMucChungTuTrangThai	bigint,
		So							nvarchar(35),
		DebitNote					nvarchar(128),
		SoTienCuoc					float,
		NgayDongTraHang				nvarchar(10),
		MaDanhMucKhachHang			nvarchar(128),
		MaDanhMucNhomHangVanChuyen	nvarchar(128),
		TenDanhMucTuyenVanTai		nvarchar(255),
		MaDanhMucHangHoa			nvarchar(128),
		KhoiLuong					float,
		MaDanhMucChuXe				nvarchar(128),
		TenDanhMucChuXe				nvarchar(255),
		BienSo						nvarchar(128),
		TenDanhMucTaiXe				nvarchar(255),
		SoLuongNhienLieu			float,
		ChiPhiVanTaiBoSung			float,
		TrangThaiDonHang			nvarchar(255),
		GhiChu						nvarchar(max)
	);
	--
	insert into #ChungTu
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		a.So,
		a.DebitNote,
		a.SoTienCuoc,
		convert(nvarchar(10), isnull(a.NgayDongHang, a.NgayTraHang), 103) NgayDongTraHang,
		KhachHang.Ma MaDanhMucKhachHang,
		NhomHangVanChuyen.Ma MaDanhMucNhomHangVanChuyen,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		HangHoa.Ma MaDanhMucHangHoa,
		KhoiLuong,
		ChuXe.Ma MaDanhMucChuXe,
		ChuXe.Ten TenDanhMucChuXe,
		Xe.BienSo,
		TaiXe.Ten,
		null SoLuongNhienLieu,
		null ChiPhiVanTaiBoSung,
		case when ctDieuHanh.TrangThaiDonHang = 1 or ctDieuHanh.TrangThaiDonHang is null then N'Đơn' when ctDieuHanh.TrangThaiDonHang = 2 then N'Kết hợp' else N'Kẹp đôi' end TrangThaiDonHang,
		a.GhiChu
	from ctDonHang a
		--left join ctChiPhiVanTaiBoSung on a.ID = ctChiPhiVanTaiBoSung.IDChungTu
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa = HangHoa.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.Huy is null
		and case when @ID is not null then a.ID else -1 end = isnull(@ID, -1)
		and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay
	order by isnull(a.NgayDongHang, a.NgayTraHang), NhomHangVanChuyen.Ma, a.DebitNote;
	--update số tổng
	update #ChungTu set SoLuongNhienLieu = T.SoLuongNhienLieu,
						ChiPhiVanTaiBoSung = T.ChiPhiVanTaiBoSung
	from #ChungTu left join (select IDChungTu, sum(SoLuongNhienLieu) SoLuongNhienLieu, sum(isnull(SoTienVeCauDuong, 0) + isnull(SoTienLuatAnCa, 0) + isnull(SoTienKetHopVeCauDuongLuatAnCa, 0) + isnull(SoTienLuuCaKhac, 0) + isnull(SoTienLuatDuongCam, 0) + isnull(SoTienLuongChuyen, 0) + isnull(SoTienLuongChuNhat, 0) + isnull(SoTienCuocThueXeNgoai, 0)) ChiPhiVanTaiBoSung from ctChiPhiVanTaiBoSung group by IDChungTu) T
	on #ChungTu.ID = IDChungTu;
	--
	select * from #ChungTu;
	--
	drop table #ChungTu;
end;
go
---------------
alter procedure List_ctChiPhiVanTaiBoSung
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint
as
begin
	set nocount on;
	--
	create table #ChungTu
	(
		ID										bigint,
		IDDanhMucDonVi							bigint,
		IDDanhMucChungTu						bigint,
		IDDanhMucChungTuTrangThai				bigint,
		So										nvarchar(35),
		NgayLap									datetime,
		--
		DebitNote								nvarchar(128),
		BillBooking								nvarchar(128),
		NgayDongTraHang							date,
		TenDanhMucKhachHang						nvarchar(255),
		TenDanhMucTuyenVanTai					nvarchar(255),
		BienSo									nvarchar(128),
		IDDanhMucNhomHangVanChuyen				bigint,
		TenDanhMucNhomHangVanChuyen				nvarchar(255),
		IDDanhMucHangHoa						bigint,
		TenDanhMucHangHoa						nvarchar(255),
		SoLuongNhienLieu						float,
		SoTienVeCauDuong						float,
		SoTienLuatAnCa							float,
		SoTienKetHopVeCauDuongLuatAnCa			float,
		SoTienLuuCaKhac							float, 
		SoTienLuatDuongCam						float,
		SoTienTongLuuCaKhacLuatDuongCam			float,
		SoTienLuongChuyen						float,
		SoTienLuongChuNhat						float,
		SoTienCuocThueXeNgoai					float
	);
	create table #ChungTuChiTiet
	(
		ID										bigint,
		IDDanhMucDonVi							bigint,
		IDDanhMucChungTu						bigint,
		IDChungTu								bigint,
		NgayBoSung								date,
		SoLuongNhienLieu						float,
		SoTienVeCauDuong						float,
		SoTienLuatAnCa							float,
		SoTienKetHopVeCauDuongLuatAnCa			float,
		SoTienLuuCaKhac							float, 
		SoTienLuatDuongCam						float,
		SoTienTongLuuCaKhacLuatDuongCam			float,
		SoTienLuongChuyen						float,
		SoTienLuongChuNhat						float,
		SoTienCuocThueXeNgoai					float,
		GhiChu									nvarchar(max),
		--
		IDDanhMucNguoiSuDungCreate				bigint,
		MaDanhMucNguoiSuDungCreate				nvarchar(128),
		CreateDate								datetime,
		IDDanhMucNguoiSuDungEdit				bigint,
		MaDanhMucNguoiSuDungEdit				nvarchar(128),
		EditDate								datetime
	);
	--
	insert into #ChungTu
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		a.So,
		a.NgayLap,
		--
		a.DebitNote,
		a.BillBooking,
		isnull(a.NgayDongHang, a.NgayTraHang),
		KhachHang.Ten TenDanhMucKhachHang,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		Xe.BienSo,
		a.IDDanhMucNhomHangVanChuyen,
		NhomHangVanChuyen.Ten TenDanhMucNhomHangVanChuyen,
		a.IDDanhMucHangHoa,
		HangHoa.Ten TenDanhMucHangHoa,
		ctChiPhiVanTai.SoLuongNhienLieu,
		ctChiPhiVanTai.SoTienVeCauDuong,
		ctChiPhiVanTai.SoTienLuatAnCa,
		ctChiPhiVanTai.SoTienKetHopVeCauDuongLuatAnCa,
		ctChiPhiVanTai.SoTienLuuCaKhac,
		ctChiPhiVanTai.SoTienLuatDuongCam,
		ctChiPhiVanTai.SoTienTongLuuCaKhacLuatDuongCam,
		ctChiPhiVanTai.SoTienLuongChuyen,
		ctChiPhiVanTai.SoTienLuongChuNhat,
		ctChiPhiVanTai.SoTienCuocThueXeNgoai
	from ctDonHang a
		left join ctChiPhiVanTai on a.ID = ctChiPhiVanTai.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa = HangHoa.ID
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.Huy is null and a.ID = @ID;
	--
	insert into #ChungTuChiTiet
	select
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDChungTu,
		a.NgayBoSung,
		a.SoLuongNhienLieu,
		a.SoTienVeCauDuong,
		a.SoTienLuatAnCa,
		a.SoTienKetHopVeCauDuongLuatAnCa,
		a.SoTienLuuCaKhac,
		a.SoTienLuatDuongCam,
		a.SoTienTongLuuCaKhacLuatDuongCam,
		a.SoTienLuongChuyen,
		a.SoTienLuongChuNhat,
		a.SoTienCuocThueXeNgoai,
		a.GhiChu,
		--
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ma MaDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ma MaDanhMucNguoiSuDungEdit,
		a.EditDate
	from ctChiPhiVanTaiBoSung a
		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.IDChungTu = @ID;
	--
	select * from #ChungTu;
	select * from #ChungTuChiTiet;
	--
	drop table #ChungTuChiTiet;
	drop table #ChungTu;
end;
go
------------------
alter procedure Insert_ctChiPhiVanTaiBoSung
(
	@ID									bigint = null output,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucChungTu					bigint,
	--
	@IDChungTu							bigint,
	@SoLuongNhienLieu					float = null,
	@SoTienVeCauDuong					float = null,
	@SoTienLuatAnCa						float = null,
	@SoTienKetHopVeCauDuongLuatAnCa		float = null,
	@SoTienLuuCaKhac					float = null,
	@SoTienLuatDuongCam					float = null,
	@SoTienTongLuuCaKhacLuatDuongCam	float = null,
	@SoTienLuongChuyen					float = null,
	@SoTienLuongChuNhat					float = null,
	@SoTienCuocThueXeNgoai				float = null,
	@NgayBoSung							date,
	@GhiChu								nvarchar(max) = null,
	--
	@IDDanhMucNguoiSuDungCreate			bigint,
	@CreateDate							datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	select @CreateDate = GETDATE();
	begin tran
	begin try
	
	--
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctChiPhiVanTaiBoSung';
	insert	into ctChiPhiVanTaiBoSung
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		--
		IDChungTu,
		SoLuongNhienLieu,
		SoTienVeCauDuong,
		SoTienLuatAnCa,
		SoTienKetHopVeCauDuongLuatAnCa,
		SoTienLuuCaKhac,
		SoTienLuatDuongCam,
		SoTienTongLuuCaKhacLuatDuongCam,
		SoTienLuongChuyen,
		SoTienLuongChuNhat,
		SoTienCuocThueXeNgoai,
		NgayBoSung,
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
		--
		@IDChungTu,
		@SoLuongNhienLieu,
		@SoTienVeCauDuong,
		@SoTienLuatAnCa,
		@SoTienKetHopVeCauDuongLuatAnCa,
		@SoTienLuuCaKhac,
		@SoTienLuatDuongCam,
		@SoTienTongLuuCaKhacLuatDuongCam,
		@SoTienLuongChuyen,
		@SoTienLuongChuNhat,
		@SoTienCuocThueXeNgoai,
		@NgayBoSung,
		@GhiChu,
		--
		@IDDanhMucNguoiSuDungCreate,
		@CreateDate
	)
	commit tran
	end try
	begin catch
		rollback
		declare @ErrMsg nvarchar(max)
		select @ErrMsg = error_message()
		raiserror(@ErrMsg, 16, 1)
	end catch
	set @Err = @@Error
	return @Err
end
go
--
alter procedure Update_ctChiPhiVanTaiBoSung
(
	@ID									bigint,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucChungTu					bigint,
	--
	@IDChungTu							bigint,
	@SoLuongNhienLieu					float = null,
	@SoTienVeCauDuong					float = null,
	@SoTienLuatAnCa						float = null,
	@SoTienKetHopVeCauDuongLuatAnCa		float = null,
	@SoTienLuuCaKhac					float = null,
	@SoTienLuatDuongCam					float = null,
	@SoTienTongLuuCaKhacLuatDuongCam	float = null,
	@SoTienLuongChuyen					float = null,
	@SoTienLuongChuNhat					float = null,
	@SoTienCuocThueXeNgoai				float = null,
	@NgayBoSung							date,
	@GhiChu								nvarchar(255) = null,
	@IDDanhMucNguoiSuDungEdit			bigint,
	@EditDate							datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	select @EditDate = GETDATE()
	begin tran
	begin try
	update ctChiPhiVanTaiBoSung
		set
			IDChungTu = @IDChungTu,
			SoLuongNhienLieu = @SoLuongNhienLieu,
			SoTienVeCauDuong = @SoTienVeCauDuong,
			SoTienLuatAnCa = @SoTienLuatAnCa,
			SoTienKetHopVeCauDuongLuatAnCa = @SoTienKetHopVeCauDuongLuatAnCa,
			SoTienLuuCaKhac = @SoTienLuuCaKhac,
			SoTienLuatDuongCam = @SoTienLuatDuongCam,
			SoTienTongLuuCaKhacLuatDuongCam = @SoTienTongLuuCaKhacLuatDuongCam,
			SoTienLuongChuyen = @SoTienLuongChuyen,
			SoTienLuongChuNhat = @SoTienLuongChuNhat,
			SoTienCuocThueXeNgoai = @SoTienCuocThueXeNgoai,
			NgayBoSung = @NgayBoSung,
			--
			GhiChu = @GhiChu,
			IDDanhMucNguoiSuDungEdit = @IDDanhMucNguoiSuDungEdit,
			EditDate = @EditDate
		where ID = @ID;
	commit tran
	end try
	begin catch
		rollback
		declare @ErrMsg nvarchar(max)
		select @ErrMsg = error_message()
		raiserror(@ErrMsg, 16, 1)
	end catch
	set @Err = @@Error
	return @Err
end
go
--
alter procedure Delete_ctChiPhiVanTaiBoSung
(
	@ID	bigint
)
as
begin
	set nocount on;
	declare @Err int;
	declare @NgayCapNhat datetime;
	select @NgayCapNhat = GETDATE()
	begin tran
	begin try
	--
	delete from ctChiPhiVanTaiBoSung where ID = @ID;
	delete from AutoID where ID = @ID;
	commit tran
	end try
	begin catch
		rollback
		declare @ErrMsg nvarchar(max)
		select @ErrMsg = error_message()
		raiserror(@ErrMsg, 16, 1)
	end catch
	set @Err = @@Error
	return @Err
end
go
--
alter procedure Get_ctChiPhiVanTaiBoSung_IDctChotChiPhiVanTaiBoSungGuiKeToan
	@IDctDonHang bigint,
	@IDctChotChiPhiVanTaiBoSungGuiKeToan bigint = null out
as
begin
	set nocount on;
	select @IDctChotChiPhiVanTaiBoSungGuiKeToan = ID from ctChotChiPhiVanTaiBoSungGuiKeToan where IDChungTu = @IDctDonHang;
end