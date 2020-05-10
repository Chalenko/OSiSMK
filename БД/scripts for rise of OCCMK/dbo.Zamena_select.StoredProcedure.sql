USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[Zamena_select]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Zamena_select]
as begin

select k.id ,dt.doctype [Тип документа],k.obozn [Обозначение],k.name [Наименование] from kart k
left join doctype dt 
on dt.id = k.doctypeid

end
GO
