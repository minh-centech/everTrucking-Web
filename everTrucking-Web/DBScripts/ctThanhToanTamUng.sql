/*
create table ctThanhToanTamUng
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	--
	IDChungTu						bigint not null,
	IDChungTuChiTiet				bigint,
	LoaiThanhToanTamUng				tinyint not null, --1: Hoàn tạm ứng; 2: Đề nghị thanh toán
	LanThanhToanTamUng				int,
	IDDanhMucCanBoThanhToanTamUng	bigint not null,
	NgayThanhToanTamUng				date not null,
	SoTienHoanTamUng				float,
	IDDanhMucChiPhiHaiQuanKinhDoanh	bigint,
	SoTienChiThuTuc					float,
	SoTienChiTraHoCoHoaDon			float,
	SoTienChiCuocVo					float,
	SoHoaDon						nvarchar(128),
	--
	GhiChu							nvarchar(max),
	Huy								bit,
	--
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	IDDanhMucNguoiSuDungDelete		bigint,
	DeleteDate						datetime,

	constraint PK_ctThanhToanTamUng primary key (ID),
	constraint ctThanhToanTamUng_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctThanhToanTamUng foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctThanhToanTamUng foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint ChungTu_ctThanhToanTamUng foreign key (IDChungTu) references ctDonHang(ID),
	constraint ChungTuChiTiet_ctThanhToanTamUng foreign key (IDChungTuChiTiet) references ctDonHangChiTietTamUng(ID),
	--
	alter table ctThanhToanTamUng drop
	constraint DanhMucCanBoThanhToanTamUng_ctThanhToanTamUng foreign key (IDDanhMucCanBoThanhToanTamUng) references DanhMucNhanSu(ID),
	constraint DanhMucChiPhiHaiQuanKinhDoanh_ctThanhToanTamUng foreign key (IDDanhMucChiPhiHaiQuanKinhDoanh) references DanhMucDoiTuong(ID),
	--
	constraint UserCreate_ctThanhToanTamUng foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctThanhToanTamUng foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID),
	constraint UserDelete_ctThanhToanTamUng foreign key (IDDanhMucNguoiSuDungDelete) references DanhMucNguoiSuDung(ID)
)
go
*/
---------------
alter procedure List_ctThanhToanTamUng_Display
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@IDChungTu			bigint = null,
	@IDChungTuChiTiet	bigint = null,
	@TuNgay				date = null,
	@DenNgay			date = null
