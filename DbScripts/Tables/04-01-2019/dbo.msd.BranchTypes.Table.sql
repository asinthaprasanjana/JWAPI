USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.BranchTypes]    Script Date: 01/04/2019 9:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.BranchTypes](
	[Id] [int] NULL,
	[BranchId] [int] NULL,
	[BranchTypeId] [int] NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
