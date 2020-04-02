USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CommonAttributes]    Script Date: 30/05/2019 11:35:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.CommonAttributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttributeName] [varchar](50) NOT NULL,
	[Type] [varchar](100) NOT NULL,
	[showAttribute] [tinyint] NOT NULL
) ON [PRIMARY]
GO
