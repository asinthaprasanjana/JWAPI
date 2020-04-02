USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.UserComment]    Script Date: 16/05/2019 12:00:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.UserComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserComments] [varchar](max) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
