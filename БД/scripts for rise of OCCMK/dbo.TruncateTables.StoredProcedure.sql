USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[TruncateTables]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TruncateTables]
AS
BEGIN

	SET NOCOUNT ON;

	truncate table dbo.ActProverky
	truncate table dbo.ActVnedren
	--truncate table dbo.CopyStatus
	truncate table dbo.Departments
	truncate table dbo.Developer
	truncate table dbo.DocChange
	truncate table dbo.DocSecret
	--truncate table dbo.DocStatus
	--truncate table dbo.DocType
	truncate table dbo.DocVvodInfo
	truncate table dbo.Kart
	truncate table dbo.PodrDoc
	truncate table dbo.PoluchatelInfo
	truncate table dbo.ZaprosInfo
END
GO
