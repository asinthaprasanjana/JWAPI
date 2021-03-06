USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[usm.UserRoles]    Script Date: 07/03/2019 10:01:20 AM ******/
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
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
