USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[usm.UserRoles]    Script Date: 14/03/2019 11:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usm.UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId]  AS ([Id]) PERSISTED NOT NULL,
	[PageNameList] [varchar](50) NULL,
	[CompanyId] [int] NULL,
	[RoleName] [nvarchar](50) NULL,
	[PageIds] [varchar](150) NULL,
	[PrivilegeIds] [varchar](150) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[usm.UserRoles] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
