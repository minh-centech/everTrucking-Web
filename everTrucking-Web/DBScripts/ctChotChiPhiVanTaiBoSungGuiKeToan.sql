/*
create table ctChotChiPhiVanTaiBoSungGuiKeToan
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	--
	IDChungTu						bigint not null, --IDctDonHang
	--
	GhiChu							nvarchar(max),
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	constraint PK_ctChotChiPhiVanTaiBoSungGuiKeToan primary key (ID),
	constraint ctChotChiPhiVanTaiBoSungGuiKeToan_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctChotChiPhiVanTaiBoSungGuiKeToan foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctChotChiPhiVanTaiBoSungGuiKeToan foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint ChungTu_ctChotChiPhiVanTaiBoSungGuiKeToan foreign key (IDChungTu) references ctDonHang(ID),
	--
	constraint UserCreate_ctChotChiPhiVanTaiBoSungGuiKeToan foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctChotChiPhiVanTaiBoSungGuiKeToan foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
---------------
alter procedure List_ctChotChiPhiVanTaiBoSungGuiKeToan
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	@TuNgay						date = null,
	@DenNgay					date = null,
	@IDDanhMucNhomHangVanChuyen	bigint = null,
	@IDDanhMucSale				bigint = null

as
begin
	set nocount on;
	--
	if @TuNgay is null set @TuNgay = '2020-01-01';
	if @DenNgay is null set @DenNgay = '2030-01-01';
	--
	create table #ChungTuChuaChot
	(
		ID								bigint,
		IDDanhMucDonVi					bigint,
		IDDanhMucChungTu				bigint,
		IDDanhMucChungTuTrangThai			bigint,
		IDctChiPhiVanTaiBoSung				bigint,
		IDctChotChiPhiVanTaiBoSungGuiKeToan	bigint,
		LuaChon							bit,
		So								nvarchar(35),
		DebitNote						nvarchar(128),
		MaDanhMucTuyenVanTai			nvarchar(128),
		TenDanhMucTuyenVanTai			nvarchar(255),
		TenDanhMucTaiXe					nvarchar(255),
		MaDanhMucChuXe					nvarchar(128),
		BienSo							nvarchar(128),
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
		GhiChu							nvarchar(max)
	);
	--
	create table #ChungTuDaChot
	(
		ID								bigint,
		IDDanhMucDonVi					bigint,
		IDDanhMucChungTu				bigint,
		IDDanhMucChungTuTrangThai		bigint,
		IDctChiPhiVanTaiBoSung				bigint,
		IDctChotChiPhiVanTaiBoSungGuiKeToan	bigint,
		LuaChon							bit,
		So								nvarchar(35),
		DebitNote						nvarchar(128),
		MaDanhMucTuyenVanTai			nvarchar(128),
		TenDanhMucTuyenVanTai			nvarchar(255),
		TenDanhMucTaiXe					nvarchar(255),
		MaDanhMucChuXe					nvarchar(128),
		BienSo							nvarchar(128),
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
		GhiChu							nvarchar(max)
	);
	--
	insert into #ChungTuChuaChot
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		ctChiPhiVanTaiBoSung.ID,
		ctChotChiPhiVanTaiBoSungGuiKeToan.ID,
		0,
		a.So,
		a.DebitNote,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		TaiXe.Ten,
		ChuXe.Ma,
		Xe.BienSo,
		ctChiPhiVanTaiBoSung.SoLuongNhienLieu,
		ctChiPhiVanTaiBoSung.SoTienVeCauDuong,
		ctChiPhiVanTaiBoSung.SoTienLuatAnCa,
		ctChiPhiVanTaiBoSung.SoTienKetHopVeCauDuongLuatAnCa,
		ctChiPhiVanTaiBoSung.SoTienLuuCaKhac,
		ctChiPhiVanTaiBoSung.SoTienLuatDuongCam,
		ctChiPhiVanTaiBoSung.SoTienTongLuuCaKhacLuatDuongCam,
		ctChiPhiVanTaiBoSung.SoTienLuongChuyen,
		ctChiPhiVanTaiBoSung.SoTienLuongChuNhat,
		ctChiPhiVanTaiBoSung.SoTienCuocThueXeNgoai,
		a.GhiChu
	from ctDonHang a
		left join ctChiPhiVanTaiBoSung on a.ID = ctChiPhiVanTaiBoSung.IDChungTu
		left join ctChotChiPhiVanTaiBoSungGuiKeToan on a.ID = ctChotChiPhiVanTaiBoSungGuiKeToan.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucNhanSu Sale on a.IDDanhMucSale = Sale.ID
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.Huy is null
		and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)
		and case when @IDDanhMucSale is not null then a.IDDanhMucSale else -1 end = isnull(@IDDanhMucSale, -1)
		and ctChotChiPhiVanTaiBoSungGuiKeToan.ID is null
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay order by isnull(a.NgayDongHang, a.NgayTraHang);
	--
	insert into #ChungTuDaChot
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		ctChiPhiVanTaiBoSung.ID,
		ctChotChiPhiVanTaiBoSungGuiKeToan.ID,
		0,
		a.So,
		a.DebitNote,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		TaiXe.Ten,
		ChuXe.Ma,
		Xe.BienSo,
		ctChiPhiVanTaiBoSung.SoLuongNhienLieu,
		ctChiPhiVanTaiBoSung.SoTienVeCauDuong,
		ctChiPhiVanTaiBoSung.SoTienLuatAnCa,
		ctChiPhiVanTaiBoSung.SoTienKetHopVeCauDuongLuatAnCa,
		ctChiPhiVanTaiBoSung.SoTienLuuCaKhac,
		ctChiPhiVanTaiBoSung.SoTienLuatDuongCam,
		ctChiPhiVanTaiBoSung.SoTienTongLuuCaKhacLuatDuongCam,
		ctChiPhiVanTaiBoSung.SoTienLuongChuyen,
		ctChiPhiVanTaiBoSung.SoTienLuongChuNhat,
		ctChiPhiVanTaiBoSung.SoTienCuocThueXeNgoai,
		a.GhiChu
	from ctDonHang a
		left join ctChiPhiVanTaiBoSung on a.ID = ctChiPhiVanTaiBoSung.IDChungTu
		left join ctChotChiPhiVanTaiBoSungGuiKeToan on a.ID = ctChotChiPhiVanTaiBoSungGuiKeToan.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucNhanSu Sale on a.IDDanhMucSale = Sale.ID
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu
		and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)
		and case when @IDDanhMucSale is not null then a.IDDanhMucSale else -1 end = isnull(@IDDanhMucSale, -1)
		and ctChotChiPhiVanTaiBoSungGuiKeToan.ID is not null
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay order by isnull(a.NgayDongHang, a.NgayTraHang);
	--
	select * from #ChungTuChuaChot;
	select * from #ChungTuDaChot;
	--
	drop table #ChungTuChuaChot;
	drop table #ChungTuDaChot;
end;
go
------------------
alter procedure Insert_ctChotChiPhiVanTaiBoSungGuiKeToan
(
	@ID										bigint = null output,
	@IDDanhMucDonVi							bigint,
	@IDDanhMucChungTu						bigint,
	--
	@IDChungTu								bigint,
	--
	@IDDanhMucNguoiSuDungCreate				bigint,
	@CreateDate								datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	select @CreateDate = GETDATE();
	begin tran
	begin try
	
	--
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctChotChiPhiVanTaiBoSungGuiKeToan';
	insert	into ctChotChiPhiVanTaiBoSungGuiKeToan
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		--
		IDChungTu,
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
alter procedure Delete_ctChotChiPhiVanTaiBoSungGuiKeToan
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
	delete from ctChotChiPhiVanTaiBoSungGuiKeToan where ID = @ID;
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
