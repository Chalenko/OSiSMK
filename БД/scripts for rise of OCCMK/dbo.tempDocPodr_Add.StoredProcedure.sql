USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[tempDocPodr_Add]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--ALTER procedure [dbo].[tempDocPodr_Add] @Tpodr varchar(50),@codpodr int,@givedate datetime,@takedate datetime,@giveto varchar(50)
--ALTER procedure [dbo].[tempDocPodr_Add] @Tpodr varchar(50),@givedate datetime,@takedate datetime,@giveto varchar(50)
CREATE procedure [dbo].[tempDocPodr_Add] @Tpodr varchar(50),@takedate datetime,@giveto varchar(50)

as begin
 
declare @dt as varchar(50)
set @dt = cast(@takedate as varchar) 

--declare @exnum as int
--set @exnum = (select count(examplnum) from PodrDoc where codpodr = @codpodr)

declare @sql varchar(250) 
--set @sql = 'Insert into ' + @Tpodr + ' values ('+ 150 +','+ @codpodr +',' + @exnum + ',' + @givedate+ ','+ @takedate + ',' + @giveto + ')'
--set @sql = 'Insert into ' + @Tpodr + ' values ('+ null +','+ null +',' + @exnum + ',' + null+ ','+ null + ',' + null + ')'
--set @sql = 'Insert into ' + @Tpodr + ' (givedate,takedate,giveto) values ('+ @givedate+ ','+ @takedate + ',' + @giveto + ')'
set @sql = 'Insert into ' + @Tpodr + ' (takedate,giveto) values (' + @dt  +','+ @giveto + ')'
exec(@sql)
end
GO
