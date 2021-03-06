USE [OCCMK]
GO
/****** Object:  Table [dbo].[Kart]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kart](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[docTypeId] [int] NOT NULL,
	[obozn] [varchar](100) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[dateEnter] [datetime] NULL,
	[docStatus] [int] NULL,
	[docSecret] [int] NULL,
	[docDevel] [int] NULL,
	[vzamen] [int] NULL,
	[zamenen] [int] NULL,
	[vnedrAct] [int] NULL,
	[provAct] [int] NULL,
	[dateProv] [datetime] NULL,
	[controlCopyExist] [bit] NULL,
	[original] [bit] NULL,
	[dateEndOfAction] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
