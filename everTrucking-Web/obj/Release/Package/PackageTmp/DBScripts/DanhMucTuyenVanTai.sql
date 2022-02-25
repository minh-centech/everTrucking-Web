/*
drop table DanhMucTuyenVanTai
create table DanhMucTuyenVanTai
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	--
	Ma							nvarchar(128)	not null,
	Ten							nvarchar(255)	not null,
	DiemDau						nvarchar(255)	not null,
	IDDanhMucTinhThanhDau		bigint			not null,
	DiemCuoi					nvarchar(255)	not null,
	IDDanhMucTinhThanhCuoi		bigint			not null,
	CuLy						float,
	GhiChu						nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucTuyenVanTai primary key (ID),
	constraint	DanhMucTuyenVanTai_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucTuyenVanTai foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucTuyenVanTai foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	constraint	Ma_DanhMucTuyenVanTai unique(Ma),
	--
	constraint	DanhMucTinhThanhDau_DanhMucTuyenVanTai foreign key (IDDanhMucTinhThanhDau) references DanhMucDoiTuong(ID),
	constraint	DanhMucTinhThanhCuoi_DanhMucTuyenVanTai foreign key (IDDanhMucTinhThanhCuoi) references DanhMucDoiTuong(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucTuyenVanTai foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucTuyenVanTai foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
create table DanhMucTuyenVanTaiDinhMucNhienLieu
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	--
	IDDanhMucTuyenVanTai		bigint			not null,
	NgayApDung					date			not null,
	IDDanhMucNhomXe				bigint			not null,
	IDDanhMucNhienLieu			bigint			not null,
	TaiTrongDau					float,
	TaiTrongCuoi				float,
	DinhMucNhienLieu1km			float,
	GhiChu						nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucTuyenVanTaiDinhMucNhienLieu primary key (ID),
	constraint	DanhMucDonVi_DanhMucTuyenVanTaiDinhMucNhienLieu foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucTuyenVanTaiDinhMucNhienLieu foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	--
	constraint	DanhMucTuyenVanTai_DanhMucTuyenVanTaiDinhMucNhienLieu foreign key (IDDanhMucTuyenVanTai) references DanhMucTuyenVanTai(ID),
	constraint	DanhMucNhomXe_DanhMucTuyenVanTaiDinhMucNhienLieu foreign key (IDDanhMucNhomXe) references DanhMucDoiTuong(ID),
	constraint	DanhMucNhienLieu_DanhMucTuyenVanTaiDinhMucNhienLieu foreign key (IDDanhMucNhienLieu) references DanhMucDoiTuong(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucTuyenVanTaiDinhMucNhienLieu foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucTuyenVanTaiDinhMucNhienLieu foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
create table DanhMucTuyenVanTaiDinhMucChiPhi
(
	ID									bigint			not null,
	IDDanhMucDonVi						bigint			not null,
	IDDanhMucLoaiDoiTuong				bigint			not null,
	--
	IDDanhMucTuyenVanTai				bigint			not null,
	ChieuVanTai							tinyint, --1--chiều đi, 2--chiều về
	NgayApDung							date			not null,
	IDDanhMucNhomXe						bigint			not null,
	IDDanhMucChiPhiDieuVanThuongXuyen	bigint			not null,
	SoLuong								float,
	SoTien								float,
	GhiChu								nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucTuyenVanTaiDinhMucChiPhi primary key (ID),
	constraint	DanhMucDonVi_DanhMucTuyenVanTaiDinhMucChiPhi foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucTuyenVanTaiDinhMucChiPhi foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	--
	constraint	DanhMucTuyenVanTai_DanhMucTuyenVanTaiDinhMucChiPhi foreign key (IDDanhMucTuyenVanTai) references DanhMucTuyenVanTai(ID),
	constraint	DanhMucNhomXe_DanhMucTuyenVanTaiDinhMucChiPhi foreign key (IDDanhMucNhomXe) references DanhMucDoiTuong(ID),
	constraint	DanhMucChiPhiDieuVanThuongXuyen_DanhMucTuyenVanTaiDinhMucChiPhi foreign key (IDDanhMucChiPhiDieuVanThuongXuyen) references DanhMucDoiTuong(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucTuyenVanTaiDinhMucChiPhi foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucTuyenVanTaiDinhMucChiPhi foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
alter procedure List_DanhMucTuyenVanTai
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
			a.DiemDau,
			a.IDDanhMucTinhThanhDau,
			TinhThanhDau.Ma MaDanhMucTinhThanhDau,
			TinhThanhDau.Ten TenDanhMucTinhThanhDau,
			a.DiemCuoi,
			a.IDDanhMucTinhThanhCuoi,
			TinhThanhCuoi.Ma MaDanhMucTinhThanhCuoi,
			TinhThanhCuoi.Ten TenDanhMucTinhThanhCuoi,
			a.CuLy,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
	into #DanhMucTuyenVanTai
	from DanhMucTuyenVanTai a 
			left join DanhMucDoiTuong TinhThanhDau on a.IDDanhMucTinhThanhDau = TinhThanhDau.ID
			left join DanhMucDoiTuong TinhThanhCuoi on a.IDDanhMucTinhThanhCuoi = TinhThanhCuoi.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi 
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	order by a.Ma;
	--
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.IDDanhMucTuyenVanTai,
			TuyenVanTai.Ma MaDanhMucTuyenVanTai,
			TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.NgayApDung,
			a.IDDanhMucNhomXe,
			NhomXe.Ma MaDanhMucNhomXe,
			NhomXe.Ten TenDanhMucNhomXe,
			a.IDDanhMucNhienLieu,
			NhienLieu.Ma MaDanhMucNhienLieu,
			NhienLieu.Ten TenDanhMucNhienLieu,
			a.TaiTrongDau,
			a.TaiTrongCuoi,
			a.DinhMucNhienLieu1km,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
	into #DanhMucTuyenVanTaiDinhMucNhienLieu
	from DanhMucTuyenVanTaiDinhMucNhienLieu a
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
			left join DanhMucDoiTuong NhomXe on a.IDDanhMucNhomXe = NhomXe.ID
			left join DanhMucDoiTuong NhienLieu on a.IDDanhMucNhienLieu = NhienLieu.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi 
		and a.IDDanhMucTuyenVanTai in (select ID from #DanhMucTuyenVanTai);
	--
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.IDDanhMucTuyenVanTai,
			TuyenVanTai.Ma MaDanhMucTuyenVanTai,
			TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.ChieuVanTai,
			a.NgayApDung,
			a.IDDanhMucNhomXe,
			NhomXe.Ma MaDanhMucNhomXe,
			NhomXe.Ten TenDanhMucNhomXe,
			a.IDDanhMucChiPhiDieuVanThuongXuyen,
			ChiPhiDieuVanThuongXuyen.Ma MaDanhMucChiPhiDieuVanThuongXuyen,
			ChiPhiDieuVanThuongXuyen.Ten TenDanhMucChiPhiDieuVanThuongXuyen,
			a.SoLuong,
			a.SoTien,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
	into #DanhMucTuyenVanTaiDinhMucChiPhi
	from DanhMucTuyenVanTaiDinhMucChiPhi a
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
			left join DanhMucDoiTuong NhomXe on a.IDDanhMucNhomXe = NhomXe.ID
			left join DanhMucDoiTuong ChiPhiDieuVanThuongXuyen on a.IDDanhMucChiPhiDieuVanThuongXuyen = ChiPhiDieuVanThuongXuyen.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi 
		and a.IDDanhMucTuyenVanTai in (select ID from #DanhMucTuyenVanTai);
	--
	select * from #DanhMucTuyenVanTai;
	select * from #DanhMucTuyenVanTaiDinhMucNhienLieu;
	select * from #DanhMucTuyenVanTaiDinhMucChiPhi;
	--
	drop table #DanhMucTuyenVanTaiDinhMucChiPhi;
	drop table #DanhMucTuyenVanTaiDinhMucNhienLieu;
	drop table #DanhMucTuyenVanTai;
end
go
--
alter procedure Insert_DanhMucTuyenVanTai
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@DiemDau					nvarchar(255),
	@IDDanhMucTinhThanhDau		bigint,
	@DiemCuoi					nvarchar(255),
	@IDDanhMucTinhThanhCuoi		bigint,
	@CuLy						float,
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
		insert DanhMucTuyenVanTai 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			Ma,
			Ten,
			DiemDau,
			IDDanhMucTinhThanhDau,
			DiemCuoi,
			IDDanhMucTinhThanhCuoi,
			CuLy,
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
			@DiemDau,
			@IDDanhMucTinhThanhDau,
			@DiemCuoi,
			@IDDanhMucTinhThanhCuoi,
			@CuLy,
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
alter procedure Update_DanhMucTuyenVanTai
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@DiemDau					nvarchar(255),
	@IDDanhMucTinhThanhDau		bigint,
	@DiemCuoi					nvarchar(255),
	@IDDanhMucTinhThanhCuoi		bigint,
	@CuLy						float,
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
		update DanhMucTuyenVanTai set
			Ma = @Ma,
			Ten = @Ten,
			DiemDau = @DiemDau,
			IDDanhMucTinhThanhDau = @IDDanhMucTinhThanhDau,
			DiemCuoi = @DiemCuoi,
			IDDanhMucTinhThanhCuoi = IDDanhMucTinhThanhCuoi,
			CuLy = @CuLy,
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
alter procedure Delete_DanhMucTuyenVanTai
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		--Xóa danh mục giấy tờ xe
		declare @IDChiTiet bigint;
		--
		declare curCT cursor for select ID from DanhMucTuyenVanTaiDinhMucNhienLieu where IDDanhMucTuyenVanTai = @ID;
		open curCT;
		fetch next from curCT into @IDChiTiet
		while @@FETCH_STATUS = 0
		begin
			delete from DanhMucTuyenVanTaiDinhMucNhienLieu where ID = @IDChiTiet;
			delete from AutoID where ID = @IDChiTiet;
			fetch next from curCT into @IDChiTiet;
		end;
		deallocate curCT;
		--
		declare curCT cursor for select ID from DanhMucTuyenVanTaiDinhMucChiPhi where IDDanhMucTuyenVanTai = @ID;
		open curCT;
		fetch next from curCT into @IDChiTiet
		while @@FETCH_STATUS = 0
		begin
			delete from DanhMucTuyenVanTaiDinhMucChiPhi where ID = @IDChiTiet;
			delete from AutoID where ID = @IDChiTiet;
			fetch next from curCT into @IDChiTiet;
		end;
		deallocate curCT;
		--
		delete DanhMucTuyenVanTai	where ID = @ID;
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
alter procedure Insert_DanhMucTuyenVanTaiDinhMucNhienLieu
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@IDDanhMucTuyenVanTai		bigint,
	@NgayApDung					date,
	@IDDanhMucNhomXe			bigint,
	@IDDanhMucNhienLieu			bigint,
	@TaiTrongDau				float,
	@TaiTrongCuoi				float,
	@DinhMucNhienLieu1km		float,
	@GhiChu						nvarchar(512) = null,
	@IDDanhMucNguoiSuDungCreate	bigint,
	@CreateDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_DanhMucDoiTuong @ID out, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, null, null, @IDDanhMucNguoiSuDungCreate, @CreateDate out;
		insert DanhMucTuyenVanTaiDinhMucNhienLieu 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			IDDanhMucTuyenVanTai,
			NgayApDung,
			IDDanhMucNhomXe,
			IDDanhMucNhienLieu,
			TaiTrongDau,
			TaiTrongCuoi,
			DinhMucNhienLieu1km,
			GhiChu,
			IDDanhMucNguoiSuDungCreate, 
			CreateDate
		) 
		values 
		(	
			@ID, 
			@IDDanhMucDonVi, 
			@IDDanhMucLoaiDoiTuong, 
			@IDDanhMucTuyenVanTai,
			@NgayApDung,
			@IDDanhMucNhomXe,
			@IDDanhMucNhienLieu,
			@TaiTrongDau,
			@TaiTrongCuoi,
			@DinhMucNhienLieu1km,
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
alter procedure Update_DanhMucTuyenVanTaiDinhMucNhienLieu
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@IDDanhMucTuyenVanTai		bigint,
	@NgayApDung					date,
	@IDDanhMucNhomXe			bigint,
	@IDDanhMucNhienLieu			bigint,
	@TaiTrongDau				float,
	@TaiTrongCuoi				float,
	@DinhMucNhienLieu1km		float,
	@GhiChu						nvarchar(512) = null,
	@IDDanhMucNguoiSuDungEdit	bigint,
	@EditDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Update_DanhMucDoiTuong @ID, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, null, null, @IDDanhMucNguoiSuDungEdit, @EditDate out
		update DanhMucTuyenVanTaiDinhMucNhienLieu set
			IDDanhMucTuyenVanTai = @IDDanhMucTuyenVanTai,
			NgayApDung = @NgayApDung,
			IDDanhMucNhomXe = @IDDanhMucNhomXe,
			IDDanhMucNhienLieu = @IDDanhMucNhienLieu,
			TaiTrongDau = @TaiTrongDau,
			TaiTrongCuoi = @TaiTrongCuoi,
			DinhMucNhienLieu1km = @DinhMucNhienLieu1km,
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
alter procedure Delete_DanhMucTuyenVanTaiDinhMucNhienLieu
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucTuyenVanTaiDinhMucNhienLieu where ID = @ID;
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
alter procedure Insert_DanhMucTuyenVanTaiDinhMucChiPhi
	@ID									bigint out,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucLoaiDoiTuong				bigint,
	@IDDanhMucTuyenVanTai				bigint,
	@ChieuVanTai						tinyint, --1--chiều đi, 2--chiều về
	@NgayApDung							date,
	@IDDanhMucNhomXe					bigint,
	@IDDanhMucChiPhiDieuVanThuongXuyen	bigint,
	@SoLuong							float,
	@SoTien								float,
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
		insert DanhMucTuyenVanTaiDinhMucChiPhi 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			IDDanhMucTuyenVanTai,
			ChieuVanTai,
			NgayApDung,
			IDDanhMucNhomXe,
			IDDanhMucChiPhiDieuVanThuongXuyen,
			SoLuong,
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
			@IDDanhMucTuyenVanTai,
			@ChieuVanTai,
			@NgayApDung,
			@IDDanhMucNhomXe,
			@IDDanhMucChiPhiDieuVanThuongXuyen,
			@SoLuong,
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
alter procedure Update_DanhMucTuyenVanTaiDinhMucChiPhi
	@ID									bigint,
	@IDDanhMucDonVi						bigint,
	@IDDanhMucLoaiDoiTuong				bigint,
	@IDDanhMucTuyenVanTai				bigint,
	@ChieuVanTai						tinyint, --1--chiều đi, 2--chiều về
	@NgayApDung							date,
	@IDDanhMucNhomXe					bigint,
	@IDDanhMucChiPhiDieuVanThuongXuyen	bigint,
	@SoLuong							float,
	@SoTien								float,
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
		update DanhMucTuyenVanTaiDinhMucChiPhi set
			IDDanhMucTuyenVanTai = @IDDanhMucTuyenVanTai,
			ChieuVanTai = @ChieuVanTai,
			NgayApDung = @NgayApDung,
			IDDanhMucNhomXe = @IDDanhMucNhomXe,
			IDDanhMucChiPhiDieuVanThuongXuyen = @IDDanhMucChiPhiDieuVanThuongXuyen,
			SoLuong = @SoLuong,
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
alter procedure Delete_DanhMucTuyenVanTaiDinhMucChiPhi
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucTuyenVanTaiDinhMucChiPhi where ID = @ID;
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
create procedure List_DanhMucTuyenVanTai_byID
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint
as
begin
	set nocount on;
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.Ma,
			a.Ten,
			a.DiemDau,
			a.IDDanhMucTinhThanhDau,
			TinhThanhDau.Ma MaDanhMucTinhThanhDau,
			TinhThanhDau.Ten TenDanhMucTinhThanhDau,
			a.DiemCuoi,
			a.IDDanhMucTinhThanhCuoi,
			TinhThanhCuoi.Ma MaDanhMucTinhThanhCuoi,
			TinhThanhCuoi.Ten TenDanhMucTinhThanhCuoi,
			a.CuLy,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
	from DanhMucTuyenVanTai a 
			left join DanhMucDoiTuong TinhThanhDau on a.IDDanhMucTinhThanhDau = TinhThanhDau.ID
			left join DanhMucDoiTuong TinhThanhCuoi on a.IDDanhMucTinhThanhCuoi = TinhThanhCuoi.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi 
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and a.ID = @ID
	order by a.Ma;
end
go
--