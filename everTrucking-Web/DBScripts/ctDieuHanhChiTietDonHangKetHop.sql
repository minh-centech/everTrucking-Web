/*
create table ctDieuHanhChiTietDonHangKetHop
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	--
	IDChungTu						bigint not null, --ID đơn hàng
	IDChungTuChiTiet				bigint not null, --IDctDieuHanh
	IDctDonHang						bigint not null, --Số đơn hàng kết hợp
	GhiChu							nvarchar(255)
	--
	constraint PK_ctDieuHanhChiTietDonHangKetHop primary key (ID),
	constraint ctDieuHanhChiTietDonHangKetHop_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctDieuHanhChiTietDonHangKetHop foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctDieuHanhChiTietDonHangKetHop foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint ChungTu_ctDieuHanhChiTietDonHangKetHop foreign key (IDChungTu) references ctDonHang(ID),
	constraint ChungTuChiTiet_ctDieuHanhChiTietDonHangKetHop foreign key (IDChungTuChiTiet) references ctDieuHanh(ID),
	--
	constraint DonHang_ctDieuHanhChiTietDonHangKetHop foreign key (IDctDonHang) references ctDonHang(ID)
)
go
*/
---------------
alter procedure List_ctDieuHanhChiTietDonHangKetHop
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint
as
begin
	set nocount on;
	--
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDChungTu, --ID đơn hàng
		a.IDChungTuChiTiet, --IDctDieuHanh
		a.IDctDonHang, --Số đơn hàng kết hợp
		ctDonHang.DebitNote,
		ctDonHang.So SoDonHang,
		a.GhiChu
	from ctDieuHanhChiTietDonHangKetHop a
		left join ctDonHang on a.IDctDonHang = ctDonHang.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.IDChungTu = @ID;
	--
	select * from #ChungTu;
	--
	drop table #ChungTu;
end;
go
------------------
alter procedure Insert_ctDieuHanhChiTietDonHangKetHop
(
	@ID								bigint = null output,
	@IDDanhMucDonVi					bigint,
	@IDDanhMucChungTu				bigint,
	--
	@IDChungTu						bigint, --ID đơn hàng
	@IDChungTuChiTiet				bigint, --IDctDieuHanh
	@IDctDonHang					bigint, --Số đơn hàng kết hợp
	@GhiChu							nvarchar(255) = null
)
as
begin
	set nocount on;
	declare @Err int;
	begin tran
	begin try
	
	--
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctDieuHanhChiTietDonHangKetHop';
	insert	into ctDieuHanhChiTietDonHangKetHop
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		--
		IDChungTu,
		IDChungTuChiTiet,
		IDctDonHang,
		GhiChu
	)
	values
	(
		@ID,
		@IDDanhMucDonVi,
		@IDDanhMucChungTu,
		--
		@IDChungTu,
		@IDChungTuChiTiet,
		@IDctDonHang,
		@GhiChu
	)
	commit tran
	end try
	begin catch
		rollback
		declare @ErrMsg nvarchar(max)
		select @ErrMsg = error_message()
		raiserror(@ErrMsg, 16, 1)
	end catch
	set @Err = @@Error
	return @Err
end
go
--
alter procedure Update_ctDieuHanhChiTietDonHangKetHop
(
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	--
	@IDChungTu					bigint, --ID đơn hàng
	@IDChungTuChiTiet			bigint, --IDctDieuHanh
	@IDctDonHang				bigint, --Số đơn hàng kết hợp
	@GhiChu						nvarchar(255) = null
)
as
begin
	set nocount on;
	declare @Err int;
	begin tran
	begin try
	update ctDieuHanhChiTietDonHangKetHop
		set
			IDChungTu = @IDChungTu,
			IDChungTuChiTiet = @IDChungTuChiTiet,
			IDctDonHang = @IDctDonHang,
			GhiChu = @GhiChu
		where ID = @ID;
	commit tran
	end try
	begin catch
		rollback
		declare @ErrMsg nvarchar(max)
		select @ErrMsg = error_message()
		raiserror(@ErrMsg, 16, 1)
	end catch
	set @Err = @@Error
	return @Err
end
go
--
alter procedure Delete_ctDieuHanhChiTietDonHangKetHop
(
	@ID	bigint
)
as
begin
	set nocount on;
	declare @Err int;
	declare @NgayCapNhat datetime;
	select @NgayCapNhat = GETDATE()
	begin tran
	begin try
	--
	delete from ctDieuHanhChiTietDonHangKetHop where ID = @ID;
	delete from AutoID where ID = @ID;
	commit tran
	end try
	begin catch
		rollback
		declare @ErrMsg nvarchar(max)
		select @ErrMsg = error_message()
		raiserror(@ErrMsg, 16, 1)
	end catch
	set @Err = @@Error
	return @Err
end
go