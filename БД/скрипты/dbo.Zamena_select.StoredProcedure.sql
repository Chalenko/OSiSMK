USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[Zamena_select]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Zamena_select]
AS BEGIN

SELECT 
	k.id
	,dt.doctype		[Тип документа]
	,k.obozn		[Обозначение]
	,k.name			[Наименование]
FROM kart k
LEFT JOIN doctype dt ON dt.id = k.doctypeid

END
GO
