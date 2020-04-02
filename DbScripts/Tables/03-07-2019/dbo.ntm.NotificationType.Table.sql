USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[ntm.NotificationType]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ntm.NotificationType](
	[Id] [int] NULL,
	[CompanyId] [int] NULL,
	[NotificationTypeId] [int] NULL,
	[NotificationName] [nvarchar](50) NULL,
	[Header] [nvarchar](50) NULL,
	[Message] [nvarchar](100) NULL,
	[IsActive] [tinyint] NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
