USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.AdvanceSetting]    Script Date: 26/07/2019 10:08:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.AdvanceSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SettingTypeId] [int] NULL,
	[IsActive] [int] NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
