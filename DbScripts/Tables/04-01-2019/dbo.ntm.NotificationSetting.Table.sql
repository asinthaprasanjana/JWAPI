USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[ntm.NotificationSetting]    Script Date: 01/04/2019 9:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ntm.NotificationSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NotificationTypeId] [int] NULL,
	[CompanyId] [int] NULL,
	[NotificationName] [varchar](150) NULL,
	[Header] [varchar](100) NULL,
	[Message] [varchar](150) NULL,
	[Status] [tinyint] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
