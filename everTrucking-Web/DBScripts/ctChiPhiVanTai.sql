/*
create table ctChiPhiVanTai
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
	IDDanhMucCanBoTamUng			bigint,
	ThoiHanThanhToan				date
	--
	GhiChu							nvarchar(max),
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	constraint PK_ctChiPhiVanTai primary key (ID),
	constraint ctChiPhiVanTai_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctChiPhiVanTai foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctChiPhiVanTai foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint ChungTu_ctChiPhiVanTai foreign key (IDChungTu) references ctDonHang(ID),
	constraint unq_IDChungTu_ctChiPhiVanTai unique(IDChungTu),
	--
	alter table ctChiPhiVanTai drop
	constraint DanhMucCanBoTamUng_ctChiPhiVanTai foreign key (IDDanhMucCanBoTamUng) references DanhMucNhanSu(ID),
	--
	constraint UserCreate_ctChiPhiVanTai foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctChiPhiVanTai foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
---------------
alter procedure List_ctChiPhiVanTai_Display
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	@TuNgay						date = null,
	@DenNgay					date = null,
	@IDDanhMucNhomHangVanChuyen bigint = null
as
begin
	set nocount on;
	--
	if @TuNgay is null set @TuNgay = '2020-01-01';
	if @DenNgay is null set @DenNgay = '2030-01-01';
	--
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		ctChiPhiVanTai.ID IDctChiPhiVanTai,
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
		a.GhiChu GhiChuCS,
		TaiXe.Ten TenDanhMucTaiXe,
		case when ctDieuHanh.TrangThaiDonHang = 1 or ctDieuHanh.TrangThaiDonHang is null then N'Đơn' when ctDieuHanh.TrangThaiDonHang = 2 then N'Kết hợp' else N'Kẹp đôi' end TrangThaiDonHang,
		ctChiPhiVanTai.GhiChu
	from ctDonHang a
		left join ctChiPhiVanTai on a.ID = ctChiPhiVanTai.IDChungTu
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa = HangHoa.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.Huy is null
		and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay
	order by isnull(a.NgayDongHang, a.NgayTraHang), NhomHangVanChuyen.Ma, a.DebitNote;
end;
go
---------------
alter procedure List_ctChiPhiVanTai
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	@ID							bigint

as
begin
	set nocount on;
	--
	create table #ChungTu
	(
		ID								bigint,
		IDDanhMucDonVi					bigint,
		IDDanhMucChungTu				bigint,
		IDDanhMucChungTuTrangThai		bigint,
		IDctChiPhiVanTai				bigint,
		So								nvarchar(35),
		NgayLap							datetime,
		--
		DebitNote						nvarchar(128),
		BillBooking						nvarchar(128),
		NgayDongTraHang					date,
		TenDanhMucKhachHang				nvarchar(255),
		TenDanhMucTuyenVanTai			nvarchar(255),
		BienSo							nvarchar(128),
		IDDanhMucNhomHangVanChuyen		bigint,
		TenDanhMucNhomHangVanChuyen		nvarchar(255),
		IDDanhMucHangHoa				bigint,
		TenDanhMucHangHoa				nvarchar(255),
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
		IDDanhMucCanBoTamUng			bigint,
		TenDanhMucCanBoTamUng			nvarchar(255),
		ThoiHanThanhToan				date,
		GhiChu							nvarchar(max),
		--
		IDDanhMucNguoiSuDungCreate		bigint,
		MaDanhMucNguoiSuDungCreate		nvarchar(128),
		CreateDate						datetime,
		IDDanhMucNguoiSuDungEdit		bigint,
		MaDanhMucNguoiSuDungEdit		nvarchar(128),
		EditDate						datetime
	);
	--
	insert into #ChungTu
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		ctChiPhiVanTai.ID,
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
		ctChiPhiVanTai.SoTienCuocThueXeNgoai,
		ctChiPhiVanTai.IDDanhMucCanBoTamUng,
		CanBoTamUng.Ten TenDanhMucCanBoTamUng,
		ctChiPhiVanTai.ThoiHanThanhToan,
		ctChiPhiVanTai.GhiChu,
		--
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ma MaDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ma MaDanhMucNguoiSuDungEdit,
		a.EditDate
	from ctDonHang a
		left join ctChiPhiVanTai on a.ID = ctChiPhiVanTai.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa = HangHoa.ID
		left join DanhMucNhanSu CanBoTamUng on ctChiPhiVanTai.IDDanhMucCanBoTamUng = CanBoTamUng.ID
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.Huy is null and a.ID = @ID;
	--
	select * from #ChungTu;
	--
	drop table #ChungTu;
end;
go
------------------
alter procedure Insert_ctChiPhiVanTai
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
	@IDDanhMucCanBoTamUng				bigint = null,
	@ThoiHanThanhToan					date = null,
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
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctChiPhiVanTai';
	insert	into ctChiPhiVanTai
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
		IDDanhMucCanBoTamUng,
		ThoiHanThanhToan,
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
		@IDDanhMucCanBoTamUng,
		@ThoiHanThanhToan,
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
alter procedure Update_ctChiPhiVanTai
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
	@IDDanhMucCanBoTamUng				bigint = null,
	@ThoiHanThanhToan					date = null,
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
	update ctChiPhiVanTai
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
			IDDanhMucCanBoTamUng = @IDDanhMucCanBoTamUng,
			ThoiHanThanhToan = @ThoiHanThanhToan,
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
alter procedure Delete_ctChiPhiVanTai
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
	delete from ctChiPhiVanTai where ID = @ID;
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
alter procedure Get_ctChiPhiVanTai_IDctChotChiPhiVanTaiGuiKeToan
	@IDctDonHang bigint,
	@IDctChotChiPhiVanTaiGuiKeToan bigint = null out
as
begin
	set nocount on;
	select @IDctChotChiPhiVanTaiGuiKeToan = ID from ctChotChiPhiVanTaiGuiKeToan where IDChungTu = @IDctDonHang;
end
go
---------------
alter procedure List_ctChiPhiVanTai_ValidSoDonHang
	@IDDanhMucDonVi	bigint,
	@So				nvarchar(128) = null
as
begin
	set nocount on;
	--
	if @So is null set @So = '%' else set @So = '%' + @So + '%';
	--
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		ctChiPhiVanTai.ID IDctChiPhiVanTai,
		a.So,
		a.DebitNote,
		a.SoTienCuoc,
		convert(nvarchar(10), isnull(a.NgayDongHang, a.NgayTraHang), 103) NgayDongTraHang,
		KhachHang.Ma MaDanhMucKhachHang,
		NhomHangVanChuyen.Ma MaDanhMucNhomHangVanChuyen,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		HangHoa.Ma MaDanhMucHangHoa,
		KhoiLuong,
		ChuXe.Ten TenDanhMucChuXe,
		Xe.BienSo,
		a.GhiChu GhiChuCS,
		TaiXe.Ten TenDanhMucTaiXe,
		ctChiPhiVanTai.SoLuongNhienLieu,
		ctChiPhiVanTai.GhiChu
	from ctDonHang a
		left join ctChiPhiVanTai on a.ID = ctChiPhiVanTai.IDChungTu
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa = HangHoa.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.So like @So --and ctChiPhiVanTai.ID is not null
	order by isnull(a.NgayDongHang, a.NgayTraHang), a.DebitNote;
end;
go