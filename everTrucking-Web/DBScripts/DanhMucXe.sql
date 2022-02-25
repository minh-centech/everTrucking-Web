/*
drop table DanhMucXe
create table DanhMucXe
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	--
	BienSo						nvarchar(128)	not null,
	IDDanhMucNhomXe				bigint			not null,
	IDDanhMucNhienLieu			bigint			not null,
	IDDanhMucThauPhu			bigint,
	IDDanhMucNhomHangVanChuyen	bigint,
	MaTaiKhoanDoanhThu			nvarchar(128),
	MaTaiKhoanChietKhau			nvarchar(128),
	HinhAnhMatTruoc				varbinary(max),
	HinhAnhNgang				varbinary(max),
	GhiChu						nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucXe primary key (ID),
	constraint	DanhMucXe_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucXe foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucXe foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	constraint	BienSo_DanhMucXe unique(BienSo),
	--
	constraint	DanhMucNhomXe_DanhMucXe foreign key (IDDanhMucNhomXe) references DanhMucDoiTuong(ID),
	constraint	DanhMucNhienLieu_DanhMucXe foreign key (IDDanhMucNhienLieu) references DanhMucDoiTuong(ID),
	constraint DanhMucThauPhu_DanhMucXe foreign key (IDDanhMucThauPhu) references DanhMucThauPhu(ID),
	constraint DanhMucNhomHangVanChuyen_DanhMucXe foreign key (IDDanhMucNhomHangVanChuyen) references DanhMucDoiTuong(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucXe foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucXe foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
alter procedure List_DanhMucXe
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint,
	@IDDanhMucThauPhu bigint = null,
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
			a.BienSo,
			a.IDDanhMucNhomXe,
			NhomXe.Ma MaDanhMucNhomXe,
			NhomXe.Ten TenDanhMucNhomXe,
			a.IDDanhMucNhienLieu,
			NhienLieu.Ma MaDanhMucNhienLieu,
			NhienLieu.Ten TenDanhMucNhienLieu,
			a.IDDanhMucThauPhu,
			ThauPhu.Ma MaDanhMucThauPhu,
			ThauPhu.Ten TenDanhMucThauPhu,
			a.IDDanhMucNhomHangVanChuyen,
			NhomHangVanChuyen.Ma MaDanhMucNhomHangVanChuyen,
			NhomHangVanChuyen.Ten TenDanhMucNhomHangVanChuyen,
			a.MaTaiKhoanDoanhThu,
			a.MaTaiKhoanChietKhau,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
	from DanhMucXe a 
			left join DanhMucDoiTuong NhomXe on a.IDDanhMucNhomXe = NhomXe.ID
			left join DanhMucDoiTuong NhienLieu on a.IDDanhMucNhienLieu = NhienLieu.ID
			left join DanhMucThauPhu ThauPhu on a.IDDanhMucThauPhu = ThauPhu.ID
			left join DanhMucDoiTuong NhomHangVanChuyen on a.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi 
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		--and case when @IDDanhMucThauPhu is not null then a.IDDanhMucThauPhu else -1 end = ISNULL(@IDDanhMucThauPhu, -1) 
		--and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else -1 end = ISNULL(@IDDanhMucNhomHangVanChuyen, -1)
		and case when @ID is not null then a.ID else -1 end = ISNULL(@ID, -1) 
		and a.BienSo like @SearchStr
	order by a.BienSo;
end
go
--
--
alter procedure List_DanhMucXe_HinhAnh
	@ID bigint
as
begin
	set nocount on;
	select	a.HinhAnhMatTruoc, a.HinhAnhNgang
		from DanhMucXe a 
	where a.ID = @ID;
end
go
--
--
alter procedure Insert_DanhMucXe
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@BienSo						nvarchar(128),
	@IDDanhMucNhomXe			bigint,
	@IDDanhMucNhienLieu			bigint,
	@IDDanhMucThauPhu			bigint = null,
	@IDDanhMucNhomHangVanChuyen	bigint = null,
	@MaTaiKhoanDoanhThu			nvarchar(128) = null,
	@MaTaiKhoanChietKhau		nvarchar(128) = null,
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
		insert DanhMucXe 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			BienSo,
			IDDanhMucNhomXe,
			IDDanhMucNhienLieu,
			IDDanhMucThauPhu,
			IDDanhMucNhomHangVanChuyen,
			MaTaiKhoanDoanhThu,
			MaTaiKhoanChietKhau,
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
			@IDDanhMucNhomXe,
			@IDDanhMucNhienLieu,
			@IDDanhMucThauPhu,
			@IDDanhMucNhomHangVanChuyen,
			@MaTaiKhoanDoanhThu,
			@MaTaiKhoanChietKhau,
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
alter procedure Update_DanhMucXe
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@BienSo						nvarchar(128),
	@IDDanhMucNhomXe			bigint,
	@IDDanhMucNhienLieu			bigint,
	@IDDanhMucThauPhu			bigint = null,
	@IDDanhMucNhomHangVanChuyen	bigint = null,
	@MaTaiKhoanDoanhThu			nvarchar(128) = null,
	@MaTaiKhoanChietKhau		nvarchar(128) = null,
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
		update DanhMucXe set
			BienSo = @BienSo,
			IDDanhMucNhomXe = @IDDanhMucNhomXe,
			IDDanhMucNhienLieu = @IDDanhMucNhienLieu,
			IDDanhMucThauPhu = @IDDanhMucThauPhu,
			IDDanhMucNhomHangVanChuyen = @IDDanhMucNhomHangVanChuyen,
			MaTaiKhoanDoanhThu = @MaTaiKhoanDoanhThu,
			MaTaiKhoanChietKhau = @MaTaiKhoanChietKhau,
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
alter procedure Delete_DanhMucXe
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucXe where ID = @ID;
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
