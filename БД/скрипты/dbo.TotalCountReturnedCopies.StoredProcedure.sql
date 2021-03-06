USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[TotalCountReturnedCopies]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TotalCountReturnedCopies] @TName varchar(50),@docId int,@depId int
AS
BEGIN

SET DATEFORMAT dmy 

DECLARE @sql AS VARCHAR(1000)
IF @depId = '0'
BEGIN
SET @sql = 'SELECT
				ROW_NUMBER() OVER (
					PARTITION BY 
						copyName 
					ORDER BY 
						docId
						,podrId
						,copyName
						,id DESC)		rn
				,[id]
				,[docId]
				,[podrId]
				,[examplnum]
				,[givedate]
				,[takedate]
				,[giveto]
				,[copyName]
				,[copyStatus]
			INTO #t
			FROM ' + 
				@TName + '
			WHERE (docId = ' + cast(@docId as varchar) + ') '
END
ELSE
BEGIN
	SET @sql = 'SELECT
					ROW_NUMBER() OVER (
						PARTITION BY 
							copyName 
						ORDER BY 
							docId
							,podrId
							,copyName
							,id DESC) rn
					,[id]
					,[docId]
					,[podrId]
					,[examplnum]
					,[givedate]
					,[takedate]
					,[giveto]
					,[copyName]
					,[copyStatus]
				INTO #t
				FROM ' + 
					@TName + '
				WHERE (
					docId = ' + cast(@docId as varchar) + ' AND 
					podrId = '+ cast(@depId as varchar) + ') '
END

DECLARE @sql1 AS VARCHAR(1000)
SET @sql1 =		@sql + ' 
				SELECT 
					#t.id 
					,#t.copyName AS			[Номер экземпляра] 
					,#t.givedate AS			[Дата выдачи] 
					,#t.giveto AS			[Ф.И.О получившего] 
					,#t.takedate AS			[Дата возврата] 
					,s.status 
				INTO #tt
				FROM #t 
				LEFT JOIN copyStatus s ON #t.copyStatus = s.id 
				WHERE rn = 1 '
				
DECLARE @sql2 AS VARCHAR(1000)
SET @sql2 =		@sql1 + ' 
				SELECT COUNT (#tt.id)
				FROM #tt 
				LEFT JOIN copyStatus s ON #tt.status = s.status 
				WHERE s.id in (1,3) --spisan i spisan po aktu '
				
exec (@sql2)

END
GO
