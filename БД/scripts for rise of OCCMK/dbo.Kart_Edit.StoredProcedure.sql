USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[Kart_Edit]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Kart_Edit] 
@docID int,@doctype int,@obozn varchar(100),@name varchar(255),@dateenter datetime
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

AS BEGIN

BEGIN TRANSACTION

Update Kart set docTypeID = @doctype, obozn = @obozn, name = @name, dateEnter = @dateenter, docStatus = @stat
,docSecret = @secr, docDevel=@dev, dateProv = @dateprov, controlCopyExist = @contrcopy, original = @original, dateEndOfAction = @enddate 
where id = @docID     


update kart 
set Vzamen = @vzamen 
where id = @docID 
	
if @vzamen is not null
begin
	update kart 
	set Zamenen = @docID 
	where id = @vzamen
	
	--изменения Ильичев
	update kart
	set docStatus = 2--не действующий
	where id = @vzamen
	--конец изменений
end 
else
begin
	update kart 
	set Zamenen = null
	where Zamenen = @docID
end


update kart 
set Zamenen = @zamenen 
where id = @docID  
	
if @zamenen is not null
begin
	update kart 
	set Vzamen = @docID 
	where id = @zamenen
	
	--изменения Ильичев
	update kart
	set docStatus = 2--не действующий
	where id = @docID
	--конец изменений
end 
else
begin
	update kart
	set Vzamen = null
	where Vzamen  = @docID
end

update ActVnedren set number = @actvnednum,data = @actvneddate
where id = (select vnedrAct from kart where id = @docID)

update ActProverky set number = @actprovnum,data = @actprovdate
where id = (select provAct from kart where id = @docID)

update	DocVvodInfo	
set		vnedNumber = @poruchnum, vnedDate = @poruchdate, podrId = @podrId, orderNum = @ordernum
		,orderDate = @orderdate, endOTM = @otmdate, vvedDate = @vveddate
where	id = @docID

--изменения Чаленко
IF @doctype='1' 
BEGIN
	IF (EXISTS(
		SELECT 
			*
		FROM 
			ZaprosInfo 
		WHERE 
			docId = @docID)) 
	BEGIN
		UPDATE 
			ZaprosInfo 
		SET 
			number = @zapnum, 
			data = @zapdat, 
			addres = @zapadr 
		WHERE 
			docId = @docID 
	END
	ELSE
	BEGIN
		INSERT INTO 
			ZaprosInfo
		VALUES ( 
			@docID, 
			@zapnum, 
			@zapdat, 
			@zapadr )
	END
    
    IF (EXISTS(
		SELECT 
			*
		FROM 
			PoluchatelInfo 
		WHERE 
			docId = @docID)) 
	BEGIN
		UPDATE 
			PoluchatelInfo 
		SET 
			number = @polnum, 
			regdata = @polregdate, 
			poluchdate = @poldate, 
			kolvo = @kolvo, 
			addres = @poladr 
		WHERE 
			docId = @docID
	END
	ELSE
	BEGIN
		INSERT INTO 
			PoluchatelInfo
		VALUES ( 
			@docID, 
			@polnum, 
			@polregdate, 
			@poldate, 
			@kolvo, 
			@poladr )
	END
END 
ELSE
BEGIN
	IF (EXISTS(
		SELECT 
			*
		FROM 
			ZaprosInfo 
		WHERE 
			docId = @docID)) 
	BEGIN
		DELETE FROM 
			ZaprosInfo
		WHERE 
			docId = @docID 
	END
	
	IF (EXISTS(
		SELECT 
			*
		FROM 
			PoluchatelInfo 
		WHERE 
			docId = @docID)) 
	BEGIN
		DELETE FROM 
			PoluchatelInfo
		WHERE 
			docId = @docID 
	END
END
--конец изменений

IF @@ERROR = 0
COMMIT
ELSE
ROLLBACK

END
GO
