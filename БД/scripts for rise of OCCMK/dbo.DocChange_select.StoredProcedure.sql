USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[DocChange_select]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DocChange_select] @Tpodr varchar(50),@id int

as begin

set dateformat dmy 

declare @sql as varchar(500)
set @sql = 'select t.id, t.number as [Номер], t.regdoc as [Документ], 
			Convert(varchar(10), t.regdate, 104) as [Дата регистрации], Convert(varchar(10), t.vvoddate, 104) as [Дата введения] from '
			+@Tpodr+' as t 
			where docid = ' + cast(@id as varchar)

exec (@sql)

end
GO
