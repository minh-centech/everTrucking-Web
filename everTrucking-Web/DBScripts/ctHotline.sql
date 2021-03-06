/*
create table ctHotline
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	--
	IDChungTu						bigint not null, --ID đơn hàng
	NgayGioThucHien					datetime not null,
	NgayThucHien					date not null,
	GioThucHien						nvarchar(5) not null,
	DienThoai						nvarchar(128),
	ThongTinThuTuc					nvarchar(128),
	GhiChuHotline					nvarchar(512),
	TinhTrangHotline				nvarchar(512),
	TrangThaiHotline				tinyint,
	--
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	constraint PK_ctHotline primary key (ID),
	constraint ctHotline_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctHotline foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctHotline foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint ChungTu_ctHotline foreign key (IDChungTu) references ctDonHang(ID),
	--
	constraint UserCreate_ctHotline foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctHotline foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
---------------
alter procedure List_ctHotline_Display
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	@ID							bigint = null,
	@TuNgay						date = null,
	@DenNgay					date = null,
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
		IDctHotline						bigint,
		So								nvarchar(35),
		NgayDongTraHang					date,
		GioDongTraHang					nvarchar(5),
		GioThucHien						nvarchar(5),
		DebitNote						nvarchar(128),
		MaDanhMucKhachHang				nvarchar(128),
		MaDanhMucTuyenVanTai			nvarchar(128),
		TenDanhMucTuyenVanTai			nvarchar(255),
		TenLoaiHang						nvarchar(255),
		MaDanhMucHangHoa				nvarchar(255),
		TrongLuong						float,
		ThongTinThuTuc					nvarchar(512),
		MaDanhMucThauPhu				nvarchar(128),
		BienSo							nvarchar(128),
		TenDanhMucTaiXe					nvarchar(255),
		DienThoai						nvarchar(128),
		GhiChu							nvarchar(max),
		SoContainer						nvarchar(128),
		TenDanhMucDiaDiemLayContHang	nvarchar(255),
		TenDanhMucDiaDiemTraContHang	nvarchar(255),
		GhiChuHotline					nvarchar(512),
		TinhTrangHotline				nvarchar(512),
		TenTrangThaiHotline				nvarchar(128),
	);
	--
	insert into #ChungTu
	select 
		a.ID,
		ctHotline.ID,
		a.So,
		isnull(a.NgayDongHang, a.NgayTraHang) NgayDongTraHang,
		isnull(a.GioDongHang, a.GioTraHang) GioDongTraHang,
		ctHotline.GioThucHien,
		a.DebitNote,
		KhachHang.Ma MaDanhMucKhachHang,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		case when a.LoaiHang = 1 then N'Nhập' when a.LoaiHang = 2 then N'Xuất' else N'Nội địa' end,
		HangHoa.Ma MaDanhMucHangHoa,
		a.KhoiLuong,
		ctHotline.ThongTinThuTuc, --TinhTrangHotline,
		ThauPhu.Ma MaDanhMucThauPhu,
		Xe.BienSo,
		TaiXe.Ten TenDanhMucTaiXe,
		isnull(ctDieuHanh.DienThoai, ctHotline.DienThoai),
		a.GhiChu GhiChuCongViec,
		a.SoContainer,
		DiaDiemLayContHang.Ten TenDanhMucDiaDiemLayContHang,
		DiaDiemTraContHang.Ten TenDanhMucDiaDiemTraContHang,
		ctHotline.GhiChuHotline,
		ctHotline.TinhTrangHotline,
		case when ctHotline.TrangThaiHotline  = 0 then N'Đang đi đóng/trả' when ctHotline.TrangThaiHotline  = 1 then N'Đang chờ đóng/trả' else N'Đã xong' end
	from ctDonHang a
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join ctHotline on a.ID = ctHotline.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucThauPhu ThauPhu on ctDieuHanh.IDDanhMucThauPhu = ThauPhu.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa = HangHoa.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemLayContHang on a.IDDanhMucDiaDiemLayContHang = DiaDiemLayContHang.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemTraContHang on a.IDDanhMucDiaDiemTraContHang = DiaDiemTraContHang.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu
		and case when @ID is not null then a.ID else -1 end = isnull(@ID, -1)
		and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay order by NhomHangVanChuyen.Ma, a.DebitNote, isnull(a.NgayDongHang, a.NgayTraHang);
	--
	select * from #ChungTu;
	--
	drop table #ChungTu;
end;
go
-----------
alter procedure List_ctHotline
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
		IDctDieuHanh					bigint,
		IDctHotline						bigint,
		So								nvarchar(35),
		NgayLap							datetime,
		--
		NgayDongTraHang					date,
		GioDongTraHang					nvarchar(5),
		NgayGioThucHien					datetime,
		NgayThucHien					date,
		GioThucHien						nvarchar(5),
		DebitNote						nvarchar(128),
		BillBooking						nvarchar(128),
		IDDanhMucKhachHang				bigint,
		TenDanhMucKhachHang				nvarchar(255),
		IDDanhMucTuyenVanTai			bigint,
		TenDanhMucTuyenVanTai			nvarchar(255),
		LoaiHang						tinyint, --1: nhập, 2: xuất, 3: nội địa
		TrongLuong						float,
		SoTienCuoc						float,
		ThongTinThuTuc					nvarchar(255),
		IDDanhMucThauPhu					bigint,
		TenDanhMucThauPhu					nvarchar(255),
		IDDanhMucXe						bigint,
		BienSo							nvarchar(128),
		IDDanhMucTaiXe					bigint,
		TenDanhMucTaiXe					nvarchar(255),
		DienThoai						nvarchar(128),
		GhiChu							nvarchar(max),
		SoContainer						nvarchar(128),
		TenDanhMucDiaDiemLayContHang	nvarchar(255),
		TenDanhMucDiaDiemTraContHang	nvarchar(255),
		GhiChuHotline					nvarchar(512),
		TinhTrangHotline				nvarchar(512),
		TrangThaiHotline				tinyint
	);
	--
	insert into #ChungTu
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		ctDieuHanh.ID,
		ctHotline.ID,
		a.So,
		a.NgayLap,
		--
		isnull(a.NgayDongHang, a.NgayTraHang) NgayDongTraHang,
		isnull(a.GioDongHang, a.GioTraHang) GioDongTraHang,
		ctHotline.NgayGioThucHien,
		ctHotline.NgayThucHien,
		ctHotline.GioThucHien,
		a.DebitNote,
		a.BillBooking,
		a.IDDanhMucKhachHang,
		KhachHang.Ten TenDanhMucKhachHang,
		a.IDDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		a.LoaiHang,
		a.KhoiLuong,
		a.SoTienCuoc,
		ctHotline.ThongTinThuTuc,
		ctDieuHanh.IDDanhMucThauPhu,
		ThauPhu.Ten TenDanhMucThauPhu,
		ctDieuHanh.IDDanhMucXe,
		Xe.BienSo,
		ctDieuHanh.IDDanhMucTaiXe,
		TaiXe.Ten TenDanhMucTaiXe,
		isnull(ctHotline.DienThoai, ctDieuHanh.DienThoai),
		a.GhiChu,
		a.SoContainer,
		DiaDiemLayContHang.Ten,
		DiaDiemTraContHang.Ten,
		ctHotline.GhiChuHotline,
		ctHotline.TinhTrangHotline,
		ctHotline.TrangThaiHotline
	from ctDonHang a
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join ctHotline on a.ID = ctHotline.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucThauPhu ThauPhu on ctDieuHanh.IDDanhMucThauPhu = ThauPhu.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
		left join DanhMucDoiTuong DiaDiemLayContHang on a.IDDanhMucDiaDiemLayContHang = DiaDiemLayContHang.ID
		left join DanhMucDoiTuong DiaDiemTraContHang on a.IDDanhMucDiaDiemTraContHang = DiaDiemTraContHang.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.ID = @ID;
	--
	select * from #ChungTu;
	--
	drop table #ChungTu;
end;
go
------------------
alter procedure Insert_ctHotline
(
	@ID							bigint = null output,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	--
	@IDChungTu					bigint, --ID đơn hàng
	@NgayGioThucHien			datetime,
	@NgayThucHien				date,
	@GioThucHien				nvarchar(5),
	@DienThoai					nvarchar(128) = null,
	@ThongTinThuTuc				nvarchar(128) = null,
	@GhiChuHotline				nvarchar(512) = null,
	@TinhTrangHotline			nvarchar(512) = null,
	@TrangThaiHotline			tinyint = null,
	--
	@IDDanhMucNguoiSuDungCreate	bigint,
	@CreateDate					datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	select @CreateDate = GETDATE();
	begin tran
	begin try
	
	--
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctHotline';
	insert	into ctHotline
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		--
		IDChungTu,
		NgayGioThucHien,
		NgayThucHien,
		GioThucHien,
		DienThoai,
		ThongTinThuTuc,
		GhiChuHotline,
		TinhTrangHotline,
		TrangThaiHotline,
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
		@NgayGioThucHien,
		@NgayThucHien,
		@GioThucHien,
		@DienThoai,
		@ThongTinThuTuc,
		@GhiChuHotline,
		@TinhTrangHotline,
		@TrangThaiHotline,
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
alter procedure Update_ctHotline
(
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	--
	@IDChungTu					bigint, --ID đơn hàng
	@NgayGioThucHien			datetime,
	@NgayThucHien				date,
	@GioThucHien				nvarchar(5),
	@DienThoai					nvarchar(128) = null,
	@ThongTinThuTuc				nvarchar(128) = null,
	@GhiChuHotline				nvarchar(512) = null,
	@TinhTrangHotline			nvarchar(512) = null,
	@TrangThaiHotline			tinyint = null,
	--
	@IDDanhMucNguoiSuDungEdit	bigint,
	@EditDate					datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	select @EditDate = GETDATE()
	begin tran
	begin try
	update ctHotline
		set
			IDChungTu = @IDChungTu,
			NgayGioThucHien = @NgayGioThucHien,
			NgayThucHien = @NgayThucHien,
			GioThucHien = @GioThucHien,
			DienThoai = @DienThoai,
			ThongTinThuTuc = @ThongTinThuTuc,
			GhiChuHotline = @GhiChuHotline,
			TinhTrangHotline = @TinhTrangHotline,
			TrangThaiHotline = @TrangThaiHotline,
			--
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
alter procedure Delete_ctHotline
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
	delete from ctHotline where ID = @ID;
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
