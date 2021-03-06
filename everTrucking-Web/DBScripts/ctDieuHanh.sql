/*
create table ctDieuHanh
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	--
	IDChungTu						bigint not null, --ID đơn hàng
	IDDanhMucThauPhu				bigint,
	IDDanhMucXe						bigint,
	IDDanhMucTaiXe					bigint,
	DienThoai						nvarchar(128),
	TrangThaiDonHang				tinyint, --1: kết hợp, 2 kẹp đôi, 3: đơn, mặc định là 3
	SoDonHangKetHop					nvarchar(255),
	GhiChu							nvarchar(255),
	--
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	constraint PK_ctDieuHanh primary key (ID),
	constraint ctDieuHanh_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctDieuHanh foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctDieuHanh foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint ChungTu_ctDieuHanh foreign key (IDChungTu) references ctDonHang(ID),
	constraint unq_IDChungTu_ctDieuHanh unique(IDChungTu),
	--
	constraint DanhMucThauPhu_ctDieuHanh foreign key (IDDanhMucThauPhu) references DanhMucKhachHang(ID),
	constraint DanhMucThauPhu_ctDieuHanh foreign key (IDDanhMucThauPhu) references DanhMucThauPhu(ID),
	constraint DanhMucXe_ctDieuHanh foreign key (IDDanhMucXe) references DanhMucXe(ID),
	constraint DanhMucTaiXe_ctDieuHanh foreign key (IDDanhMucTaiXe) references DanhMucTaiXe(ID),
	--
	constraint UserCreate_ctDieuHanh foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctDieuHanh foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
---------------
alter procedure List_ctDieuHanh_Display
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
	select 
		a.ID,
		ctDieuHanh.ID IDctDieuHanh,
		a.So,
		a.NgayLap,
		a.IDDanhMucChungTuTrangThai,
		case when a.LoaiHang = 1 then a.NgayTraHang else a.NgayDongHang end NgayDongTraHang,
		case when a.LoaiHang = 1 then a.GioTraHang else a.GioDongHang end GioDongTraHang,
		a.DebitNote,
		KhachHang.Ma MaDanhMucKhachHang,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		a.GhiChu GhiChuCongViec,
		convert(nvarchar(10), a.NgayCatMang, 103) NgayCatMang,
		a.GioCatMang,
		a.LoaiHang,
		case when a.LoaiHang = 1 then N'Nhập' when a.LoaiHang = 2 then N'Xuất' else N'Nội địa' end TenLoaiHang,
		HangHoa.Ma MaDanhMucHangHoa,
		case when ctDieuHanh.TrangThaiDonHang = 1 or ctDieuHanh.TrangThaiDonHang is null then N'Đơn' when ctDieuHanh.TrangThaiDonHang = 2 then N'Kết hợp' else N'Kẹp đôi' end TrangThaiDonHang,
		a.KhoiLuong,
		a.TheTich,
		ThauPhu.ID IDDanhMucThauPhu,
		ThauPhu.Ma MaDanhMucThauPhu,
		Xe.ID IDDanhMucXe,
		Xe.BienSo,
		TaiXe.ID IDDanhMucTaiXe,
		TaiXe.Ten TenDanhMucTaiXe,
		ctDieuHanh.GhiChu GhiChuDieuHanh,
		isnull(ctDieuHanh.DienThoai, ctHotline.DienThoai) DienThoai,
		ctHotline.TinhTrangHotline, --TinhTrangHotline,
		ctHotline.GhiChuHotline, --GhiChuHotline,
		a.SoContainer,
		DiaDiemLayContHang.Ten TenDanhMucDiaDiemLayContHang,
		DiaDiemTraContHang.Ten TenDanhMucDiaDiemTraContHang,
		a.SoTienCuoc,
		ctDieuHanh.IDDanhMucNguoiSuDungCreate,
		ctDieuHanh.CreateDate,
		ctDieuHanh.IDDanhMucNguoiSuDungEdit,
		ctDieuHanh.EditDate
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
		left join DanhMucNguoiSuDung UserCreate on ctDieuHanh.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on ctDieuHanh.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.Huy is null
		and case when @ID is not null then a.ID else -1 end = isnull(@ID, -1)
		and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)
		and a.Huy is null
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay order by NhomHangVanChuyen.Ma, a.DebitNote, isnull(a.NgayDongHang, a.NgayTraHang);
end;
go
---------------
alter procedure List_ctDieuHanh
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint
as
begin
	set nocount on;
	--
	select 
		a.ID,
		ctDieuHanh.ID IDctDieuHanh,
		a.So,
		a.NgayLap,
		a.IDDanhMucChungTuTrangThai,
		isnull(a.NgayDongHang, a.NgayTraHang) NgayDongTraHang,
		isnull(a.GioDongHang, a.GioTraHang) GioDongTraHang,
		a.DebitNote,
		KhachHang.Ma MaDanhMucKhachHang,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		convert(nvarchar(10), a.NgayCatMang, 103) NgayCatMang,
		a.GioCatMang,
		a.LoaiHang,
		case when a.LoaiHang = 1 then N'Nhập' when a.LoaiHang = 2 then N'Xuất' else N'Nội địa' end TenLoaiHang,
		HangHoa.Ma MaDanhMucHangHoa,
		a.KhoiLuong,
		ctHotline.TinhTrangHotline, --TinhTrangHotline,
		ctHotline.GhiChuHotline, --GhiChuHotline,
		ThauPhu.ID IDDanhMucThauPhu,
		ThauPhu.Ma MaDanhMucThauPhu,
		Xe.ID IDDanhMucXe,
		Xe.BienSo,
		TaiXe.ID IDDanhMucTaiXe,
		TaiXe.Ten TenDanhMucTaiXe,
		ctDieuHanh.GhiChu GhiChuDieuHanh,
		isnull(ctDieuHanh.DienThoai, ctHotline.DienThoai) DienThoai,
		a.GhiChu GhiChuCongViec,
		a.SoContainer,
		DiaDiemLayContHang.Ten TenDanhMucDiaDiemLayContHang,
		DiaDiemTraContHang.Ten TenDanhMucDiaDiemTraContHang,
		a.SoTienCuoc
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
		left join DanhMucDoiTuong DiaDiemLayContHang on a.IDDanhMucDiaDiemLayContHang = DiaDiemLayContHang.ID
		left join DanhMucDoiTuong DiaDiemTraContHang on a.IDDanhMucDiaDiemTraContHang = DiaDiemTraContHang.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.Huy is null and a.ID = @ID;
	--
	select * from #ChungTu;
	--
	drop table #ChungTu;
end;
go
---------------
alter procedure List_ctDieuHanh2
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint
as
begin
	set nocount on;
	--
	select 
		a.ID,
		ctDieuHanh.ID IDctDieuHanh,
		a.So,
		a.NgayLap,
		a.IDDanhMucChungTuTrangThai,
		KhachHang.Ma MaDanhMucKhachHang,
		KhachHang.Ten TenDanhMucKhachHang,
		a.SoTienCuoc,
		a.DebitNote,
		case when a.LoaiHang = 1 then N'Nhập' when a.LoaiHang = 2 then N'Xuất' else N'Nội địa' end TenLoaiHang,
		a.BillBooking,
		a.IDDanhMucNhomHangVanChuyen,
		NhomHangVanChuyen.Ma MaDanhMucNhomHangVanChuyen,
		HangHoa.Ma MaDanhMucHangHoa,
		a.KhoiLuong,
		a.SoContainer,
		DiaDiemLayContHang.Ten TenDanhMucDiaDiemLayContHang,
		DiaDiemTraContHang.Ten TenDanhMucDiaDiemTraContHang,
		a.NgayDongHang,
		a.GioDongHang GioDongHang,
		a.NgayTraHang,
		a.GioTraHang,
		KhachHangF3DongHang.Ten TenDanhMucKhachHangF3DongHang,
		KhachHangF3DongHang.DiaChi DiaChiDanhMucKhachHangF3DongHang,
		KhachHangF3TraHang.Ten TenDanhMucKhachHangF3TraHang,
		KhachHangF3TraHang.DiaChi DiaChiDanhMucKhachHangF3TraHang,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		NgayCatMang,
		a.GioCatMang,
		a.NguoiGiaoNhan,
		a.SoDienThoaiGiaoNhan,
		a.GhiChu GhiChuCongViec,
		ThauPhu.ID IDDanhMucThauPhu,
		ThauPhu.Ma MaDanhMucThauPhu,
		ThauPhu.Ten TenDanhMucThauPhu,
		ThauPhu.MaSoThueCMND MaSoThueCMNDThauPhu,
		Xe.ID IDDanhMucXe,
		TaiXe.ID IDDanhMucTaiXe,
		TaiXe.Ten TenDanhMucTaiXe,
		ctDieuHanh.DienThoai,
		TaiXe.SoCMND,
		ctDieuHanh.TrangThaiDonHang,
		ctDieuHanh.SoDonHangKetHop,
		ctDieuHanh.GhiChu
	from ctDonHang a
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join ctHotline on a.ID = ctHotline.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa = HangHoa.ID
		left join DanhMucDoiTuong DiaDiemLayContHang on a.IDDanhMucDiaDiemLayContHang = DiaDiemLayContHang.ID
		left join DanhMucDoiTuong DiaDiemTraContHang on a.IDDanhMucDiaDiemTraContHang = DiaDiemTraContHang.ID

		left join DanhMucKhachHang KhachHangF3DongHang on a.IDDanhMucKhachHangF3DongHang = KhachHangF3DongHang.ID
		left join DanhMucKhachHang KhachHangF3TraHang on a.IDDanhMucKhachHangF3TraHang = KhachHangF3TraHang.ID

		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucThauPhu ThauPhu on ctDieuHanh.IDDanhMucThauPhu = ThauPhu.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.Huy is null and a.ID = @ID;
	--
	select * from #ChungTu;
	--
	drop table #ChungTu;
end;
go
------------------
alter procedure Insert_ctDieuHanh
(
	@ID								bigint = null output,
	@IDDanhMucDonVi					bigint,
	@IDDanhMucChungTu				bigint,
	--
	@IDChungTu						bigint, --ID đơn hàng
	@IDDanhMucThauPhu				bigint = null,
	@IDDanhMucXe					bigint = null,
	@IDDanhMucTaiXe					bigint = null,
	@DienThoai						nvarchar(128) = null,
	@TrangThaiDonHang				tinyint = null,
	@SoDonHangKetHop				nvarchar(255) = null,
	@GhiChu							nvarchar(255) = null,
	--
	@IDDanhMucNguoiSuDungCreate		bigint,
	@CreateDate						datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	select @CreateDate = GETDATE();
	begin tran
	begin try
	
	--
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctDieuHanh';
	insert	into ctDieuHanh
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		--
		IDChungTu,
		IDDanhMucThauPhu,
		IDDanhMucXe,
		IDDanhMucTaiXe,
		DienThoai,
		TrangThaiDonHang,
		SoDonHangKetHop,
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
		@IDDanhMucThauPhu,
		@IDDanhMucXe,
		@IDDanhMucTaiXe,
		@DienThoai,
		@TrangThaiDonHang,
		@SoDonHangKetHop,
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
alter procedure Update_ctDieuHanh
(
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	--
	@IDChungTu					bigint, --ID đơn hàng
	@IDDanhMucThauPhu			bigint = null,
	@IDDanhMucXe				bigint = null,
	@IDDanhMucTaiXe				bigint = null,
	@DienThoai					nvarchar(128) = null,
	@TrangThaiDonHang			tinyint = null,
	@SoDonHangKetHop			nvarchar(255) = null,
	@GhiChu						nvarchar(255) = null,
	--
	@IDDanhMucNguoiSuDungEdit	bigint,
	@EditDate					datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	select @EditDate = GETDATE();

	declare @countID bigint = null;
	
	exec Check_ForeignKey N'ctChiPhiVanTai', N'IDChungTu', @IDChungTu, N'Đơn hàng này đã có phát sinh chi phí vận tải, không sửa được!', @countID out;
	if (@countID > 0)
		return;

	exec Check_ForeignKey N'ctChiPhiVanTaiBoSung', N'IDChungTu', @IDChungTu, N'Đơn hàng này đã có phát sinh chi phí vận tải bổ sung, không sửa được!', @countID out;
	if (@countID > 0)
		return;

	begin tran
	begin try
	update ctDieuHanh
		set
			IDChungTu = @IDChungTu,
			IDDanhMucThauPhu = @IDDanhMucThauPhu,
			IDDanhMucXe = @IDDanhMucXe,
			IDDanhMucTaiXe = @IDDanhMucTaiXe,
			DienThoai = @DienThoai,
			TrangThaiDonHang = @TrangThaiDonHang,
			SoDonHangKetHop = @SoDonHangKetHop,
			GhiChu = @GhiChu,
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
alter procedure Delete_ctDieuHanh
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

	declare @countID bigint = null, @IDChungTu bigint = null;
	select @IDChungTu = IDChungTu from ctDieuHanh where ID = @ID;
	exec Check_ForeignKey N'ctChiPhiVanTai', N'IDChungTu', @IDChungTu, N'Đơn hàng này đã có phát sinh chi phí vận tải, không xóa được!', @countID out;
	if (@countID > 0)
		return;
	exec Check_ForeignKey N'ctChiPhiVanTaiBoSung', N'IDChungTu', @IDChungTu, N'Đơn hàng này đã có phát sinh chi phí vận tải bổ sung, không xóa được!', @countID out;
	if (@countID > 0)
		return;

	declare @IDChiTiet bigint;
	--
	declare curCT cursor for select ID from ctDieuHanhChiTietDonHangKetHop where IDChungTuChiTiet = @ID;
	open curCT;
	fetch next from curCT into @IDChiTiet
	while @@FETCH_STATUS = 0
	begin
		delete from ctDieuHanhChiTietDonHangKetHop where ID = @IDChiTiet;
		delete from AutoID where ID = @IDChiTiet;
		fetch next from curCT into @IDChiTiet;
	end;
	deallocate curCT;

	--
	delete from ctDieuHanh where ID = @ID;
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
------------------