as
begin
	set nocount on;
	--
	if @TuNgay is null set @TuNgay = '2020-01-01';
	if @DenNgay is null set @DenNgay = '2030-01-01';
	create table #ChungTu
	(
		ID							bigint,
		IDctDonHangChiTietTamUng	bigint,
		IDDanhMucDonVi				bigint,
		IDDanhMucChungTu			bigint,
		IDDanhMucChungTuTrangThai	bigint,
		NgayDongTraHang				nvarchar(10),
		So							nvarchar(35),
		DebitNote					nvarchar(128),
		BillBooking					nvarchar(128),
		MaDanhMucCanBoTamUng		nvarchar(128),
		SoTienTamUng				float,
		SoTienThanhToan				float,
		SoTienHoanTamUng			float,
		SoTienTon					float,
		NgayThanhToanTamUng			nvarchar(10),
		TenLoaiHang					nvarchar(255), --Nhập/Xuất/Nội địa
		MaDanhMucNhomHangVanChuyen	nvarchar(128),
		MaDanhMucHangHoa			nvarchar(128),
		KhoiLuong					float,
		MaDanhMucKhachHang			nvarchar(128),
		MaDanhMucTuyenVanTai		nvarchar(128),
		MaDanhMucThauPhu			nvarchar(128),
		TrangThaiDonHang			nvarchar(255),
		GhiChu						nvarchar(max)
		
	);
	--
	insert into #ChungTu
	select 
		a.ID,
		ctDonHangChiTietTamUng.ID IDctDonHangChiTietTamUng,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		convert(nvarchar(10), isnull(a.NgayDongHang, a.NgayTraHang), 103),
		a.So,
		a.DebitNote,
		a.BillBooking,
		CanBoTamUng.Ma MaDanhMucCanBoTamUng,
		isnull(ctDonHangChiTietTamUng.SoTienCuocVo, 0) + isnull(ctDonHangChiTietTamUng.SoTienHaiQuan, 0) + isnull(ctDonHangChiTietTamUng.SoTienNangHa, 0) + isnull(ctDonHangChiTietTamUng.SoTienChiKhac, 0) SoTienTamUng,
		null SoTienThanhToan,
		null SoTienHoanTamUng,
		null SoTienTon,
		null NgayThanhToanTamUng,
		case when a.LoaiHang = 1 then N'Nhập' when a.LoaiHang = 2 then N'Xuất' else N'Nội địa' end TenLoaiHang,
		NhomHangVanChuyen.Ma MaDanhMucNhomHangVanChuyen,
		HangHoa.Ma MaDanhMucHangHoa,
		a.KhoiLuong,
		KhachHang.Ma MaDanhMucKhachHang,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		ThauPhu.Ma MaDanhMucThauPhu,
		case when ctDieuHanh.TrangThaiDonHang = 1 or ctDieuHanh.TrangThaiDonHang is null then N'Đơn' when ctDieuHanh.TrangThaiDonHang = 2 then N'Kết hợp' else N'Kẹp đôi' end TrangThaiDonHang,
		a.GhiChu
	from ctDonHang a
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucThauPhu ThauPhu on ctDieuHanh.IDDanhMucThauPhu = ThauPhu.ID
		left join ctDonHangChiTietTamUng on a.ID = ctDonHangChiTietTamUng.IDChungTu
		left join DanhMucNhanSu CanBoTamUng on ctDonHangChiTietTamUng.IDDanhMucCanBoTamUng = CanBoTamUng.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa  = HangHoa.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu --and ctDonHangChiTietTamUng.ID is not null
		and case when @IDChungTu is not null then a.ID else -1 end = isnull(@IDChungTu, -1)
		and case when @IDChungTuChiTiet is not null then ctDonHangChiTietTamUng.ID else -1 end = isnull(@IDChungTuChiTiet, -1)
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay
	order by NhomHangVanChuyen.Ma, a.DebitNote, isnull(a.NgayDongHang, a.NgayTraHang);
	--update thanh toán tạm ứng
	update #ChungTu set SoTienHoanTamUng = isnull(T.SoTienHoanTamUng, 0),
						SoTienThanhToan = isnull(T.SoTienThanhToan, 0)
	from #ChungTu inner join (select IDChungTuChiTiet, sum(isnull(SoTienHoanTamUng, 0)) SoTienHoanTamUng, sum(isnull(SoTienChiThuTuc, 0) + isnull(SoTienChiTraHoCoHoaDon, 0) + isnull(SoTienChiCuocVo, 0)) SoTienThanhToan from ctThanhToanTamUng group by IDChungTuChiTiet) T
	on #ChungTu.IDctDonHangChiTietTamUng = T.IDChungTuChiTiet where #ChungTu.IDctDonHangChiTietTamUng is not null;
	--đơn hàng không tạm ứng
	update #ChungTu set SoTienHoanTamUng = isnull(T.SoTienHoanTamUng, 0),
						SoTienThanhToan = isnull(T.SoTienThanhToan, 0)
	from #ChungTu inner join (select IDChungTu, sum(isnull(SoTienHoanTamUng, 0)) SoTienHoanTamUng, sum(isnull(SoTienChiThuTuc, 0) + isnull(SoTienChiTraHoCoHoaDon, 0) + isnull(SoTienChiCuocVo, 0)) SoTienThanhToan from ctThanhToanTamUng group by IDChungTu) T
	on #ChungTu.ID = T.IDChungTu where #ChungTu.IDctDonHangChiTietTamUng is null;
	--
	update #ChungTu set SoTienTon = SoTienTamUng - isnull(SoTienHoanTamUng, 0) - isnull(SoTienThanhToan, 0);
	update #ChungTu set NgayThanhToanTamUng = (select convert(nvarchar(10), max(NgayThanhToanTamUng), 103) from ctThanhToanTamUng where IDChungTuChiTiet = #ChungTu.IDctDonHangChiTietTamUng);
	--
	select * from #ChungTu;
	--
	drop table #ChungTu;
