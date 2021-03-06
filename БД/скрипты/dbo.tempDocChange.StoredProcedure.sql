USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[tempDocChange]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tempDocChange] @Tname varchar(100),@Tpodr varchar(100)
AS BEGIN 

CREATE TABLE tempDC (
	id int identity(1,1) NOT NULL 
	,docId int 
	,number varchar(100) 
	,regDate datetime 
	,vvodDate datetime
	,regDoc varchar(100))

EXEC SP_RENAME tempDC, @Tname

CREATE TABLE PodrDocTemp (
	id int identity(1,1) NOT NULL
	,docId int
	,podrId varchar(20)
	,examplnum int
	,givedate datetime
	,takedate datetime
	,giveto varchar(50)
	,copyName varchar(10)
	,copyStatus int)

EXEC SP_RENAME PodrDocTemp, @Tpodr

END
GO
