/*
drop table DanhMucDinhMucChiPhi
create table DanhMucDinhMucChiPhi
(
	ID									bigint			not null,
	IDDanhMucDonVi						bigint			not null,
	IDDanhMucLoaiDoiTuong				bigint			not null,
	--
	NgayApDung							date			not null,
	IDDanhMucTuyenVanTai				bigint			not null,
	SoTienVeCauDuong					float,
	SoTienLuatAnCa						float,
	SoTienLuuCaKhac						float,
	SoTienLuatDuongCam					float,
	SoTienLuongChuyen					float,
	SoTramLuat							smallint,
	SoTramVe							smallint,
	GhiChu								nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate			bigint			not null,
	CreateDate							datetime		not null,
	IDDanhMucNguoiSuDungEdit			bigint,
	EditDate							datetime,
	constraint	PK_DanhMucDinhMucChiPhi primary key (ID),
	constraint	DanhMucDinhMucChiPhi_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucDinhMucChiPhi foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucDinhMucChiPhi foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	--
	constraint	DanhMucTuyenVanTai_DanhMucDinhMucChiPhi foreign key (IDDanhMucTuyenVanTai) references DanhMucTuyenVanTai(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucDinhMucChiPhi foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucDinhMucChiPhi foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
alter procedure List_DanhMucDinhMucChiPhi
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
			a.IDDanhMucTuyenVanTai,
			TuyenVanTai.Ma MaDanhMucTuyenVanTai,
			TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.SoTienVeCauDuong,
			a.SoTienLuatAnCa,
			a.SoTienLuuCaKhac,
			a.SoTienLuatDuongCam,
			a.SoTienLuongChuyen,
			a.SoTramLuat,
			a.SoTramVe,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		from DanhMucDinhMucChiPhi a 
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
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
alter procedure Insert_DanhMucDinhMucChiPhi
	@ID									bigint out,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucLoaiDoiTuong				bigint,
	@NgayApDung							date,
	@IDDanhMucTuyenVanTai				bigint,
	@SoTienVeCauDuong					float = null,
	@SoTienLuatAnCa						float = null,
	@SoTienLuuCaKhac					float = null,
	@SoTienLuatDuongCam					float = null,
	@SoTienLuongChuyen					float = null,
	@SoTramLuat							smallint = null,
	@SoTramVe							smallint = null,
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
		insert DanhMucDinhMucChiPhi 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			NgayApDung,
			IDDanhMucTuyenVanTai,
			SoTienVeCauDuong,
			SoTienLuatAnCa,
			SoTienLuuCaKhac,
			SoTienLuatDuongCam,
			SoTienLuongChuyen,
			SoTramLuat,
			SoTramVe,
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
			@IDDanhMucTuyenVanTai,
			@SoTienVeCauDuong,
			@SoTienLuatAnCa,
			@SoTienLuuCaKhac,
			@SoTienLuatDuongCam,
			@SoTienLuongChuyen,
			@SoTramLuat,
			@SoTramVe,
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
alter procedure Update_DanhMucDinhMucChiPhi
	@ID									bigint,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucLoaiDoiTuong				bigint,
	@NgayApDung							date,
	@IDDanhMucTuyenVanTai				bigint,
	@SoTienVeCauDuong					float = null,
	@SoTienLuatAnCa						float = null,
	@SoTienLuuCaKhac					float = null,
	@SoTienLuatDuongCam					float = null,
	@SoTienLuongChuyen					float = null,
	@SoTramLuat							smallint = null,
	@SoTramVe							smallint = null,
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
		update DanhMucDinhMucChiPhi set
			NgayApDung = @NgayApDung,
			IDDanhMucTuyenVanTai = @IDDanhMucTuyenVanTai,
			SoTienVeCauDuong = @SoTienVeCauDuong,
			SoTienLuatAnCa = @SoTienLuatAnCa,
			SoTienLuuCaKhac = @SoTienLuuCaKhac,
			SoTienLuatDuongCam = @SoTienLuatDuongCam,
			SoTienLuongChuyen = @SoTienLuongChuyen,
			SoTramLuat = @SoTramLuat,
			SoTramVe = @SoTramVe,
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
alter procedure Delete_DanhMucDinhMucChiPhi
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucDinhMucChiPhi	where ID = @ID;
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
