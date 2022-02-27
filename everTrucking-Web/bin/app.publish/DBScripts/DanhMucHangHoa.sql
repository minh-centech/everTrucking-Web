/*
drop table DanhMucHangHoa
create table DanhMucHangHoa
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	Ma							nvarchar(128)	not null,
	Ten							nvarchar(255)	not null,
	--
	IDDanhMucNhomHangVanChuyen	bigint			not null,
	KichThuoc					float,
	DonViTinh					nvarchar(128),
	GhiChu						nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucHangHoa primary key (ID),
	constraint	DanhMucHangHoa_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucHangHoa foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucHangHoa foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	constraint	Ma_DanhMucHangHoa unique(Ma),
	--
	constraint	DanhMucNhomHangVanChuyen_DanhMucHangHoa foreign key (IDDanhMucNhomHangVanChuyen) references DanhMucDoiTuong(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucHangHoa foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucHangHoa foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
alter procedure List_DanhMucHangHoa
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint,
	@IDDanhMucNhomHangVanChuyen bigint = null,
	@SearchStr nvarchar(255) = null
as
begin
	set nocount on;
	if @SearchStr is null set @SearchStr = '%' else set @SearchStr = '%' + @SearchStr + '%';
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.Ma,
			a.Ten,
			a.IDDanhMucNhomHangVanChuyen,
			NhomHangVanChuyen.Ma MaDanhMucNhomHangVanChuyen,
			NhomHangVanChuyen.Ten TenDanhMucNhomHangVanChuyen,
			a.KichThuoc,
			a.DonViTinh,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		from DanhMucHangHoa a 
			left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi 
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else 0 end = ISNULL(@IDDanhMucNhomHangVanChuyen, 0) 
		and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	order by a.Ma;
end
go
--
--
create procedure Insert_DanhMucHangHoa
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@IDDanhMucNhomHangVanChuyen	bigint,
	@KichThuoc					float = null,
	@DonViTinh					nvarchar(128) = null,
	@GhiChu						nvarchar(512) = null,
	@IDDanhMucNguoiSuDungCreate	bigint,
	@CreateDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_DanhMucDoiTuong @ID out, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, @Ma, @Ten, @IDDanhMucNguoiSuDungCreate, @CreateDate out;
		insert DanhMucHangHoa 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			Ma,
			Ten,
			IDDanhMucNhomHangVanChuyen,
			KichThuoc,
			DonViTinh,
			GhiChu,
			IDDanhMucNguoiSuDungCreate, 
			CreateDate
		) 
		values 
		(	
			@ID, 
			@IDDanhMucDonVi, 
			@IDDanhMucLoaiDoiTuong, 
			@Ma, 
			@Ten, 
			@IDDanhMucNhomHangVanChuyen,
			@KichThuoc,
			@DonViTinh,
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
create procedure Update_DanhMucHangHoa
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@IDDanhMucNhomHangVanChuyen	bigint,
	@KichThuoc					float = null,
	@DonViTinh					nvarchar(128) = null,
	@GhiChu						nvarchar(512) = null,
	@IDDanhMucNguoiSuDungEdit	bigint,
	@EditDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Update_DanhMucDoiTuong @ID, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, @Ma, @Ten, @IDDanhMucNguoiSuDungEdit, @EditDate out
		update DanhMucHangHoa set
			Ma = @Ma,
			Ten = @Ten,
			IDDanhMucNhomHangVanChuyen = @IDDanhMucNhomHangVanChuyen,
			KichThuoc = @KichThuoc,
			DonViTinh = @DonViTinh,
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
create procedure Delete_DanhMucHangHoa
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucHangHoa	where ID = @ID;
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
