USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[GetOuterDocListSinceTo]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOuterDocListSinceTo] 
	@date1 datetime = 0, 
	@date2 datetime = 0
AS
BEGIN

SELECT 
	k.id													[Номер]
	,CAST(ROW_NUMBER() OVER (ORDER BY k.id) AS varchar)		[№ п/п]
	--,k.docTypeId
	,CONVERT(varchar(10),pin.poluchDate,104)				[Дата получения]
	,k.obozn												[Обозначение документа]
	,k.name													[Наименование документа]
	,kvz.obozn												[Взамен$Обозначение документа]
	,kvz.name												[Взамен$Наименование документа]
	,CONVERT(varchar(10),k.dateEnter,104)					[Дата$Дата введения]
	,CONVERT(varchar(10),dvi.orderDate,104)					[Дата$Дата введения на предприятии]
	,dev.Developer											[Разработчик]
	,pin.number												[Входящий регистрационный номер]
	,CONVERT(varchar(10),pin.poluchDate,104)				[Вх. дата] 
FROM kart k
	LEFT JOIN PoluchatelInfo pin	ON k.id = pin.docId
	LEFT JOIN Kart kvz				ON kvz.id = k.Vzamen
	LEFT JOIN DocVvodInfo dvi		ON dvi.docId = k.id
	LEFT JOIN Developer dev			ON dev.id = k.docDevel
WHERE (
	k.docTypeId IN (
		SELECT id 
		FROM doctype 
		WHERE docType = 'Внешний') AND
	--pin.poluchDate between @date1 and dateadd(day, 1, @date2)
	k.dateEnter BETWEEN @date1 AND DATEADD(DAY, 1, @date2))
		
END
GO
