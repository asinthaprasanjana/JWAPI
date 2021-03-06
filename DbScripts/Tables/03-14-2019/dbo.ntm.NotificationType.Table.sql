USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[ntm.NotificationType]    Script Date: 14/03/2019 11:45:46 AM ******/
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
