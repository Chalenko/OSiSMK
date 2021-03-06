USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[SelectPodrDocInfoForPrintCard]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPodrDocInfoForPrintCard]
	@docId int

AS BEGIN
SELECT 
	ROW_NUMBER() OVER (
		PARTITION BY 
			docId
			,copyName 
		ORDER BY 
			docId
			,podrId
			,code
			,name
			,copyName
			,pd.id DESC)		rn, 
	pd.id 
	,docId 
	,podrId
	,d.code 
	,d.name 
	,copyName 
	,copyStatus 
INTO #t1
FROM PodrDoc pd
LEFT JOIN Departments d ON d.id = pd.podrId
WHERE docId = @docId --AND 
--copyStatus = 1
ORDER BY  code

SELECT name,
		count(copyName) AS copyCount
INTO #countCopyTable 
FROM #t1
WHERE rn=1 
GROUP BY name 

SELECT 
	name
	,COUNT(copyName) AS copyReturnedCount 
INTO #countReturnedCopyTable 
FROM #t1
WHERE (
	rn=1 AND 
	copystatus = 1)
GROUP BY name

DROP TABLE #t1

SELECT	d.id					[Индекс подразделения]
--		,d.code					[Код подразделения]
		,ct.copyCount			[Количество копий]
		,rt.copyReturnedCount	[Количество копий списано]
FROM #countCopyTable ct
LEFT JOIN #countReturnedCopyTable rt	ON ct.name = rt.name
LEFT JOIN Departments d					ON ct.name = d.name
ORDER BY d.code

DROP TABLE #countCopyTable
DROP TABLE #countReturnedCopyTable
END
GO
