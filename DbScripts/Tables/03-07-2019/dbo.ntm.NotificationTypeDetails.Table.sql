USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[ntm.NotificationTypeDetails]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ntm.NotificationTypeDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NotificationTypeId] [int] NULL,
	[NotificationType] [varchar](20) NULL,
	[CompanyId] [int] NULL,
	[RoleIds] [varchar](20) NULL,
	[IsActive] [tinyint] NULL
) ON [PRIMARY]
GO
