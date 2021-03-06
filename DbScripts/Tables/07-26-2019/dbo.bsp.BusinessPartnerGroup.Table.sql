USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[bsp.BusinessPartnerGroup]    Script Date: 26/07/2019 10:08:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bsp.BusinessPartnerGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [varchar](30) NULL,
	[GroupName] [varchar](50) NULL,
	[BusinessPartnerTypeId] [int] NULL,
	[BusinessPartnerTypeName] [varchar](50) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
