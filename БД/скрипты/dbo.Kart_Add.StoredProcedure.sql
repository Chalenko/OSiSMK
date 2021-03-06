USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[Kart_Add]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kart_Add] 
	@doctype int
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

SET DATEFORMAT dmy

BEGIN TRANSACTION

INSERT INTO ActVnedren 
VALUES (
	@actvnednum
	,@actvneddate)
DECLARE @vactid int
SET @vactid = @@identity


INSERT INTO ActProverky 
VALUES (
	@actprovnum
	,@actprovdate) 
DECLARE @pactid int
SET @pactid = @@identity


INSERT INTO kart 
VALUES (
	@doctype
	,@obozn
	,@name
	,@dateenter
	,@stat
	,@secr
	,@dev
	,null
	,null
	,@vactid
	,@pactid
	,@dateprov
	,@contrcopy
	,@original
	,@enddate)
DECLARE @kartid int
SET @kartid = @@identity


IF @doctype='1'--внешний
BEGIN
    INSERT INTO ZaprosInfo 
    VALUES (
		@kartid
		,@zapnum
		,@zapdat
		,@zapadr)
    
    INSERT INTO PoluchatelInfo 
    VALUES (
		@kartid
		,@polnum
		,@polregdate
		,@poldate
		,@kolvo
		,@poladr)
END 


IF @vzamen IS NOT NULL
BEGIN
	UPDATE kart 
	SET Vzamen = @vzamen 
	WHERE id = @kartid 
	
	UPDATE kart 
	SET Zamenen = @kartid
	WHERE id = @vzamen
	
	--изменения Ильичев
	UPDATE kart
	SET docStatus = 2--не действующий
	WHERE id = @vzamen
	--конец изменений
END 


IF @zamenen IS NOT NULL
BEGIN
	UPDATE kart 
	SET Zamenen = @zamenen 
	WHERE id = @kartid 
	
	UPDATE kart 
	SET Vzamen = @kartid
	WHERE id = @zamenen
	
	--изменения Ильичев
	UPDATE kart
	SET docStatus = 2--не действующий
	WHERE id = @kartid
	--конец изменений
END 


INSERT INTO DocVvodInfo 
VALUES (
	@kartid
	,@poruchnum
	,@poruchdate
	,@podrId
	,@ordernum
	,@orderdate
	,@otmdate
	,@vveddate)


DECLARE @sql varchar(250)
SET @sql = 'UPDATE ' + @chtabname + ' 
			SET docid = ' + CAST(@kartid AS varchar) + ''
EXEC (@sql)


DECLARE @sql2 varchar(250)
SET @sql2 = 'INSERT INTO docchange (
				docid
				,Number
				,regDoc
				,regDate
				,vvodDate) 
			SELECT 
				docId
				,number
				,regDoc
				,regDate
				,vvodDate 
			FROM ' + @chtabname + ''
EXEC (@sql2)


DECLARE @sql3 varchar(250)
SET @sql3 = 'UPDATE ' + @docpodr + ' 
			SET docid = ' + CAST(@kartid AS varchar) + ''
EXEC (@sql3)


DECLARE @sql4 varchar(250)
SET @sql4 = 'INSERT INTO podrdoc (
				docid
				,podrId
				,givedate
				,takedate
				,giveto
				,copyName
				,copyStatus) 
			SELECT 
				docid
				,podrId
				,givedate
				,takedate
				,giveto
				,copyName
				,copyStatus 
			FROM ' + @docpodr + ''
EXEC (@sql4)



IF @@ERROR = 0
COMMIT
ELSE 
ROLLBACK

end
GO
