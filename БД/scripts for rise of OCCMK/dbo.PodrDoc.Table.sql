USE [OCCMK]
GO
/****** Object:  Table [dbo].[PodrDoc]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PodrDoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[docId] [int] NULL,
	[podrId] [varchar](20) NULL,
	[examplnum] [int] NULL,
	[givedate] [datetime] NULL,
	[takedate] [datetime] NULL,
	[giveto] [varchar](50) NULL,
	[copyName] [varchar](10) NULL,
	[copyStatus] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
