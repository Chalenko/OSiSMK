USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[GetInnerDocListSinceTo]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInnerDocListSinceTo] 
	@date1 datetime = 0, 
	@date2 datetime = 0
AS
BEGIN

	select
	
		k.id
		,row_number() over (order by k.id) "№ п/п"
		,k.obozn [Обозначение документа]
		,k.name [Наименование документа]
		--,k.zamenen 
		--,k.vzamen 
		,kVz.obozn[Взамен $ Обозначение документа]
		,kVz.name[Взамен $ Наименование документа]
		,CONVERT(varchar(10),vdi.orderDate,104)[Дата введения в действие на предприятии]
		--,k.docDevel
		,dev.developer[Разработчик]
		,dc.Number[Изменения(поправки)$ Номер]
		,CONVERT(varchar(10),dc.regDate, 104)[Изменения(поправки) $ Дата регистрации]
		,CONVERT(varchar(10),dc.vvodDate, 104)[Изменения(поправки) $ Дата введения в действие]
	from Kart k
		left join Kart kVz on kvz.id = k.vzamen
		left join DocVvodInfo vdi on vdi.docId = k.id
		left join Developer dev on dev.id = k.docDevel
		left join DocChange dc on dc.docId = k.id
	where 
		k.docTypeId in 
					(select id from DocType where docType = 'Внутренний')
		and
			vvedDate between @date1 and dateadd(day, 1, @date2)
		
		
		
END
GO
