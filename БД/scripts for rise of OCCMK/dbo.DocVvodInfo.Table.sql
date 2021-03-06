USE [OCCMK]
GO
/****** Object:  Table [dbo].[DocVvodInfo]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocVvodInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[docId] [int] NULL,
	[vnedNumber] [varchar](100) NULL,
	[vnedDate] [datetime] NULL,
	[podrId] [int] NULL,
	[orderNum] [varchar](100) NULL,
	[orderDate] [datetime] NULL,
	[endOTM] [datetime] NULL,
	[vvedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
