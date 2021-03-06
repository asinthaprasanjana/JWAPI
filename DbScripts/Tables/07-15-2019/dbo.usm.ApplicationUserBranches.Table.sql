USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[usm.ApplicationUserBranches]    Script Date: 15/07/2019 12:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usm.ApplicationUserBranches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [smallint] NOT NULL,
	[BusinessProcessId] [int] NULL,
	[Branches] [varchar](100) NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[usm.ApplicationUserBranches] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
