/*
drop table DanhMucDinhMucChiPhiHaiQuan
create table DanhMucDinhMucChiPhiHaiQuan
(
	ID									bigint			not null,
	IDDanhMucDonVi						bigint			not null,
	IDDanhMucLoaiDoiTuong				bigint			not null,
	--
	NgayApDung							date			not null,
	IDDanhMucNhomHangVanChuyen			bigint			not null,
	IDDanhMucHangHoa					bigint,
	IDDanhMucKhachHang					bigint,
	IDDanhMucChiPhiHaiQuanKinhDoanh		bigint			not null,
	SoTien								float,
	GhiChu								nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate			bigint			not null,
	CreateDate							datetime		not null,
	IDDanhMucNguoiSuDungEdit			bigint,
	EditDate							datetime,
	constraint	PK_DanhMucDinhMucChiPhiHaiQuan primary key (ID),
	constraint	DanhMucDinhMucChiPhiHaiQuan_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucDinhMucChiPhiHaiQuan foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucDinhMucChiPhiHaiQuan foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	--
	constraint	DanhMucNhomHangVanChuyen_DanhMucDinhMucChiPhiHaiQuan foreign key (IDDanhMucNhomHangVanChuyen) references DanhMucDoiTuong(ID),
	constraint	DanhMucHangHoa_DanhMucDinhMucChiPhiHaiQuan foreign key (IDDanhMucHangHoa) references DanhMucHangHoa(ID),
	constraint	DanhMucKhachHang_DanhMucDinhMucChiPhiHaiQuan foreign key (IDDanhMucKhachHang) references DanhMucKhachHang(ID),
	constraint	DanhMucChiPhiHaiQuanKinhDoanh_DanhMucDinhMucChiPhiHaiQuan foreign key (IDDanhMucChiPhiHaiQuanKinhDoanh) references DanhMucDoiTuong(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucDinhMucChiPhiHaiQuan foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucDinhMucChiPhiHaiQuan foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
alter procedure List_DanhMucDinhMucChiPhiHaiQuan
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint,
	@SearchStr nvarchar(255) = null
as
begin
	set nocount on;
	if @SearchStr is null set @SearchStr = '%' else set @SearchStr = '%' + @SearchStr + '%';
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.NgayApDung,
			a.IDDanhMucNhomHangVanChuyen,
			NhomHangVanChuyen.Ma MaDanhMucNhomHangVanChuyen,
			NhomHangVanChuyen.Ten TenDanhMucNhomHangVanChuyen,
			a.IDDanhMucHangHoa,
			HangHoa.Ma MaDanhMucHangHoa,
			HangHoa.Ten TenDanhMucHangHoa,
			a.IDDanhMucKhachHang,
			KhachHang.Ma MaDanhMucKhachHang,
			KhachHang.Ten TenDanhMucKhachHang,
			a.IDDanhMucChiPhiHaiQuanKinhDoanh,
			ChiPhiHaiQuanKinhDoanh.Ma MaDanhMucChiPhiHaiQuanKinhDoanh,
			ChiPhiHaiQuanKinhDoanh.Ten TenDanhMucChiPhiHaiQuanKinhDoanh,
			a.SoTien,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		from DanhMucDinhMucChiPhiHaiQuan a 
			left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
			left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa = HangHoa.ID
			left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
			left join DanhMucDoiTuong ChiPhiHaiQuanKinhDoanh on a.IDDanhMucChiPhiHaiQuanKinhDoanh = ChiPhiHaiQuanKinhDoanh.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi 
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
	order by a.NgayApDung;
end
go
--
alter procedure Insert_DanhMucDinhMucChiPhiHaiQuan
	@ID									bigint out,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucLoaiDoiTuong				bigint,
	@NgayApDung							date,
	@IDDanhMucNhomHangVanChuyen			bigint,
	@IDDanhMucHangHoa					bigint = null,
	@IDDanhMucKhachHang					bigint = null,
	@IDDanhMucChiPhiHaiQuanKinhDoanh	bigint,
	@SoTien								float = null,
	@GhiChu								nvarchar(512) = null,
	@IDDanhMucNguoiSuDungCreate			bigint,
	@CreateDate							datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_DanhMucDoiTuong @ID out, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, null, null, @IDDanhMucNguoiSuDungCreate, @CreateDate out;
		insert DanhMucDinhMucChiPhiHaiQuan 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			NgayApDung,
			IDDanhMucNhomHangVanChuyen,
			IDDanhMucHangHoa,
			IDDanhMucKhachHang,
			IDDanhMucChiPhiHaiQuanKinhDoanh,
			SoTien,
			GhiChu,
			IDDanhMucNguoiSuDungCreate, 
			CreateDate
		) 
		values 
		(	
			@ID, 
			@IDDanhMucDonVi, 
			@IDDanhMucLoaiDoiTuong, 
			@NgayApDung,
			@IDDanhMucNhomHangVanChuyen,
			@IDDanhMucHangHoa,
			@IDDanhMucKhachHang,
			@IDDanhMucChiPhiHaiQuanKinhDoanh,
			@SoTien,
			@GhiChu,
			@IDDanhMucNguoiSuDungCreate, 
			@CreateDate
		);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
--
--
alter procedure Update_DanhMucDinhMucChiPhiHaiQuan
	@ID									bigint,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucLoaiDoiTuong				bigint,
	@NgayApDung							date,
	@IDDanhMucNhomHangVanChuyen			bigint,
	@IDDanhMucHangHoa					bigint = null,
	@IDDanhMucKhachHang					bigint = null,
	@IDDanhMucChiPhiHaiQuanKinhDoanh	bigint,
	@SoTien								float = null,
	@GhiChu								nvarchar(512) = null,
	@IDDanhMucNguoiSuDungEdit			bigint,
	@EditDate							datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Update_DanhMucDoiTuong @ID, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, null, null, @IDDanhMucNguoiSuDungEdit, @EditDate out
		update DanhMucDinhMucChiPhiHaiQuan set
			NgayApDung = @NgayApDung,
			IDDanhMucNhomHangVanChuyen = @IDDanhMucNhomHangVanChuyen,
			IDDanhMucHangHoa = @IDDanhMucHangHoa,
			IDDanhMucKhachHang = @IDDanhMucKhachHang,
			IDDanhMucChiPhiHaiQuanKinhDoanh = @IDDanhMucChiPhiHaiQuanKinhDoanh,
			SoTien = @SoTien,
			GhiChu = @GhiChu,
			IDDanhMucNguoiSuDungEdit = @IDDanhMucNguoiSuDungEdit,
			EditDate = @EditDate
		where ID = @ID;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
--
--
alter procedure Delete_DanhMucDinhMucChiPhiHaiQuan
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucDinhMucChiPhiHaiQuan	where ID = @ID;
		exec Delete_DanhMucDoiTuong @ID;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
---
