/*
drop table DanhMucMooc
create table DanhMucMooc
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	--
	BienSo						nvarchar(128)	not null,
	IDDanhMucChuMooc			bigint			not null,
	TaiTrong					float,
	HinhAnhMatTruoc				varbinary(max),
	HinhAnhNgang				varbinary(max),
	GhiChu						nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucMooc primary key (ID),
	constraint	DanhMucMooc_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucMooc foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucMooc foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	constraint	BienSo_DanhMucMooc unique(BienSo),
	--
	constraint	DanhMucChuMooc_DanhMucMooc foreign key (IDDanhMucChuMooc) references DanhMucKhachHang(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucMooc foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucMooc foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
create procedure List_DanhMucMooc
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
			a.BienSo,
			a.IDDanhMucChuMooc,
			ChuMooc.Ma MaDanhMucChuMooc,
			ChuMooc.Ten TenDanhMucChuMooc,
			a.TaiTrong,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
	from DanhMucMooc a 
			left join DanhMucKhachHang ChuMooc on a.IDDanhMucChuMooc = ChuMooc.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi 
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
		and a.BienSo like @SearchStr
	order by a.BienSo;
end
go
--
--
create procedure List_DanhMucMooc_HinhAnh
	@ID bigint
as
begin
	set nocount on;
	select	a.HinhAnhMatTruoc, a.HinhAnhNgang
		from DanhMucMooc a 
	where a.ID = @ID;
end
go
--
--
create procedure Insert_DanhMucMooc
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@BienSo						nvarchar(128),
	@IDDanhMucChuMooc			bigint,
	@TaiTrong					float = null,
	@HinhAnhMatTruoc			varbinary(max) = null,
	@HinhAnhNgang				varbinary(max) = null,
	@GhiChu						nvarchar(512) = null,
	@IDDanhMucNguoiSuDungCreate	bigint,
	@CreateDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_DanhMucDoiTuong @ID out, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, @BienSo, @BienSo, @IDDanhMucNguoiSuDungCreate, @CreateDate out;
		insert DanhMucMooc 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			BienSo,
			IDDanhMucChuMooc,
			TaiTrong,
			HinhAnhMatTruoc,
			HinhAnhNgang,
			GhiChu,
			IDDanhMucNguoiSuDungCreate, 
			CreateDate
		) 
		values 
		(	
			@ID, 
			@IDDanhMucDonVi, 
			@IDDanhMucLoaiDoiTuong, 
			@BienSo,
			@IDDanhMucChuMooc,
			@TaiTrong,
			@HinhAnhMatTruoc,
			@HinhAnhNgang,
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
create procedure Update_DanhMucMooc
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@BienSo						nvarchar(128),
	@IDDanhMucChuMooc			bigint,
	@TaiTrong					float = null,
	@HinhAnhMatTruoc			varbinary(max) = null,
	@HinhAnhNgang				varbinary(max) = null,
	@GhiChu						nvarchar(512) = null,
	@IDDanhMucNguoiSuDungEdit	bigint,
	@EditDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Update_DanhMucDoiTuong @ID, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, @BienSo, @BienSo, @IDDanhMucNguoiSuDungEdit, @EditDate out
		update DanhMucMooc set
			BienSo = @BienSo,
			IDDanhMucChuMooc = @IDDanhMucChuMooc,
			TaiTrong = @TaiTrong,
			HinhAnhMatTruoc = @HinhAnhMatTruoc,
			HinhAnhNgang = @HinhAnhNgang,
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
create procedure Delete_DanhMucMooc
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucMooc where ID = @ID;
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
--
--