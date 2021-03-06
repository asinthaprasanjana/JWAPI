USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[usm.ApplicationUserBranches]    Script Date: 01/04/2019 9:42:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usm.ApplicationUserBranches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[BusinessProcessId] [int] NULL,
	[Branches] [varchar](100) NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[usm.ApplicationUserBranches] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
