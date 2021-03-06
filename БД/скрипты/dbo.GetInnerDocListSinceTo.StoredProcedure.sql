USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[GetInnerDocListSinceTo]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInnerDocListSinceTo] 
	@date1 datetime = 0, 
	@date2 datetime = 0
AS
BEGIN

	SELECT
		k.id										[Номер]
		,ROW_NUMBER() OVER (ORDER BY k.id)			[№ п/п]
		,k.obozn									[Обозначение документа]
		,k.name										[Наименование документа]
		--,k.zamenen 
		--,k.vzamen 
		,kVz.obozn									[Взамен $ Обозначение документа]
		,kVz.name									[Взамен $ Наименование документа]
		,CONVERT(varchar(10),vdi.orderDate,104)		[Дата введения в действие на предприятии]
		--,k.docDevel
		,dev.developer								[Разработчик]
		,dc.Number									[Изменения(поправки)$ Номер]
		,CONVERT(varchar(10),dc.regDate, 104)		[Изменения(поправки) $ Дата регистрации]
		,CONVERT(varchar(10),dc.vvodDate, 104)		[Изменения(поправки) $ Дата введения в действие]
	FROM Kart k
		LEFT JOIN Kart kVz			ON kvz.id = k.vzamen
		LEFT JOIN DocVvodInfo vdi	ON vdi.docId = k.id
		LEFT JOIN Developer dev		ON dev.id = k.docDevel
		LEFT JOIN DocChange dc		ON dc.docId = k.id
	WHERE (
		k.docTypeId IN (
			SELECT id 
			FROM DocType 
			WHERE docType = 'Внутренний') AND
		--vvedDate between @date1 and dateadd(day, 1, @date2)
		k.dateEnter BETWEEN @date1 AND DATEADD(DAY, 1, @date2))

END
GO
