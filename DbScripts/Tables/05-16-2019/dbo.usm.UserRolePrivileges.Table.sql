USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[usm.UserRolePrivileges]    Script Date: 16/05/2019 12:00:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usm.UserRolePrivileges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrivilegeId] [int] NOT NULL,
	[IsActive] [tinyint] NOT NULL,
	[RoleIds] [varchar](150) NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[usm.UserRolePrivileges] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
