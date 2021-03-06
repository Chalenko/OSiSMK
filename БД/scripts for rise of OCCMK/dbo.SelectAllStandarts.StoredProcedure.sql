USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[SelectAllStandarts]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectAllStandarts]
AS
BEGIN
select cast(row_number()	over (order by k.id) as varchar) '№ п/п',
	k.id 'Номер документа'
	--,k.docTypeId 'docTypeId'--
	,dt.docType 'Документ (внешний/внутренний)'
	,k.obozn 'Обозначение документа'
	,k.name 'Наименование документа'
	,CONVERT(varchar(10),k.dateEnter,104) 'Дата введения'
	,CONVERT(varchar(10),pInfo.poluchDate,104) 'Информация о получении $ Дата получения'
	,dev.developer 'Информация о получении $ Откуда получен'
	,dvi.vnedNumber 'Информация о введении $ Номер поручения о внедрении'
	,CONVERT(varchar(10),dvi.vnedDate,104) 'Информация о введении $ Дата поручения о внедрении'
	,dep.code 'Информация о введении $ Код подразделения ответственного за внедрение'
	,dep.name 'Информация о введении $ Наименование ответственного подразделения'
	,dvi.orderNum 'Информация о введении $ Номер приказа/распоряжения'
	,CONVERT(varchar(10),dvi.orderDate, 104) 'Информация о введении $ Дата приказа/распоряжения'
	,CONVERT(varchar(10),dvi.endOTM, 104) 'Информация о введении $ Дата завершения ОТМ(при наличии ОТМ)'
	,CONVERT(varchar(10),dvi.vvedDate, 104) 'Информация о введении $ Дата введения на предприятии'

from [OCCMK].[dbo].[Kart] k
	left join docType dt on  dt.id = k.doctypeid 
	left join PoluchatelInfo pInfo on pInfo.docId = k.id
	left join DocVvodInfo dvi on dvi.docID = k.id
	left join Departments dep on dep.id = dvi.podrId
	left join Developer dev on dev.id = pInfo.addres
END
GO
