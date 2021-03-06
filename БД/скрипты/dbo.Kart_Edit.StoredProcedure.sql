USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[Kart_Edit]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kart_Edit] 
		@docID int
		,@doctype int
		,@obozn varchar(100)
		,@name varchar(255)
		,@dateenter datetime
		,@stat int
		,@secr int
		,@dev int
		,@dateprov datetime
		,@contrcopy bit
		,@original bit
		,@enddate datetime
		--информация о запросе
		,@zapnum varchar(100) = null
		,@zapdat datetime = null
		,@zapadr int = null
		--информация о получении
		,@polnum varchar(100) = null
		,@polregdate datetime = null
		,@poldate datetime = null
		,@kolvo int = null
		,@poladr int = null
		--взамен
		,@vzamen int
		--заменен
		,@zamenen int
		--информация о введении в действие документа на предприятии
		,@poruchnum varchar(100)
		,@poruchdate datetime
		,@podrId varchar(20)
		,@ordernum varchar(100)
		,@orderdate datetime
		,@otmdate datetime
		,@vveddate datetime 
		--акт о внедрении докумнета
		,@actvnednum varchar(100)
		,@actvneddate datetime
		-- акт о проверки докумнета
		,@actprovnum varchar(100)
		,@actprovdate datetime
		--изменения(поправки)
		,@chtabname varchar(100)
		--документ выдан в подразделение
		,@docpodr varchar(100)

AS BEGIN

BEGIN TRANSACTION

UPDATE Kart 
SET 
	docTypeID = @doctype
	,obozn = @obozn
	,name = @name
	,dateEnter = @dateenter
	,docStatus = @stat
	,docSecret = @secr
	,docDevel=@dev
	,dateProv = @dateprov
	,controlCopyExist = @contrcopy
	,original = @original
	,dateEndOfAction = @enddate
WHERE id = @docID     


UPDATE kart
SET Vzamen = @vzamen 
WHERE id = @docID 
	
IF @vzamen IS NOT NULL
BEGIN
	UPDATE kart 
	SET Zamenen = @docID 
	WHERE id = @vzamen
	
	--изменения Ильичев
	UPDATE kart
	SET docStatus = 2--не действующий
	WHERE id = @vzamen
	--конец изменений
END 
ELSE
BEGIN
	UPDATE kart 
	SET Zamenen = null
	WHERE Zamenen = @docID
END


UPDATE kart 
SET Zamenen = @zamenen 
WHERE id = @docID  
	
IF @zamenen is not null
BEGIN
	UPDATE kart 
	SET Vzamen = @docID 
	WHERE id = @zamenen
	
	--изменения Ильичев
	UPDATE kart
	SET docStatus = 2--не действующий
	WHERE id = @docID
	--конец изменений
END 
ELSE
BEGIN
	UPDATE kart
	SET Vzamen = null
	WHERE Vzamen  = @docID
END

UPDATE ActVnedren 
SET 
	number = @actvnednum
	,data = @actvneddate
WHERE id = (SELECT vnedrAct FROM kart WHERE id = @docID)

UPDATE ActProverky 
SET 
	number = @actprovnum
	,data = @actprovdate
WHERE id = (SELECT provAct FROM kart WHERE id = @docID)

UPDATE DocVvodInfo	
SET 
	vnedNumber = @poruchnum
	,vnedDate = @poruchdate
	,podrId = @podrId
	,orderNum = @ordernum
	,orderDate = @orderdate
	,endOTM = @otmdate
	,vvedDate = @vveddate
WHERE id = @docID

--изменения Чаленко
IF @doctype='1' 
BEGIN
	IF (EXISTS(
		SELECT *
		FROM ZaprosInfo 
		WHERE docId = @docID)) 
	BEGIN
		UPDATE ZaprosInfo 
		SET 
			number = @zapnum, 
			data = @zapdat, 
			addres = @zapadr 
		WHERE docId = @docID 
	END
	ELSE
	BEGIN
		INSERT INTO ZaprosInfo
		VALUES ( 
			@docID, 
			@zapnum, 
			@zapdat, 
			@zapadr )
	END
    
    IF (EXISTS(
		SELECT *
		FROM PoluchatelInfo 
		WHERE docId = @docID)) 
	BEGIN
		UPDATE PoluchatelInfo 
		SET 
			number = @polnum, 
			regdata = @polregdate, 
			poluchdate = @poldate, 
			kolvo = @kolvo, 
			addres = @poladr 
		WHERE docId = @docID
	END
	ELSE
	BEGIN
		INSERT INTO PoluchatelInfo
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
		SELECT *
		FROM ZaprosInfo 
		WHERE docId = @docID)) 
	BEGIN
		DELETE FROM ZaprosInfo
		WHERE docId = @docID 
	END
	
	IF (EXISTS(
		SELECT *
		FROM PoluchatelInfo 
		WHERE docId = @docID)) 
	BEGIN
		DELETE FROM PoluchatelInfo
		WHERE docId = @docID 
	END
END
--конец изменений

IF @@ERROR = 0
COMMIT
ELSE
ROLLBACK

END
GO
