USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.BranchTypes]    Script Date: 30/05/2019 11:35:29 AM ******/
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
