USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.BranchTypes]    Script Date: 26/07/2019 10:08:53 AM ******/
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
