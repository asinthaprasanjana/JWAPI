USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CommonAttributes]    Script Date: 28/06/2019 4:47:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.CommonAttributes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttributeName] [varchar](50) NOT NULL,
	[Type] [varchar](100) NOT NULL,
	[showAttribute] [tinyint] NOT NULL,
	[isDeleted] [tinyint] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.CommonAttributes] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
