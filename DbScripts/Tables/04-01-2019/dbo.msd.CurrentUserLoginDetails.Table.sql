USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CurrentUserLoginDetails]    Script Date: 01/04/2019 9:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.CurrentUserLoginDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[UserId] [int] NOT NULL,
	[IsLogedIn] [tinyint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
