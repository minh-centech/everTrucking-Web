/*
drop table DanhMucNhanSu
create drop table DanhMucNhanSu
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	Ma							nvarchar(128)	not null,
	Ten							nvarchar(255)	not null,
	--
	IDDanhMucPhongBan			bigint			not null,
	IDDanhMucPhanLoaiChucVu		bigint			not null,
	NguyenQuan					nvarchar(512)	not null,
	DiaChiThuongTru				nvarchar(512)	not null,
	NgaySinh					date			not null,
	SoCMND						nvarchar(12)	not null,
	NgayCap						date			not null,
	NoiCap						nvarchar(255)	not null,
	SoDienThoai					nvarchar(128),
	MaSoThue					nvarchar(10),
	SoTaiKhoan					nvarchar(255),
	Email						nvarchar(255),
	TrinhDo						nvarchar(255),
	NgayVaoLam					date			not null,
	IDDanhMucTinhTrangLamViec	bigint			not null,
	HinhAnh						varbinary(max),
	GhiChu						nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucNhanSu primary key (ID),
	constraint	DanhMucNhanSu_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucNhanSu foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucNhanSu foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	constraint	Ma_DanhMucNhanSu unique(Ma),
	--
	constraint	DanhMucPhongBan_DanhMucNhanSu foreign key (IDDanhMucPhongBan) references DanhMucDoiTuong(ID),
	constraint	DanhMucPhanLoaiChucVu_DanhMucNhanSu foreign key (IDDanhMucPhanLoaiChucVu) references DanhMucDoiTuong(ID),
	constraint	DanhMucTinhTrangLamViec_DanhMucNhanSu foreign key (IDDanhMucTinhTrangLamViec) references DanhMucDoiTuong(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucNhanSu foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucNhanSu foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
alter drop procedure List_DanhMucNhanSu
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
			a.Ma,
			a.Ten,
			a.IDDanhMucPhongBan,
			PhongBan.Ma MaDanhMucPhongBan,
			PhongBan.Ten TenDanhMucPhongBan,
			a.IDDanhMucPhanLoaiChucVu,
			PhanLoaiChucVu.Ma MaDanhMucPhanLoaiChucVu,
			PhanLoaiChucVu.Ten TenDanhMucPhanLoaiChucVu,
			a.NguyenQuan,
			a.DiaChiThuongTru,
			a.NgaySinh,
			a.SoCMND,
			a.NgayCap,
			a.NoiCap,
			a.SoDienThoai,
			a.MaSoThue,
			a.SoTaiKhoan,
			a.Email,
			a.TrinhDo,
			a.NgayVaoLam,
			a.IDDanhMucTinhTrangLamViec,
			TinhTrangLamViec.Ma MaDanhMucTinhTrangLamViec,
			TinhTrangLamViec.Ten TenDanhMucTinhTrangLamViec,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		from DanhMucNhanSu a 
			left join DanhMucDoiTuong PhongBan on a.IDDanhMucPhongBan = PhongBan.ID
			left join DanhMucDoiTuong PhanLoaiChucVu on a.IDDanhMucPhanLoaiChucVu = PhanLoaiChucVu.ID
			left join DanhMucDoiTuong TinhTrangLamViec on a.IDDanhMucTinhTrangLamViec = TinhTrangLamViec.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi 
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	order by a.Ma;
end
go
--
--
alter drop procedure List_DanhMucNhanSu_HinhAnh
	@ID bigint
as
begin
	set nocount on;
	select	a.HinhAnh
		from DanhMucNhanSu a 
	where a.ID = @ID;
end
go
--
--
alter drop procedure Insert_DanhMucNhanSu
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@IDDanhMucPhongBan			bigint,
	@IDDanhMucPhanLoaiChucVu	bigint,
	@NguyenQuan					nvarchar(512),
	@DiaChiThuongTru			nvarchar(512),
	@NgaySinh					date,
	@SoCMND						nvarchar(12),
	@NgayCap					date,
	@NoiCap						nvarchar(255),
	@SoDienThoai				nvarchar(128) = null,
	@MaSoThue					nvarchar(10) = null,
	@SoTaiKhoan					nvarchar(255) = null,
	@Email						nvarchar(255) = null,
	@TrinhDo					nvarchar(255) = null,
	@NgayVaoLam					date,
	@IDDanhMucTinhTrangLamViec	bigint,
	@HinhAnh					varbinary(max) = null,
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
		insert DanhMucNhanSu 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			Ma,
			Ten,
			IDDanhMucPhongBan,
			IDDanhMucPhanLoaiChucVu,
			NguyenQuan,
			DiaChiThuongTru,
			NgaySinh,
			SoCMND,
			NgayCap,
			NoiCap,
			SoDienThoai,
			MaSoThue,
			SoTaiKhoan,
			Email,
			TrinhDo,
			NgayVaoLam,
			IDDanhMucTinhTrangLamViec,
			HinhAnh,
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
			@IDDanhMucPhongBan,
			@IDDanhMucPhanLoaiChucVu,
			@NguyenQuan,
			@DiaChiThuongTru,
			@NgaySinh,
			@SoCMND,
			@NgayCap,
			@NoiCap,
			@SoDienThoai,
			@MaSoThue,
			@SoTaiKhoan,
			@Email,
			@TrinhDo,
			@NgayVaoLam,
			@IDDanhMucTinhTrangLamViec,
			@HinhAnh,
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
alter drop procedure Update_DanhMucNhanSu
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@IDDanhMucPhongBan			bigint,
	@IDDanhMucPhanLoaiChucVu	bigint,
	@NguyenQuan					nvarchar(512),
	@DiaChiThuongTru			nvarchar(512),
	@NgaySinh					date,
	@SoCMND						nvarchar(12),
	@NgayCap					date,
	@NoiCap						nvarchar(255),
	@SoDienThoai				nvarchar(128) = null,
	@MaSoThue					nvarchar(10) = null,
	@SoTaiKhoan					nvarchar(255) = null,
	@Email						nvarchar(255) = null,
	@TrinhDo					nvarchar(255) = null,
	@NgayVaoLam					date,
	@IDDanhMucTinhTrangLamViec	bigint,
	@HinhAnh					varbinary(max) = null,
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
		update DanhMucNhanSu set
			Ma = @Ma,
			Ten = @Ten,
			IDDanhMucPhongBan = @IDDanhMucPhongBan,
			IDDanhMucPhanLoaiChucVu = @IDDanhMucPhanLoaiChucVu,
			NguyenQuan = @NguyenQuan,
			DiaChiThuongTru = @DiaChiThuongTru,
			NgaySinh = @NgaySinh,
			SoCMND = @SoCMND,
			NgayCap = @NgayCap,
			NoiCap = @NoiCap,
			SoDienThoai = @SoDienThoai,
			MaSoThue = @MaSoThue,
			SoTaiKhoan = @SoTaiKhoan,
			Email = @Email,
			TrinhDo = @TrinhDo,
			NgayVaoLam = @NgayVaoLam,
			IDDanhMucTinhTrangLamViec = @IDDanhMucTinhTrangLamViec,
			HinhAnh = @HinhAnh,
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
alter drop procedure Delete_DanhMucNhanSu
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucNhanSu	where ID = @ID;
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
