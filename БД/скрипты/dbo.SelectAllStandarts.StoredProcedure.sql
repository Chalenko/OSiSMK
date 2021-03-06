USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[SelectAllStandarts]    Script Date: 12/22/2015 16:10:02 ******/
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
SELECT 
	CAST(ROW_NUMBER() OVER (ORDER BY k.id) AS varchar)				'№ п/п'
	,k.id															'Номер'
	--,k.docTypeId 'docTypeId'--
	,dt.docType														'Документ (внешний/внутренний)'
	,k.obozn														'Обозначение документа'
	,k.name															'Наименование документа'
	,CONVERT(varchar(10),k.dateEnter,104)							'Дата введения'
	--,k.dateEnter													'Дата введения'
	,CONVERT(varchar(10),pInfo.poluchDate,104)						'Информация о получении $ Дата получения'
	,dev.developer													'Информация о получении $ Откуда получен'
	,dvi.vnedNumber													'Информация о введении $ Номер поручения о внедрении'
	,CONVERT(varchar(10),dvi.vnedDate,104)							'Информация о введении $ Дата поручения о внедрении'
	,dep.code														'Информация о введении $ Код подразделения ответственного за внедрение'
	,dep.name														'Информация о введении $ Наименование ответственного подразделения'
	,dvi.orderNum													'Информация о введении $ Номер приказа/распоряжения'
	,CONVERT(varchar(10),dvi.orderDate, 104)						'Информация о введении $ Дата приказа/распоряжения'
	,CONVERT(varchar(10),dvi.endOTM, 104)							'Информация о введении $ Дата завершения ОТМ(при наличии ОТМ)'
	,CONVERT(varchar(10),dvi.vvedDate, 104)							'Информация о введении $ Дата введения на предприятии'

FROM [OCCMK].[dbo].[Kart] k 
	LEFT JOIN docType dt			ON dt.id = k.doctypeid 
	LEFT JOIN PoluchatelInfo pInfo	ON pInfo.docId = k.id 
	LEFT JOIN DocVvodInfo dvi		ON dvi.docID = k.id 
	LEFT JOIN Departments dep		ON dep.id = dvi.podrId 
	LEFT JOIN Developer dev			ON dev.id = pInfo.addres 
ORDER BY k.id 
END
GO
