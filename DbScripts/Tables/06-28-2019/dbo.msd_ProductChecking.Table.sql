USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd_ProductChecking]    Script Date: 28/06/2019 4:47:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd_ProductChecking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductCheckingId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd_ProductChecking] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
