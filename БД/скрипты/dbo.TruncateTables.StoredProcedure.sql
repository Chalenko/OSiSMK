USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[TruncateTables]    Script Date: 12/22/2015 16:10:02 ******/
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

	TRUNCATE TABLE dbo.ActProverky
	TRUNCATE TABLE dbo.ActVnedren
	--TRUNCATE TABLE dbo.CopyStatus
	TRUNCATE TABLE dbo.Departments
	TRUNCATE TABLE dbo.Developer
	TRUNCATE TABLE dbo.DocChange
	TRUNCATE TABLE dbo.DocSecret
	--TRUNCATE TABLE dbo.DocStatus
	--TRUNCATE TABLE dbo.DocType
	TRUNCATE TABLE dbo.DocVvodInfo
	TRUNCATE TABLE dbo.Kart
	TRUNCATE TABLE dbo.PodrDoc
	TRUNCATE TABLE dbo.PoluchatelInfo
	TRUNCATE TABLE dbo.ZaprosInfo
END
GO
