USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[Kartoteka_Select]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Kartoteka_Select]

AS BEGIN


SELECT 
	k.id					'Номер'
	,k.obozn				'Обозначение'
	,k.name					'Наименование документа'
	,dt.doctype				'Тип'
	--,CONVERT(varchar(10), k.dateenter, 104)  'Дата введения'
	,k.dateenter			'Дата введения'
	,ds.status				'Статус'
	,sec.docsecret			'Секретность'
	,dev.developer			'Разработчик'
	--,CONVERT(varchar(10), k.dateprov, 104) 'Дата проверки'
	,k.dateprov				'Дата проверки'
FROM Kart k
	LEFT JOIN doctype dt	ON dt.id = k.doctypeid
	LEFT JOIN docstatus ds	ON ds.id = k.docstatus 
	LEFT JOIN docsecret sec ON sec.id = k.docsecret
	LEFT JOIN developer dev ON dev.id = k.docdevel

END
GO
