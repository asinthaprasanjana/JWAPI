USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CommonGroups]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.CommonGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](50) NOT NULL,
	[Attributes] [varchar](1000) NULL
) ON [PRIMARY]
GO
