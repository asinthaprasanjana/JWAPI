USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.BranchTypes]    Script Date: 15/07/2019 12:08:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.BranchTypes](
	[Id] [int] NULL,
	[BranchId] [smallint] NULL,
	[BranchTypeId] [int] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
