USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[ntm.NotificationTypeDetails]    Script Date: 16/05/2019 12:00:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ntm.NotificationTypeDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NotificationTypeId] [smallint] NULL,
	[NotificationType] [varchar](20) NULL,
	[CompanyId] [int] NULL,
	[RoleIds] [varchar](20) NULL,
	[IsActive] [tinyint] NULL
) ON [PRIMARY]
GO
