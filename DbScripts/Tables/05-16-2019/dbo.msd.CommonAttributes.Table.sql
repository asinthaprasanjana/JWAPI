USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CommonAttributes]    Script Date: 16/05/2019 12:00:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.CommonAttributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttributeName] [varchar](50) NOT NULL,
	[Values] [varchar](1500) NOT NULL,
	[showAttribute] [tinyint] NOT NULL
) ON [PRIMARY]
GO