end;
go
---------------
alter procedure List_ctThanhToanTamUng
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@IDChungTu			bigint,
	@IDChungTuChiTiet	bigint = null
as
begin
	set nocount on;
	--
	create table #ChungTu
	(
		ID							bigint,
		IDctDonHangChiTietTamUng	bigint,
		IDDanhMucDonVi				bigint,
		IDDanhMucChungTu			bigint,
		IDDanhMucChungTuTrangThai	bigint,
		NgayDongTraHang				nvarchar(10),
		So							nvarchar(35),
		NgayLap						datetime,
		DebitNote					nvarchar(128),
		BillBooking					nvarchar(128),
		MaDanhMucCanBoTamUng		nvarchar(128),
		SoTienTamUng				float,
		SoTienThanhToan				float,
		SoTienHoanTamUng			float,
		SoTienTon					float,
		NgayThanhToanTamUng			nvarchar(10),
		TenLoaiHang					nvarchar(255), --Nhập/Xuất/Nội địa
		MaDanhMucNhomHangVanChuyen	nvarchar(128),
		MaDanhMucHangHoa			nvarchar(128),
		KhoiLuong					float,
		MaDanhMucKhachHang			nvarchar(128),
		MaDanhMucTuyenVanTai		nvarchar(128),
		GhiChu						nvarchar(max)
		
	);
	create table #ChungTuChiTiet
	(
		ID									bigint,
		IDDanhMucDonVi						bigint,
		IDDanhMucChungTu					bigint,
		IDChungTu							bigint,
		IDChungTuChiTiet					bigint,
		--
		LoaiThanhToanTamUng					tinyint, --1: Hoàn tạm ứng; 2: Đề nghị thanh toán
		LanThanhToanTamUng					int,
		IDDanhMucCanBoThanhToanTamUng		bigint,
		MaDanhMucCanBoThanhToanTamUng		nvarchar(128),
		TenDanhMucCanBoThanhToanTamUng		nvarchar(255),
		NgayThanhToanTamUng					date,
		SoTienHoanTamUng					float,
		IDDanhMucChiPhiHaiQuanKinhDoanh		bigint,
		MaDanhMucChiPhiHaiQuanKinhDoanh		nvarchar(128),
		TenDanhMucChiPhiHaiQuanKinhDoanh	nvarchar(255),
		SoTienChiThuTuc						float,
		SoTienChiTraHoCoHoaDon				float,
		SoTienChiCuocVo						float,
		SoHoaDon							nvarchar(128),
		--
		GhiChu								nvarchar(max)
	);
	--
	insert into #ChungTu
	select 
		a.ID,
		ctDonHangChiTietTamUng.ID IDctDonHangChiTietTamUng,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		convert(nvarchar(10), isnull(a.NgayDongHang, a.NgayTraHang), 103),
		a.So,
		a.NgayLap,
		a.DebitNote,
		a.BillBooking,
		CanBoTamUng.Ma MaDanhMucCanBoTamUng,
		isnull(ctDonHangChiTietTamUng.SoTienCuocVo, 0) + isnull(ctDonHangChiTietTamUng.SoTienHaiQuan, 0) + isnull(ctDonHangChiTietTamUng.SoTienNangHa, 0) + isnull(ctDonHangChiTietTamUng.SoTienChiKhac, 0) SoTienTamUng,
		null SoTienThanhToan,
		null SoTienHoanTamUng,
		null SoTienTon,
		null NgayThanhToanTamUng,
		case when a.LoaiHang = 1 then N'Nhập' when a.LoaiHang = 2 then N'Xuất' else N'Nội địa' end TenLoaiHang,
		NhomHangVanChuyen.Ma MaDanhMucNhomHangVanChuyen,
		HangHoa.Ma MaDanhMucHangHoa,
		a.KhoiLuong,
		KhachHang.Ma MaDanhMucKhachHang,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		a.GhiChu
	from ctDonHang a
		left join ctDonHangChiTietTamUng on a.ID = ctDonHangChiTietTamUng.IDChungTu
		left join DanhMucNhanSu CanBoTamUng on ctDonHangChiTietTamUng.IDDanhMucCanBoTamUng = CanBoTamUng.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa  = HangHoa.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu
		and a.ID  = @IDChungTu 
		--and a.Huy is null
		and case when @IDChungTuChiTiet is not null then ctDonHangChiTietTamUng.ID else -1 end = isnull(@IDChungTuChiTiet, -1);
	--
	insert into #ChungTuChiTiet
	select
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDChungTu,
		a.IDChungTuChiTiet,
		--
		a.LoaiThanhToanTamUng,
		a.LanThanhToanTamUng,
		a.IDDanhMucCanBoThanhToanTamUng,
		CanBoThanhToanTamUng.Ma,
		CanBoThanhToanTamUng.Ten,
		a.NgayThanhToanTamUng,
		a.SoTienHoanTamUng,
		a.IDDanhMucChiPhiHaiQuanKinhDoanh,
		ChiPhiHaiQuanKinhDoanh.Ma MaDanhMucChiPhiHaiQuanKinhDoanh,
		ChiPhiHaiQuanKinhDoanh.Ten TenDanhMucChiPhiHaiQuanKinhDoanh,
		a.SoTienChiThuTuc,
		a.SoTienChiTraHoCoHoaDon,
		a.SoTienChiCuocVo,
		a.SoHoaDon,
		--
		a.GhiChu
	from ctThanhToanTamUng a
		left join DanhMucNhanSu CanBoThanhToanTamUng on a.IDDanhMucCanBoThanhToanTamUng = CanBoThanhToanTamUng.ID
		left join DanhMucDoiTuong ChiPhiHaiQuanKinhDoanh on a.IDDanhMucChiPhiHaiQuanKinhDoanh = ChiPhiHaiQuanKinhDoanh.ID
	where a.IDChungTu in (select ID from #ChungTu) and (a.Huy is null or a.Huy = 0);
	--update thanh toán tạm ứng
	update #ChungTu set SoTienHoanTamUng = isnull(T.SoTienHoanTamUng, 0),
						SoTienThanhToan = isnull(T.SoTienThanhToan, 0)
	from #ChungTu inner join (select IDChungTuChiTiet, sum(isnull(SoTienHoanTamUng, 0)) SoTienHoanTamUng, sum(isnull(SoTienChiThuTuc, 0) + isnull(SoTienChiTraHoCoHoaDon, 0) + isnull(SoTienChiCuocVo, 0)) SoTienThanhToan from ctThanhToanTamUng where Huy is null group by IDChungTuChiTiet) T
	on #ChungTu.IDctDonHangChiTietTamUng = T.IDChungTuChiTiet where #ChungTu.IDctDonHangChiTietTamUng is not null;
	--đơn hàng không có tạm ứng
	update #ChungTu set SoTienHoanTamUng = isnull(T.SoTienHoanTamUng, 0),
						SoTienThanhToan = isnull(T.SoTienThanhToan, 0)
	from #ChungTu inner join (select IDChungTu, sum(isnull(SoTienHoanTamUng, 0)) SoTienHoanTamUng, sum(isnull(SoTienChiThuTuc, 0) + isnull(SoTienChiTraHoCoHoaDon, 0) + isnull(SoTienChiCuocVo, 0)) SoTienThanhToan from ctThanhToanTamUng where Huy is null  group by IDChungTu) T
	on #ChungTu.ID = T.IDChungTu where #ChungTu.IDctDonHangChiTietTamUng is null;
	--
	update #ChungTu set SoTienTon = SoTienTamUng - isnull(SoTienHoanTamUng, 0) - isnull(SoTienThanhToan, 0);
	update #ChungTu set NgayThanhToanTamUng = (select max(NgayThanhToanTamUng) from ctThanhToanTamUng where IDChungTuChiTiet = #ChungTu.IDctDonHangChiTietTamUng and Huy is null);
	--
	select * from #ChungTu;
	select * from #ChungTuChiTiet;
	--
	drop table #ChungTu;
	drop table #ChungTuChiTiet;
end;
go
---------------
alter procedure List_ctThanhToanTamUng_DeNghiThanhToanHoanUng
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint
as
begin
	set nocount on;
	--
	select
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDChungTu,
		--
		ctDonHang.DebitNote,
		KhachHang.Ten TenDanhMucKhachHang,
		a.LoaiThanhToanTamUng,
		a.LanThanhToanTamUng,
		a.IDDanhMucCanBoThanhToanTamUng,
		CanBoThanhToanTamUng.Ma MaDanhMucCanBoThanhToanTamUng,
		CanBoThanhToanTamUng.Ten TenDanhMucCanBoThanhToanTamUng,
		PhongBan.Ten TenDanhMucPhongBan,
		a.NgayThanhToanTamUng,
		a.SoTienHoanTamUng,
		a.IDDanhMucChiPhiHaiQuanKinhDoanh,
		ChiPhiHaiQuanKinhDoanh.Ma MaDanhMucChiPhiHaiQuanKinhDoanh,
		ChiPhiHaiQuanKinhDoanh.Ten TenDanhMucChiPhiHaiQuanKinhDoanh,
		a.SoTienChiThuTuc,
		a.SoTienChiTraHoCoHoaDon,
		a.SoTienChiCuocVo,
		a.SoHoaDon,
		--
		a.GhiChu
	from ctThanhToanTamUng a
		left join ctDonHang on a.IDChungTu = ctDonHang.ID
		left join DanhMucKhachHang KhachHang on ctDonHang.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucNhanSu CanBoThanhToanTamUng on a.IDDanhMucCanBoThanhToanTamUng = CanBoThanhToanTamUng.ID
		left join DanhMucDoiTuong ChiPhiHaiQuanKinhDoanh on a.IDDanhMucChiPhiHaiQuanKinhDoanh = ChiPhiHaiQuanKinhDoanh.ID
		left join DanhMucDoiTuong PhongBan on CanBoThanhToanTamUng.IDDanhMucPhongBan = PhongBan.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.ID = @ID and a.LoaiThanhToanTamUng = 1;
end;
go
---------------
alter procedure List_ctThanhToanTamUng_DeNghiThanhToan
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint
as
begin
	set nocount on;
	--
	select
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDChungTu,
		--
		ctDonHang.DebitNote,
		isnull((select sum(isnull(SoTienCuocVo, 0) + isnull(SoTienHaiQuan, 0) + isnull(SoTienNangHa, 0) + isnull(SoTienChiKhac, 0)) from ctDonHangChiTietTamUng where IDChungTu = @ID  and Huy is null), 0) - isnull((select sum(isnull(SoTienHoanTamUng, 0)) from ctThanhToanTamUng where IDChungTu = @ID and Huy is null), 0) TongSoTienTamUng,
		isnull((select sum(isnull(SoTienChiThuTuc, 0)) from ctThanhToanTamUng where IDChungTu = @ID and Huy is null), 0) TongSoTienChiThuTuc,
		isnull((select sum(isnull(SoTienChiTraHoCoHoaDon, 0)) from ctThanhToanTamUng where IDChungTu = @ID and Huy is null), 0) TongSoTienChiTraHoCoHoaDon,
		isnull((select sum(isnull(SoTienChiCuocVo, 0)) from ctThanhToanTamUng where IDChungTu = @ID and Huy is null), 0) TongSoTienChiCuoc,
		isnull((select sum(isnull(SoTienChiCuocVo, 0) + isnull(SoTienChiTraHoCoHoaDon, 0) + isnull(SoTienChiThuTuc, 0)) from ctThanhToanTamUng where IDChungTu = @ID and Huy is null), 0) TongSoTienChi,
		isnull((select sum(isnull(SoTienCuocVo, 0) + isnull(SoTienHaiQuan, 0) + isnull(SoTienNangHa, 0) + isnull(SoTienChiKhac, 0)) from ctDonHangChiTietTamUng where IDChungTu = @ID and Huy is null), 0) - isnull((select sum(isnull(SoTienHoanTamUng, 0)) from ctThanhToanTamUng where IDChungTu = @ID and Huy is null), 0) - isnull((select sum(isnull(SoTienChiCuocVo, 0) + isnull(SoTienChiTraHoCoHoaDon, 0) + isnull(SoTienChiThuTuc, 0)) from ctThanhToanTamUng where IDChungTu = @ID and Huy is null), 0) TongSoTienChenhLech,
		KhachHang.Ten TenDanhMucKhachHang,
		a.LoaiThanhToanTamUng,
		a.LanThanhToanTamUng,
		a.IDDanhMucCanBoThanhToanTamUng,
		CanBoThanhToanTamUng.Ma MaDanhMucCanBoThanhToanTamUng,
		CanBoThanhToanTamUng.Ten TenDanhMucCanBoThanhToanTamUng,
		PhongBan.Ten TenDanhMucPhongBan,
		a.NgayThanhToanTamUng,
		a.SoTienHoanTamUng,
		a.IDDanhMucChiPhiHaiQuanKinhDoanh,
		ChiPhiHaiQuanKinhDoanh.Ma MaDanhMucChiPhiHaiQuanKinhDoanh,
		ChiPhiHaiQuanKinhDoanh.Ten TenDanhMucChiPhiHaiQuanKinhDoanh,
		a.SoTienChiThuTuc,
		a.SoTienChiTraHoCoHoaDon,
		a.SoTienChiCuocVo,
		a.SoHoaDon,
		--
		a.GhiChu
	from ctDonHang 
		left join  ctThanhToanTamUng a on ctDonHang.ID = a.IDChungTu
		left join DanhMucKhachHang KhachHang on ctDonHang.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucNhanSu CanBoThanhToanTamUng on a.IDDanhMucCanBoThanhToanTamUng = CanBoThanhToanTamUng.ID
		left join DanhMucDoiTuong ChiPhiHaiQuanKinhDoanh on a.IDDanhMucChiPhiHaiQuanKinhDoanh = ChiPhiHaiQuanKinhDoanh.ID
		left join DanhMucDoiTuong PhongBan on CanBoThanhToanTamUng.IDDanhMucPhongBan = PhongBan.ID
	where ctDonHang.IDDanhMucDonVi = @IDDanhMucDonVi and ctDonHang.IDDanhMucChungTu = @IDDanhMucChungTu and ctDonHang.ID = @ID and a.LoaiThanhToanTamUng = 2;
end;
go
---------------
alter procedure List_ctThanhToanTamUng_DeNghiThanhToanGuiKhachHang
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint
as
begin
	set nocount on;
	--
	select
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDChungTu,
		--
		ctDonHang.DebitNote,
		KhachHang.Ten TenDanhMucKhachHang,
		HangHoa.Ten TenDanhMucHangHoa,
		ctDonHang.KhoiLuong,
		ctDonHang.BillBooking,
		a.LoaiThanhToanTamUng,
		a.LanThanhToanTamUng,
		a.IDDanhMucCanBoThanhToanTamUng,
		CanBoThanhToanTamUng.Ma MaDanhMucCanBoThanhToanTamUng,
		CanBoThanhToanTamUng.Ten TenDanhMucCanBoThanhToanTamUng,
		PhongBan.Ten TenDanhMucPhongBan,
		a.NgayThanhToanTamUng,
		a.SoTienHoanTamUng,
		a.IDDanhMucChiPhiHaiQuanKinhDoanh,
		ChiPhiHaiQuanKinhDoanh.Ma MaDanhMucChiPhiHaiQuanKinhDoanh,
		ChiPhiHaiQuanKinhDoanh.Ten TenDanhMucChiPhiHaiQuanKinhDoanh,
		a.SoTienChiThuTuc,
		a.SoTienChiTraHoCoHoaDon,
		a.SoTienChiCuocVo,
		a.SoHoaDon,
		(select sum(isnull(SoTienChiThuTuc, 0)) from ctThanhToanTamUng where IDChungTu = @ID and a.LoaiThanhToanTamUng = 2 and Huy is null) TongSoTienChiThuTuc,
		(select sum(isnull(SoTienChiThuTuc, 0)) from ctThanhToanTamUng where IDChungTu = @ID and a.LoaiThanhToanTamUng = 2 and Huy is null) * 0.1 SoTienVATChiThuTuc,
		(select sum(isnull(SoTienChiThuTuc, 0)) from ctThanhToanTamUng where IDChungTu = @ID and a.LoaiThanhToanTamUng = 2 and Huy is null) * 1.1 TongSoTienChiThuTucTotal,
		(select sum(isnull(SoTienChiCuocVo, 0)) from ctThanhToanTamUng where IDChungTu = @ID and a.LoaiThanhToanTamUng = 2 and Huy is null) TongSoTienChiCuocVo,
		(select sum(isnull(SoTienChiTraHoCoHoaDon, 0)) from ctThanhToanTamUng where IDChungTu = @ID and a.LoaiThanhToanTamUng = 2 and Huy is null) TongSoTienChiTraHoCoHoaDon,
		((select sum(isnull(SoTienChiThuTuc, 0)) from ctThanhToanTamUng where IDChungTu = @ID and a.LoaiThanhToanTamUng = 2  and Huy is null) * 1.1) + (select sum(isnull(SoTienChiTraHoCoHoaDon, 0)) from ctThanhToanTamUng where IDChungTu = @ID and a.LoaiThanhToanTamUng = 2 and Huy is null) + (select sum(isnull(SoTienChiCuocVo, 0)) from ctThanhToanTamUng where IDChungTu = @ID and a.LoaiThanhToanTamUng = 2 and Huy is null) TongSoTienThanhToan,
		--
		a.GhiChu
	from ctDonHang
		left join ctThanhToanTamUng a on ctDonHang.ID = a.IDChungTu
		left join DanhMucHangHoa HangHoa on ctDonHang.IDDanhMucHangHoa = HangHoa.ID
		left join DanhMucKhachHang KhachHang on ctDonHang.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucNhanSu CanBoThanhToanTamUng on a.IDDanhMucCanBoThanhToanTamUng = CanBoThanhToanTamUng.ID
		left join DanhMucDoiTuong ChiPhiHaiQuanKinhDoanh on a.IDDanhMucChiPhiHaiQuanKinhDoanh = ChiPhiHaiQuanKinhDoanh.ID
		left join DanhMucDoiTuong PhongBan on CanBoThanhToanTamUng.IDDanhMucPhongBan = PhongBan.ID
	where ctDonHang.IDDanhMucDonVi = @IDDanhMucDonVi and ctDonHang.IDDanhMucChungTu = @IDDanhMucChungTu and ctDonHang.ID = @ID and a.LoaiThanhToanTamUng = 2;
end;
go
------------------
alter procedure Insert_ctThanhToanTamUng
(
	@ID									bigint = null output,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucChungTu					bigint,
	--
	@IDChungTu							bigint,
	@IDChungTuChiTiet					bigint = null,
	@LoaiThanhToanTamUng				tinyint, --1: Hoàn tạm ứng; 2: Đề nghị thanh toán
	@IDDanhMucCanBoThanhToanTamUng		bigint,
	@NgayThanhToanTamUng				date,
	@SoTienHoanTamUng					float = null,
	@IDDanhMucChiPhiHaiQuanKinhDoanh	bigint = null,
	@SoTienChiThuTuc					float = null,
	@SoTienChiTraHoCoHoaDon				float = null,
	@SoTienChiCuocVo					float = null,
	@SoHoaDon							nvarchar(128) = null,
	--
	@GhiChu								nvarchar(255) = null,
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

	declare @LanTamUng int;
	select @LanTamUng = max(LanThanhToanTamUng) from ctThanhToanTamUng where IDChungTu = @IDChungTu and IDChungTuChiTiet = @IDChungTuChiTiet and LoaiThanhToanTamUng = 1;
	if @LanTamUng is null or @LanTamUng = 0 
		set @LanTamUng = 1
	else
		set @LanTamUng = @LanTamUng + 1;

	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctThanhToanTamUng';
	insert	into ctThanhToanTamUng
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		--
		IDChungTu,
		IDChungTuChiTiet,
		LoaiThanhToanTamUng,
		LanThanhToanTamUng,
		IDDanhMucCanBoThanhToanTamUng,
		NgayThanhToanTamUng,
		SoTienHoanTamUng,
		IDDanhMucChiPhiHaiQuanKinhDoanh,
		SoTienChiThuTuc,
		SoTienChiTraHoCoHoaDon,
		SoTienChiCuocVo,
		SoHoaDon,
		--
		GhiChu,
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
		@IDChungTuChiTiet,
		@LoaiThanhToanTamUng,
		case when @LoaiThanhToanTamUng = 1 then @LanTamUng else null end,
		@IDDanhMucCanBoThanhToanTamUng,
		@NgayThanhToanTamUng,
		@SoTienHoanTamUng,
		@IDDanhMucChiPhiHaiQuanKinhDoanh,
		@SoTienChiThuTuc,
		@SoTienChiTraHoCoHoaDon,
		@SoTienChiCuocVo,
		@SoHoaDon,
		--
		@GhiChu,
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
------------------
alter procedure Update_ctThanhToanTamUng
(
	@ID									bigint,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucChungTu					bigint,
	--
	@IDChungTu							bigint,
	@IDChungTuChiTiet					bigint = null,
	@LoaiThanhToanTamUng				tinyint, --1: Hoàn tạm ứng; 2: Đề nghị thanh toán
	@IDDanhMucCanBoThanhToanTamUng		bigint,
	@NgayThanhToanTamUng				date,
	@SoTienHoanTamUng					float = null,
	@IDDanhMucChiPhiHaiQuanKinhDoanh	bigint = null,
	@SoTienChiThuTuc					float = null,
	@SoTienChiTraHoCoHoaDon				float = null,
	@SoTienChiCuocVo					float = null,
	@SoHoaDon							nvarchar(128) = null,
	--
	@GhiChu								nvarchar(255) = null,
	@IDDanhMucNguoiSuDungEdit			bigint,
	@EditDate							datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	select @EditDate = GETDATE();

	declare @IDDanhMucNguoiSuDungCreate bigint;
	select @IDDanhMucNguoiSuDungCreate = IDDanhMucNguoiSuDungCreate from ctThanhToanTamUng where ID = @ID;
	if @IDDanhMucNguoiSuDungCreate <> @IDDanhMucNguoiSuDungEdit
	begin
		raiserror(N'Bạn không có quyền sửa phiếu thanh toán tạm ứng của người khác!', 16, 1);
		return;
	end
	else
	begin
		begin tran
		begin try
		update ctThanhToanTamUng
			set
				LoaiThanhToanTamUng = @LoaiThanhToanTamUng,
				IDDanhMucCanBoThanhToanTamUng = @IDDanhMucCanBoThanhToanTamUng,
				NgayThanhToanTamUng = @NgayThanhToanTamUng,
				SoTienHoanTamUng = @SoTienHoanTamUng,
				IDDanhMucChiPhiHaiQuanKinhDoanh = @IDDanhMucChiPhiHaiQuanKinhDoanh,
				SoTienChiThuTuc = @SoTienChiThuTuc,
				SoTienChiTraHoCoHoaDon = @SoTienChiTraHoCoHoaDon,
				SoTienChiCuocVo = @SoTienChiCuocVo,
				SoHoaDon = @SoHoaDon,
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
	end;
end
go
------------------
alter procedure Delete_ctThanhToanTamUng
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
	select @IDDanhMucNguoiSuDungCreate = IDDanhMucNguoiSuDungCreate from ctThanhToanTamUng where ID = @ID;
	if @IDDanhMucNguoiSuDungCreate <> @IDDanhMucNguoiSuDungDelete
	begin
		raiserror(N'Bạn không có quyền xóa phiếu thanh toán tạm ứng của người khác!', 16, 1);
		return;
	end
	else
	begin
		begin tran
		begin try
		--
		--update ctThanhToanTamUng set Huy = 1, IDDanhMucNguoiSuDungDelete = @IDDanhMucNguoiSuDungDelete, DeleteDate = @NgayCapNhat where ID = @ID;
		delete from ctThanhToanTamUng where ID = @ID;

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
