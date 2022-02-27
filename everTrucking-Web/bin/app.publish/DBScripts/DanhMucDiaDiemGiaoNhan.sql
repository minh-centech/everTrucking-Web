/*
create table DanhMucDiaDiemGiaoNhan
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	Ma							nvarchar(128)	not null,
	Ten							nvarchar(255)	not null,
	--
	DiaChi						nvarchar(512),
	GhiChu						nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucDiaDiemGiaoNhan primary key (ID),
	constraint	DanhMucDiaDiemGiaoNhan_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucDiaDiemGiaoNhan foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucDiaDiemGiaoNhan foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	constraint	Ma_DanhMucDiaDiemGiaoNhan unique(Ma),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucDiaDiemGiaoNhan foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucDiaDiemGiaoNhan foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
alter procedure List_DanhMucDiaDiemGiaoNhan
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint = null,
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
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
	from DanhMucDiaDiemGiaoNhan a 
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi 
		and case when @IDDanhMucLoaiDoiTuong is not null then a.IDDanhMucLoaiDoiTuong else -1 end = ISNULL(@IDDanhMucLoaiDoiTuong, -1) 
		and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	order by a.Ma;
end
go
--
--
alter procedure Insert_DanhMucDiaDiemGiaoNhan
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@DiaChi						nvarchar(512) = null,
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
		insert DanhMucDiaDiemGiaoNhan 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			Ma,
			Ten,
			DiaChi,
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
alter procedure Update_DanhMucDiaDiemGiaoNhan
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@DiaChi						nvarchar(512) = null,
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
		update DanhMucDiaDiemGiaoNhan set
			Ma = @Ma,
			Ten = @Ten,
			DiaChi = @DiaChi,
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
alter procedure Delete_DanhMucDiaDiemGiaoNhan
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
	delete DanhMucDiaDiemGiaoNhan	where ID = @ID;
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
