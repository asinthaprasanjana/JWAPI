USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[usm.UserRoles]    Script Date: 15/07/2019 12:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usm.UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId]  AS ([Id]) PERSISTED NOT NULL,
	[PageNameList] [varchar](50) NULL,
	[CompanyId] [smallint] NULL,
	[RoleName] [varchar](50) NULL,
	[PageIds] [varchar](150) NULL,
	[PrivilegeIds] [varchar](150) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[usm.UserRoles] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
