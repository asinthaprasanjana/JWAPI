USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CurrentUserLoginDetails]    Script Date: 28/06/2019 4:47:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.CurrentUserLoginDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[UserId] [smallint] NOT NULL,
	[IsLogedIn] [tinyint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
