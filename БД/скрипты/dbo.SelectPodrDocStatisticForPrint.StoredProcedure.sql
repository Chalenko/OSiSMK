USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[SelectPodrDocStatisticForPrint]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPodrDocStatisticForPrint]
	@podrId int

AS BEGIN

SELECT 
	ROW_NUMBER() OVER (
		PARTITION BY 
			docId
			,copyName 
		ORDER BY 
			docId
			,podrId
			,copyName
			,id DESC)		rn
	,id 
	,docId 
	,podrId 
	,copyName 
	,copyStatus 
INTO #t1 
FROM PodrDoc 
WHERE  (podrId = @podrId AND 
		copyStatus in (1,3))--spisan i spisan po aktu
ORDER BY docId

SELECT 
	docId
	,COUNT(copyName) AS copyReturnedCount 
INTO #countReturnedCopyTable 
FROM #t1
WHERE rn=1 
GROUP BY docId

DROP TABLE #t1
		
SELECT 
	pd.docId
	,(SELECT name 
	FROM Kart 
	WHERE id = pd.docId)			name
	,COUNT(DISTINCT pd.copyName)	copySumCount
INTO #uniqueDocTable
FROM podrDoc pd
LEFT JOIN Kart k ON k.id = pd.docId
WHERE (pd.docId IN (
	SELECT DISTINCT docId 
	FROM podrDoc 
	WHERE podrId = @podrId) AND 
	pd.podrId = @podrId)
GROUP BY pd.docId
ORDER BY docId

SELECT 
ud.docId						"Номер"
,name							"Наименование"
,copySumCount					"Количество экземпляров"
,copyReturnedCount				"Количество списанных экземпляров"
FROM #uniqueDocTable ud
LEFT JOIN #countReturnedCopyTable crd ON crd.docId = ud.docId

DROP TABLE #uniqueDocTable
DROP TABLE #countReturnedCopyTable

END
GO
