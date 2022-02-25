/*
drop table DanhMucThauPhu
create table DanhMucThauPhu
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	Ma							nvarchar(128)	not null,
	Ten							nvarchar(255)	not null,
	--
	DiaChi						nvarchar(512),
	SoDienThoai					nvarchar(128),
	MaSoThueCMND				nvarchar(20),
	IDDanhMucNhomHangVanChuyen	bigint,
	KyHieuKeToan				nvarchar(128),
	GhiChu						nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucThauPhu primary key (ID),
	constraint	DanhMucThauPhu_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucThauPhu foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucThauPhu foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	constraint	Ma_DanhMucThauPhu unique(Ma),
	--
	constraint DanhMucNhomHangVanChuyen_DanhMucThauPhu foreign key (IDDanhMucNhomHangVanChuyen) references DanhMucDoiTuong(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucThauPhu foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucThauPhu foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
create index idx_ThauPhu_Ma on DanhMucThauPhu (Ma);
create index idx_ThauPhu_Ten on DanhMucThauPhu (Ten);
*/
alter procedure List_DanhMucThauPhu
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint = null,
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
			a.DiaChi,
			a.SoDienThoai,
			a.MaSoThueCMND,
			a.IDDanhMucNhomHangVanChuyen, NhomHangVanChuyen.Ten TenDanhMucNhomHangVanChuyen,
			a.KyHieuKeToan,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		from DanhMucThauPhu a 
			left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else -1 end = ISNULL(@IDDanhMucNhomHangVanChuyen, -1) 
		and case when @ID is not null then a.ID else -1 end = ISNULL(@ID, -1) 
		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	order by NhomHangVanChuyen.Ma;
end
go
--
alter procedure Insert_DanhMucThauPhu
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@DiaChi						nvarchar(512) = null,
	@SoDienThoai				nvarchar(128) = null,
	@MaSoThueCMND				nvarchar(20) = null,
	@IDDanhMucNhomHangVanChuyen	bigint,
	@KyHieuKeToan				nvarchar(128) = null,
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
		insert DanhMucThauPhu 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			Ma,
			Ten,
			DiaChi,
			SoDienThoai,
			MaSoThueCMND,
			IDDanhMucNhomHangVanChuyen,
			KyHieuKeToan,
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
			@DiaChi,
			@SoDienThoai,
			@MaSoThueCMND,
			@IDDanhMucNhomHangVanChuyen,
			@KyHieuKeToan,
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
alter procedure Update_DanhMucThauPhu
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@DiaChi						nvarchar(512) = null,
	@SoDienThoai				nvarchar(128) = null,
	@MaSoThueCMND				nvarchar(20) = null,
	@IDDanhMucNhomHangVanChuyen	bigint,
	@KyHieuKeToan				nvarchar(128) = null,
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
		update DanhMucThauPhu set
			Ma = @Ma,
			Ten = @Ten,
			DiaChi = @DiaChi,
			SoDienThoai = @SoDienThoai,
			MaSoThueCMND = @MaSoThueCMND,
			IDDanhMucNhomHangVanChuyen = @IDDanhMucNhomHangVanChuyen,
			KyHieuKeToan = @KyHieuKeToan,
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
alter procedure Delete_DanhMucThauPhu
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucThauPhu	where ID = @ID;
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
