USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[SelectLastDocPodr]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectLastDocPodr] @TName varchar(50),@docId int,@depId int
AS
BEGIN

SET DATEFORMAT dmy 

DECLARE @sql AS VARCHAR(1000)
IF @depId = '0'
BEGIN
SET @sql = 'SELECT
				row_number() 
				OVER (
					partition 
				BY 
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
			INTO 
				#t
			FROM ' + 
				@TName + '
			WHERE (
				docId = ' + cast(@docId as varchar) + ') '
END
ELSE
BEGIN
	SET @sql = 'SELECT
					row_number() 
					OVER (
						partition 
					BY 
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
				INTO 
					#t
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
					,#t.docid [Номер документа]
					,d.code [Индекс подразделения]
					,d.name [Имя подразделения]
					,#t.copyName AS [Номер экземпляра] 
					,Convert(varchar(10), #t.givedate, 104) AS [Дата выдачи] 
					,#t.giveto AS [Ф.И.О. получившего] 
					,Convert(varchar(10), #t.takedate, 104) AS [Дата списания]  
					,s.status AS [Статус] 
				FROM 
					#t 
				LEFT JOIN copyStatus s ON 
					#t.copyStatus = s.id 
				LEFT JOIN departments d ON 
					#t.podrId = d.id 
				WHERE rn = 1 '
				
exec (@sql1)

END
GO
