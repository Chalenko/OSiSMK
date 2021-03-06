USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[tempDocChange]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tempDocChange] @Tname varchar(100),@Tpodr varchar(100)
as begin 

create table tempDC
(
id int identity(1,1) not null,
docId int,
number varchar(100) ,
regDate datetime ,
vvodDate datetime, 
regDoc varchar(100) 
)

exec sp_rename tempDC, @Tname

create table PodrDocTemp
(
id int identity(1,1) not null,
docId int,
podrId varchar(20),
examplnum int,
givedate datetime,
takedate datetime,
giveto varchar(50),
copyName varchar(10),
copyStatus int
)

exec sp_rename PodrDocTemp, @Tpodr

end
GO
