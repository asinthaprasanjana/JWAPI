USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.tempProductLevels]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.tempProductLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentLevelId] [int] NOT NULL,
	[AttributeName] [varchar](50) NOT NULL,
	[Level] [int] NOT NULL,
	[CreatedDateTime] [date] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.tempProductLevels] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
