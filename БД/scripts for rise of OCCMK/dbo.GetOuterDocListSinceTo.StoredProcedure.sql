USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[GetOuterDocListSinceTo]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOuterDocListSinceTo] 
	@date1 datetime = 0, 
	@date2 datetime = 0
AS
BEGIN

select 
	k.id
	,cast(row_number()	over (order by k.id) as varchar) '№ п/п'
	--,k.docTypeId
	,CONVERT(varchar(10),pin.poluchDate,104) [Дата получения]
	,k.obozn[Обозначение документа]
	,k.name [Наименование документа]
	,kvz.obozn [Взамен$Обозначение документа]
	,kvz.name [Взамен$Наименование документа]
	,CONVERT(varchar(10),k.dateEnter,104) [Дата$Дата введения]
	,CONVERT(varchar(10),dvi.orderDate,104) [Дата$Дата введения на предприятии]
	,dev.Developer [Разработчик]
	,pin.number [Входящий регистрационный номер]
	,CONVERT(varchar(10),pin.poluchDate,104) [Вх. дата] 
from kart k
	left join PoluchatelInfo pin on k.id = pin.docId
	left join Kart kvz on kvz.id = k.Vzamen
	left join DocVvodInfo dvi on dvi.docId = k.id
	left join Developer dev on dev.id = k.docDevel
where k.docTypeId in 
		(select id from doctype where docType = 'Внешний')
			and
		pin.poluchDate between @date1 and dateadd(day, 1, @date2)
		
end
GO
