USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[SelectPodrDocForPrint]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPodrDocForPrint]
	@podrId int

AS BEGIN
	
	select 
		row_number() OVER (partition BY copyName, docId ORDER BY docId, podrId, copyName, pd.id DESC) rn
		,pd.id 
		,pd.podrId podrId
		,docId
		,dep.name depname
		,dep.code
		,pd.copyName
		,k.obozn
		,k.name
		,CONVERT(varchar(10),pd.giveDate,104) giveDate
		,pd.giveTo
		,CONVERT(varchar(10),pd.takedate,104) takedate
		,pd.copyStatus
		,cs.status
	into #t	
	from podrDoc pd
		left join departments dep on pd.podrId = dep.id
		left join kart k on k.id = pd.docId
		left join copyStatus cs on cs.id = pd.copyStatus
	where pd.podrId = @podrId 
	order by docId, copyName
	
	select 
	row_number() over (order by docId) "№ п/п"
	, id
	, docId
	, depname "Документ выдан в подразделение $ Кому выдан"
	, code "Документ выдан в подразделение $ Индекс подразделения"
	, [copyName]"Документ выдан в подразделение $ Номер экземпляра"
	, obozn "Обозначение документа"
	, name "Наименование документа"
	, [givedate] "Дата выдачи"
	, [giveto] "ФИО получившего"
	, [takedate] "Дата возврата"
	--, [copyStatus]
	, status "Статус"
	 from #t where rn=1
	 
	 drop table #t
END
GO
