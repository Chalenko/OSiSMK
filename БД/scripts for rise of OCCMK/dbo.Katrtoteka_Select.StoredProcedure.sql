USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[Katrtoteka_Select]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Katrtoteka_Select]

as begin


select 

k.id 'Номер'
,k.obozn 'Обозначение'
,k.name 'Наименование документа'
,dt.doctype 'Тип'
,CONVERT(varchar(10), k.dateenter, 104)  'Дата введения'
,ds.status 'Статус'
,sec.docsecret 'Секретность'
,dev.developer 'Разработчик'
,CONVERT(varchar(10), k.dateprov, 104) 'Дата проверки'

from Kart k
	left join doctype dt on dt.id = k.doctypeid
	left join docstatus ds on ds.id = k.docstatus 
	left join docsecret sec on sec.id = k.docsecret
	left join developer dev on dev.id = k.docdevel 

end
GO
