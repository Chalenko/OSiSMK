USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[Kart_Add]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Kart_Add] 
@doctype int,@obozn varchar(100),@name varchar(255),@dateenter datetime
,@stat int,@secr int,@dev int,@dateprov datetime,@contrcopy bit,@original bit,@enddate datetime
--информация о запросе
,@zapnum varchar(100) = null,@zapdat datetime = null,@zapadr int = null
--информация о получении
,@polnum varchar(100) = null,@polregdate datetime = null ,@poldate datetime = null,@kolvo int = null,@poladr int = null
--взамен
,@vzamen int
--заменен
,@zamenen int
--информация о введении в действие документа на предприятии
,@poruchnum varchar(100),@poruchdate datetime,@podrId varchar(20),@ordernum varchar(100)
,@orderdate datetime,@otmdate datetime,@vveddate datetime 
--акт о внедрении докумнета
,@actvnednum varchar(100),@actvneddate datetime
-- акт о проверки докумнета
,@actprovnum varchar(100),@actprovdate datetime
--изменения(поправки)
,@chtabname varchar(100)
--документ выдан в подразделение
,@docpodr varchar(100)


as begin

set dateformat dmy

BEGIN TRANSACTION

insert into ActVnedren values 
(@actvnednum,@actvneddate)
declare @vactid int
set @vactid = @@identity


insert into dbo.ActProverky values
(@actprovnum,@actprovdate) 
declare @pactid int
set @pactid = @@identity


insert into kart values
(@doctype,@obozn,@name,@dateenter,@stat,@secr,@dev,null,null,@vactid,@pactid,@dateprov,@contrcopy,@original,@enddate)
declare @kartid int
set @kartid = @@identity

if @doctype='1'--внешний
begin
    insert into ZaprosInfo values
    (@kartid,@zapnum,@zapdat,@zapadr)
    
    insert into PoluchatelInfo values 
    (@kartid,@polnum,@polregdate,@poldate,@kolvo,@poladr)
end 

if @vzamen is not null
begin
	update kart 
	set Vzamen = @vzamen 
	where id = @kartid 
	
	update kart 
	set Zamenen = @kartid
	where id = @vzamen
	
	--изменения Ильичев
	update kart
	set docStatus = 2--не действующий
	where id = @vzamen
	--конец изменений
end 

if @zamenen is not null
begin
	update kart 
	set Zamenen = @zamenen 
	where id = @kartid 
	
	update kart 
	set Vzamen = @kartid
	where id = @zamenen
	
	--изменения Ильичев
	update kart
	set docStatus = 2--не действующий
	where id = @kartid
	--конец изменений
end 

insert into DocVvodInfo values
(@kartid,@poruchnum,@poruchdate,@podrId,@ordernum,@orderdate,@otmdate,@vveddate)


declare @sql varchar(250)
set @sql = 'Update '+ @chtabname +' set docid='+cast(@kartid as varchar)+''
exec (@sql)

declare @sql2 varchar(250)
set @sql2 = 'Insert into docchange (docid,Number,regDoc,regDate,vvodDate) select docId,number,regDoc,regDate,vvodDate from '+@chtabname+''
exec (@sql2)



declare @sql3 varchar(250)
set @sql3 = 'Update '+ @docpodr +' set docid='+cast(@kartid as varchar)+''
exec (@sql3)

declare @sql4 varchar(250)
set @sql4 = 'Insert into podrdoc (docid,podrId,givedate,takedate,giveto,copyName,copyStatus) select docid,podrId,givedate,takedate,giveto,copyName,copyStatus from '+@docpodr+''
exec (@sql4)



IF @@ERROR = 0
COMMIT
ELSE 
ROLLBACK

end
GO
