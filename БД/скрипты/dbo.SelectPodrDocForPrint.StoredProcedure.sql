USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[SelectPodrDocForPrint]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPodrDocForPrint]
	@podrId int

AS BEGIN
	SELECT 
		ROW_NUMBER() OVER (
			PARTITION BY 
				copyName 
				,docId 
			ORDER BY 
				docId
				,podrId
				,copyName
				,pd.id DESC)					rn
		,pd.id 
		,pd.podrId								podrId
		,docId
		,dep.name								depname
		,dep.code
		,pd.copyName
		,k.obozn
		,k.name
		,CONVERT(varchar(10),pd.giveDate,104)	giveDate
		,pd.giveTo
		,CONVERT(varchar(10),pd.takedate,104)	takedate
		,pd.copyStatus
		,cs.status
	INTO #t	
	FROM podrDoc pd
	LEFT JOIN departments dep	ON pd.podrId = dep.id
	LEFT JOIN kart k			ON k.id = pd.docId
	LEFT JOIN copyStatus cs		ON cs.id = pd.copyStatus
	WHERE pd.podrId = @podrId 
	ORDER BY 
		docId
		,copyName
	
	SELECT 
		ROW_NUMBER() OVER (ORDER BY docId)	"№ п/п"
		,id
		,docId
		,depname							"Документ выдан в подразделение $ Кому выдан"
		,code								"Документ выдан в подразделение $ Индекс подразделения"
		,[copyName]							"Документ выдан в подразделение $ Номер экземпляра"
		,obozn								"Обозначение документа"
		,name								"Наименование документа"
		,[givedate]							"Дата выдачи"
		,[giveto]							"ФИО получившего"
		,[takedate]							"Дата возврата"
		--, [copyStatus]
		,status								"Статус"
	FROM #t 
	WHERE rn=1
	 
	DROP TABLE #t
END
GO
