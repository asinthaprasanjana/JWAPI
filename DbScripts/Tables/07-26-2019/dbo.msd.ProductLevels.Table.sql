USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.ProductLevels]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.ProductLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentLevelId] [int] NOT NULL,
	[AttributeName] [varchar](50) NOT NULL,
	[Level] [int] NOT NULL,
	[CreatedDateTime] [date] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.ProductLevels] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
