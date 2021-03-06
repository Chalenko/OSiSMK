USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[DocChange_select]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DocChange_select] @Tpodr varchar(50),@id int

AS BEGIN

SET DATEFORMAT dmy 

DECLARE @sql AS VARCHAR(500)
SET @sql = '
	SELECT 
		t.id 
		,t.number as			[Номер] 
		,t.regdoc as			[Документ] 
		--,Convert(varchar(10), t.regdate, 104) as [Дата регистрации] 
		,t.regdate as			[Дата регистрации] 
		--,Convert(varchar(10), t.vvoddate, 104) as [Дата введения] 
		,t.vvoddate as			[Дата введения] 
	FROM '
		+@Tpodr+' as t 
	WHERE docid = ' + cast(@id as varchar)

EXEC (@sql)

END
GO
