/*
drop table DanhMucXeDinhMucNhienLieu
create table DanhMucXeDinhMucNhienLieu
(
	ID									bigint			not null,
	IDDanhMucDonVi						bigint			not null,
	IDDanhMucLoaiDoiTuong				bigint			not null,
	--
	NgayApDung							date			not null,
	IDDanhMucXe							bigint			not null,
	DinhMucNhienLieuHangNheVo			float,
	DinhMucNhienLieuHangNhe				float,
	DinhMucNhienLieuHangNangVo			float,
	DinhMucNhienLieuHangNang			float,
	GhiChu								nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate			bigint			not null,
	CreateDate							datetime		not null,
	IDDanhMucNguoiSuDungEdit			bigint,
	EditDate							datetime,
	constraint	PK_DanhMucXeDinhMucNhienLieu primary key (ID),
	constraint	DanhMucXeDinhMucNhienLieu_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucXeDinhMucNhienLieu foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucXeDinhMucNhienLieu foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	--
	constraint	DanhMucXe_DanhMucXeDinhMucNhienLieu foreign key (IDDanhMucXe) references DanhMucXe(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucXeDinhMucNhienLieu foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucXeDinhMucNhienLieu foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
create procedure List_DanhMucXeDinhMucNhienLieu
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
			a.IDDanhMucXe,
			Xe.BienSo,
			a.DinhMucNhienLieuHangNheVo,
			a.DinhMucNhienLieuHangNhe,
			a.DinhMucNhienLieuHangNangVo,
			a.DinhMucNhienLieuHangNang,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		from DanhMucXeDinhMucNhienLieu a 
			left join DanhMucXe Xe on a.IDDanhMucXe = Xe.ID
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
create procedure Insert_DanhMucXeDinhMucNhienLieu
	@ID									bigint out,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucLoaiDoiTuong				bigint,
	@NgayApDung							date,
	@IDDanhMucXe						bigint,
	@DinhMucNhienLieuHangNheVo			float = null,
	@DinhMucNhienLieuHangNhe			float = null,
	@DinhMucNhienLieuHangNangVo			float = null,
	@DinhMucNhienLieuHangNang			float = null,
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
		insert DanhMucXeDinhMucNhienLieu 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			NgayApDung,
			IDDanhMucXe,
			DinhMucNhienLieuHangNheVo,
			DinhMucNhienLieuHangNhe,
			DinhMucNhienLieuHangNangVo,
			DinhMucNhienLieuHangNang,
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
			@IDDanhMucXe,
			@DinhMucNhienLieuHangNheVo,
			@DinhMucNhienLieuHangNhe,
			@DinhMucNhienLieuHangNangVo,
			@DinhMucNhienLieuHangNang,
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
create procedure Update_DanhMucXeDinhMucNhienLieu
	@ID									bigint,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucLoaiDoiTuong				bigint,
	@NgayApDung							date,
	@IDDanhMucXe						bigint,
	@DinhMucNhienLieuHangNheVo			float = null,
	@DinhMucNhienLieuHangNhe			float = null,
	@DinhMucNhienLieuHangNangVo			float = null,
	@DinhMucNhienLieuHangNang			float = null,
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
		update DanhMucXeDinhMucNhienLieu set
			NgayApDung = @NgayApDung,
			IDDanhMucXe = @IDDanhMucXe,
			DinhMucNhienLieuHangNheVo = @DinhMucNhienLieuHangNheVo,
			DinhMucNhienLieuHangNhe = @DinhMucNhienLieuHangNhe,
			DinhMucNhienLieuHangNangVo = @DinhMucNhienLieuHangNangVo,
			DinhMucNhienLieuHangNang = @DinhMucNhienLieuHangNang,
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
create procedure Delete_DanhMucXeDinhMucNhienLieu
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucXeDinhMucNhienLieu	where ID = @ID;
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
