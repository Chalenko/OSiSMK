USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[refresh_exempl]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[refresh_exempl] @Tname varchar(50)
as begin

declare @sql as varchar(500)
set @sql =' ;with cte as
(
	select id,row_number() over (partition by codpodr,docid order by ID) num ,codpodr,examplnum
	from '+@Tname+'
)
update cte set examplnum = num'

exec (@sql)

end
GO
