USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.BranchTypes]    Script Date: 16/05/2019 12:00:27 PM ******/
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
