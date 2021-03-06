--ĐẾM SỐ BẢN GHI TRONG 1 TABLE

create procedure countID
	@TableName nvarchar(512) = 'DanhMucKhachHang', 
	@countID bigint = 0 out
as

create table #countID
(
	countID bigint
);

declare @strSQL nvarchar(max) = 'insert into #countID select count(ID) from ' + @TableName;

exec sp_executesql @strSQL;

select @countID = (select top 1 countID from #countID);

select @countID;

drop table #countID;

/*	SPLIT STRING
declare @orgString nvarchar(512) = 'aaa;bbbl;ccc;ddd',
		@splitChr nvarchar(1) = ';',
		@result nvarchar(128);
if charindex(@splitChr, @orgString, 1) > 0
begin
	while charindex(@splitChr, @orgString, 1) > 0
	begin
		set @result = left(@orgString, charindex(@splitChr, @orgString, 1) - 1);
		set @orgString = substring(@orgString, charindex(@splitChr, @orgString, 1) + 1, len(@orgString) - charindex(@splitChr, @orgString, 1));
		select @result;
		select @orgString;
	end;
end
else
begin
	set @result = @orgString;
	set @orgString = '';
	select @result;
	select @orgString;
end;
*/